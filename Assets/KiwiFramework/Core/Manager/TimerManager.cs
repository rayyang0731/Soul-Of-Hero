using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 计时器管理器
    /// </summary>
    public class TimerManager : Singleton<TimerManager>, IUpdate
    {
        /// <summary>
        /// 对象池容量
        /// </summary>
        private const int PoolCapacity = 10;

        #region Private Variables

        /// <summary>
        /// 计时器池
        /// </summary>
        private readonly ObjectPool<Timer> _timerPool;

        /// <summary>
        /// 正在使用的计时器
        /// </summary>
        private readonly List<Timer> _timers;

        /// <summary>
        /// 要移除的计时器
        /// </summary>
        private readonly List<Timer> _removes;

        /// <summary>
        /// 计时器管理器虚拟体
        /// </summary>
        private readonly GameObject _timeMgrVirtual;

        #endregion

        #region Public Properties

        /// <summary>
        /// Update队列排序
        /// </summary>
        public int UpdateOrder
        {
            get { return 0; }
        }

        #endregion

        #region Constructor

        protected TimerManager()
        {
            this._timerPool = new ObjectPool<Timer>(PoolCapacity, CreateTimer, DestroyTimer);

            this._timers = new List<Timer>();
            this._removes = new List<Timer>();

#if UNITY_EDITOR
            _timeMgrVirtual = new GameObject("[TimerRuntime (0)|Pool (0/0)]");
            Object.DontDestroyOnLoad(_timeMgrVirtual);
#endif

            UpdateManager.Instance.Add(this);
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// 删除计时器
        /// </summary>
        /// <param name="obj">要删除的计时器</param>
        private static void DestroyTimer(Timer obj)
        {
            obj.Dispose();
        }

        /// <summary>
        /// 创建计时器
        /// </summary>
        /// <returns></returns>
        private static Timer CreateTimer()
        {
            return new Timer();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 添加计时器
        /// </summary>
        /// <param name="timer">计时器</param>
        public void AddTimer(Timer timer)
        {
            if (!_timers.Contains(timer))
            {
                _timers.Add(timer);
#if UNITY_EDITOR
                UpdateRuntimeTimerCount();
#endif
            }
        }

        /// <summary>
        /// 移除计时器
        /// </summary>
        /// <param name="timer">计时器</param>
        public void RemoveTimer(Timer timer)
        {
            if (_timers.Contains(timer))
            {
                _removes.Add(timer);
            }

            Recycle(timer);
        }

        /// <summary>
        /// 获得计时器
        /// </summary>
        /// <param name="guid">计时器唯一标识符</param>
        /// <returns></returns>
        public Timer GetTimer(string guid)
        {
            return _timers.Find((t) => t.Guid == guid);
        }

        /// <summary>
        /// 是否包含这个计时器
        /// </summary>
        /// <param name="guid">计时器唯一标识符</param>
        /// <returns></returns>
        public bool ExistTimer(string guid)
        {
            return _timers.Exists((t) => t.Guid == guid);
        }

        /// <summary>
        /// 从池中获得一个计时器
        /// </summary>
        /// <returns></returns>
        public Timer Get()
        {
            return _timerPool.Get();
        }

        /// <summary>
        /// 回收计时器
        /// </summary>
        /// <param name="timer">要回收的计时器对象</param>
        /// <returns></returns>
        public bool Recycle(Timer timer)
        {
            return _timerPool.Recycle(timer);
        }

        public void OnUpdate()
        {
            if (_timers.Count > 0)
            {
                for (int i = 0, y = _timers.Count; i < y; ++i)
                {
                    Timer timer = _timers[i];

                    if (!timer.IsPause)
                    {
                        timer.Tick(timer.IgnoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime);
                    }
                }

                //移除已经停止的Timer
                if (_removes.Count > 0)
                {
                    for (int i = 0, y = _removes.Count; i < y; i++)
                    {
                        _timers.Remove(_removes[i]);
                    }

                    _removes.Clear();
#if UNITY_EDITOR
                    UpdateRuntimeTimerCount();
#endif
                }
            }
        }

        #endregion


#if UNITY_EDITOR
        /// <summary>
        /// 显示计时器数量
        /// </summary>
        private void UpdateRuntimeTimerCount()
        {
            _timeMgrVirtual.name = string.Format("[TimerRuntime ({0})|Pool ({1}/{2})]", _timers.Count.ToString(),
                _timerPool.Count, PoolCapacity);
        }
#endif
    }
}