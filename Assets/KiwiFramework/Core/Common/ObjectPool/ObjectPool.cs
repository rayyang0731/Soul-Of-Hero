using System;
using System.Collections.Generic;
using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T">缓存对象类型</typeparam>
    [Serializable]
    public class ObjectPool<T> where T : class, new()
    {
        #region Private Variables

        /// <summary>
        /// 缓存最大数量
        /// </summary>
        private int mMaxSize;

        /// <summary>
        /// 缓存队列
        /// </summary>
        private Queue<T> mCacheQueue;

        /// <summary>
        /// 由池衍生出来的全部对象
        /// </summary>
        [SerializeField]
        private List<T> mAllObjStore;

        #endregion

        #region Delegate

        /// <summary>
        /// 创建对象委托,对象池将会使用此委托创建对象,此委托不能为Null
        /// </summary>
        private Func<T> onCreate;

        /// <summary>
        /// 销毁对象委托,对象池将会使用此委托销毁对象,此委托不能为Null
        /// </summary>
        private Action<T> onDestroy;

        /// <summary>
        /// 激活对象委托,对象池将会使用此委托激活对象
        /// </summary>
        public Action<T> onActive;

        /// <summary>
        /// 取消激活对象委托,对象池将会使用此委托取消激活对象
        /// </summary>
        public Action<T> onInactive;

        #endregion

        #region public Properties

        /// <summary>
        /// 返回缓存池中剩余对象的数量
        /// </summary>
        public int Count
        {
            get { return mCacheQueue.Count; }
        }

        /// <summary>
        /// 缓存池最大容量
        /// </summary>
        public int MaxSize
        {
            get { return mMaxSize; }
            set { mMaxSize = value; }
        }

        public List<T> AllObjs
        {
            get { return mAllObjStore; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 创建一个对象池
        /// </summary>
        /// <param name="capacity">对象池容量</param>
        /// <param name="onCreate">创建对象委托方法,这个参数不能为Null</param>
        /// <param name="onDestroy">销毁对象委托方法,这个参数不能为Null</param>
        public ObjectPool(int capacity, Func<T> onCreate, Action<T> onDestroy)
        {
            if (onCreate == null || onDestroy == null)
                throw new Exception("缓存池的创建对象委托与销毁对象委托不能为null.");
            if (capacity < 1)
                throw new Exception("缓存池目标容量小于1.");

            this.mMaxSize = capacity;
            this.mCacheQueue = new Queue<T>(mMaxSize);
            this.mAllObjStore = new List<T>();
            this.onCreate = onCreate;
            this.onDestroy = onDestroy;
        }

        /// <summary>
        /// 创建一个对象池
        /// </summary>
        /// <param name="capacity">对象池容量</param>
        /// <param name="onCreate">创建对象委托方法,这个参数不能为Null</param>
        /// <param name="onDestroy">销毁对象委托方法,这个参数不能为Null</param>
        /// <param name="onActive">激活对象委托方法</param>
        /// <param name="onInactive">取消激活对象委托方法</param>
        public ObjectPool(int capacity, Func<T> onCreate, Action<T> onDestroy,
            Action<T> onActive, Action<T> onInactive) :
            this(capacity, onCreate, onDestroy)
        {
            this.onActive = onActive;
            this.onInactive = onInactive;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 从对象池中获取一个缓存对象,如果池中没有对象,将使用创建方法创建一个对象
        /// </summary>
        public T Get()
        {
            T obj = null;

            if (mCacheQueue.Count > 0)
                obj = mCacheQueue.Dequeue();

            if (obj == null)
                obj = onCreate.Invoke();

            if (obj == null)
                throw new Exception("创建对象失败");

            this.mAllObjStore.Add(obj);

            if (onActive != null)
                onActive.Invoke(obj);

            return obj;
        }

        /// <summary>
        /// 缓存对象,对象池满时将会使用销毁方法销毁对象
        /// </summary>
        public bool Recycle(T obj)
        {
            //保证鲁棒性
            if (obj == null || mCacheQueue.Contains(obj))
                return false;

            if (onInactive != null)
                onInactive.Invoke(obj);

            if (mCacheQueue.Count < mMaxSize)
            {
                mCacheQueue.Enqueue(obj);
                return true;
            }

            this.mAllObjStore.Remove(obj);
            if (onDestroy != null)
                onDestroy.Invoke(obj);
            return true;
        }

        /// <summary>
        /// 清空对象池,清空并销毁对象池中的对象
        /// </summary>
        /// <param name="destroyAll">是否销毁从池中衍生出来的所有对象</param>
        public void Clear(bool destroyAll = true)
        {
            while (mCacheQueue.Count > 0)
            {
                onDestroy.Invoke(mCacheQueue.Dequeue());
            }

            if (destroyAll)
            {
                this.mAllObjStore.ForEach((obj) =>
                {
                    if (obj != null && !obj.Equals(null))
                    {
                        onDestroy.Invoke(obj);
                    }
                });
            }
        }

        /// <summary>
        /// 预加载对象池,预先填满对象池
        /// </summary>
        public bool Preload()
        {
            return Preload(mMaxSize);
        }

        /// <summary>
        /// 预加载对象池,预先填满对象池
        /// </summary>
        /// <param name="number">预加载数量</param>
        public bool Preload(int number)
        {
            if (number > mCacheQueue.Count && number <= mMaxSize)
            {
                int preloadNum = number - mCacheQueue.Count;

                for (int i = 0; i < preloadNum; i++)
                {
                    T obj = onCreate.Invoke();
                    if (obj == null)
                        throw new Exception("创建对象失败");
                    if (onInactive != null)
                        onInactive.Invoke(obj);
                    mCacheQueue.Enqueue(obj);

                    this.mAllObjStore.Add(obj);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 返回缓存池中是否存在这个对象
        /// </summary>
        public bool Contains(T obj)
        {
            return mCacheQueue.Contains(obj);
        }

        #endregion
    }
}