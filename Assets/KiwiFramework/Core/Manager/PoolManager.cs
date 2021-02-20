using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 对象池管理
    /// </summary>
    public class PoolManager : Singleton<PoolManager>
    {
        /// <summary>
        /// 对象池信息
        /// </summary>
        private struct PoolInfo
        {
            /// <summary>
            /// 对象预制体
            /// </summary>
            public GameObject Prefab;

            /// <summary>
            /// 容量
            /// </summary>
            public int Capacity;

            /// <summary>
            /// 是否预加载kd
            /// </summary>
            public bool Preload;

            /// <summary>
            /// 组名
            /// </summary>
            public string Group;
        }

        #region Private Variables

        /// <summary>
        /// 对象池管理器父物体
        /// </summary>
        private readonly Transform _parent;

        /// <summary>
        /// 对象池字典
        /// </summary>
        private readonly Dictionary<string, UnityObjectPool> dic_pool;

        /// <summary>
        /// 对象池信息列表
        /// </summary>
        private Dictionary<GameObject, PoolInfo> dic_poolInfo;

        #endregion

        #region Constructor

        private PoolManager()
        {
            dic_pool = new Dictionary<string, UnityObjectPool>();

            if (_parent != null && !_parent.Equals(null)) return;
            GameObject go = new GameObject("[UnityObject Pools]");
            _parent = go.transform;
            Object.DontDestroyOnLoad(go);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 移除管理的对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        private bool RemovePool(string poolName)
        {
            return dic_pool.Remove(poolName);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 添加加载信息
        /// </summary>
        /// <param name="_prefab">对象路径</param>
        /// <param name="_capacity">对象池容量</param>
        /// <param name="_preload">是否预加载</param>
        public void AddLoadInfo(GameObject _prefab, int _capacity, bool _preload)
        {
            AddLoadInfo(_prefab, _capacity, _preload, string.Empty);
        }

        /// <summary>
        /// 添加加载信息,带有组信息
        /// </summary>
        /// <param name="_prefab">对象预制体</param>
        /// <param name="_capacity">对象池容量</param>
        /// <param name="_preload">是否预加载</param>
        /// <param name="_group">组名</param>
        public void AddLoadInfo(GameObject _prefab, int _capacity, bool _preload, string _group)
        {
            if (_prefab == null || _prefab.Equals(null)) return;

            if (dic_poolInfo == null)
                dic_poolInfo = new Dictionary<GameObject, PoolInfo>();

            var info = dic_poolInfo.ContainsKey(_prefab) ? dic_poolInfo[_prefab] : new PoolInfo();

            info.Prefab = _prefab;
            info.Capacity = _capacity;
            info.Preload = _preload;
            info.Group = _group;

            dic_poolInfo[_prefab] = info;
        }

        /// <summary>
        /// 改变对象池的组
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        /// <param name="group">组名</param>
        public void ChangePoolGroup(string poolName, string group)
        {
            UnityObjectPool pool;
            if (TryGetPool(poolName, out pool))
                pool.group = group;
        }

        /// <summary>
        /// 改变对象池的组
        /// </summary>
        /// <param name="pool">对象池对象</param>
        /// <param name="group">组名</param>
        public void ChangePoolGroup(UnityObjectPool pool, string group)
        {
            if (pool == null)
            {
                Debug.LogError("Target Pool is Null.");
                return;
            }

            pool.@group = group;
        }

        /// <summary>
        /// 开始加载所有加载信息
        /// </summary>
        public void StartLoadAllInfos()
        {
            if (dic_poolInfo == null) return;
            var enumerator = dic_poolInfo.GetEnumerator();
            while (enumerator.MoveNext())
            {
                PoolInfo info = enumerator.Current.Value;
                StartLoad(info.Prefab, info.Capacity, info.Preload, info.Group);
            }

            enumerator.Dispose();

            dic_poolInfo.Clear();
            dic_poolInfo = null;
        }

        /// <summary>
        /// 释放所有对象池
        /// </summary>
        /// <param name="destroyAll">是否销毁从池中衍生出来的所有对象</param>
        public void ReleaseAllPools(bool destroyAll = true)
        {
            foreach (var item in dic_pool.Where(item => item.Value != null))
            {
                item.Value.DestroyPool(destroyAll);
            }

            dic_pool.Clear();
        }

        /// <summary>
        /// 释放默认组的对象池
        /// </summary>
        /// <param name="destroyAll">是否销毁从池中衍生出来的所有对象</param>
        public void ReleasePoolsByDefaultGroup(bool destroyAll = true)
        {
            ReleasePoolsByGroup(string.Empty, destroyAll);
        }

        /// <summary>
        /// 释放标记为某个组的对象池
        /// </summary>
        /// <param name="group">组名</param>
        /// <param name="destroyAll">是否销毁从池中衍生出来的所有对象</param>
        public void ReleasePoolsByGroup(string group, bool destroyAll = true)
        {
            if (group == null) return;
            var pools = dic_pool.ToList();
            foreach (var item in pools.Where(item => item.Value.@group.Equals(@group)))
            {
                item.Value.DestroyPool(destroyAll);
                dic_pool.Remove(item.Key);
            }
        }

        /// <summary>
        /// 加载对象池
        /// </summary>
        /// <param name="prefab">对象路径</param>
        /// <param name="capacity">容量</param>
        /// <param name="preload">是否预加载</param>
        /// <param name="group">组名</param>
        public UnityObjectPool StartLoad(GameObject prefab, int capacity, bool preload, string group = "")
        {
            if (prefab == null)
            {
                Debug.LogErrorFormat("创建对象池，加载对象失败！目标Prefab为Null");
                return null;
            }

            var poolName = prefab.name;

            UnityObjectPool pool;
            return TryGetPool(poolName, out pool) ? pool : CreatePool(poolName, prefab, capacity, preload, @group);
        }

        /// <summary>
        /// 创建一个Unity对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        /// <param name="prefab">预制体</param>
        /// <param name="capacity">容量</param>
        /// <param name="preload">是否预加载</param>
        /// <returns></returns>
        public UnityObjectPool CreatePool(string poolName, GameObject prefab, int capacity, bool preload)
        {
            return CreatePool(poolName, prefab, capacity, preload, string.Empty);
        }

        /// <summary>
        /// 创建一个Unity对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        /// <param name="prefab">预制体</param>
        /// <param name="capacity">容量</param>
        /// <param name="preload">是否预加载</param>
        /// <param name="group">组名</param>
        /// <returns></returns>
        public UnityObjectPool CreatePool(string poolName, GameObject prefab, int capacity, bool preload, string group)
        {
            var pool = UnityObjectPool.CreatePool(poolName, prefab, capacity, preload, group);
            AddPool(pool, group);
            pool.transform.SetParent(_parent);
            return pool;
        }

        /// <summary>
        /// 添加一个对象池到管理器, 可以自定义组标记
        /// </summary>
        /// <param name="pool">对象池</param>
        public void AddPool(UnityObjectPool pool)
        {
            AddPool(pool, string.Empty);
        }

        /// <summary>
        /// 添加一个对象池到管理器, 可以自定义组标记
        /// </summary>
        /// <param name="pool">对象池</param>
        /// <param name="group">组名</param>
        public void AddPool(UnityObjectPool pool, string group)
        {
            if (pool == null) return;
            if (!HasPool(pool.PoolName))
            {
                dic_pool.Add(pool.PoolName, pool);
                pool.transform.SetParent(_parent);
            }
            else
            {
                Debug.LogError(string.Format("\"{0}\"这个对象池名字已经存在了,请输入不重复的对象池名称", pool.PoolName), pool);
                return;
            }
        }

        /// <summary>
        /// 获取一个对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>    
        public UnityObjectPool GetPool(string poolName)
        {
            UnityObjectPool pool;
            if (!TryGetPool(poolName, out pool))
                Debug.LogWarningFormat("不存在这个对象池，请检查是否已经创建：{0}", poolName);
            return pool;
        }

        /// <summary>
        /// 尝试获取一个对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        /// <param name="pool">对象池</param>
        /// <returns></returns>
        public bool TryGetPool(string poolName, out UnityObjectPool pool)
        {
            return dic_pool.TryGetValue(poolName, out pool);
        }

        /// <summary>
        /// 判断对象池是否存在
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        /// <returns></returns>
        public bool HasPool(string poolName)
        {
            return dic_pool.ContainsKey(poolName);
        }

        /// <summary>
        /// 销毁一个对象池
        /// </summary>
        /// <param name="poolName">对象池名称</param>
        public bool DestroyPool(string poolName)
        {
            UnityObjectPool pool;
            return TryGetPool(poolName, out pool) && DestroyPool(pool);
        }

        /// <summary>
        /// 销毁一个对象池
        /// </summary>
        /// <param name="pool">对象池</param>
        /// <returns></returns>
        public bool DestroyPool(UnityObjectPool pool)
        {
            pool.DestroyPool();
            return RemovePool(pool.PoolName);
        }

        #endregion
    }
}