using System;
using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 计时器对象
    /// </summary>
    public sealed class Timer : IDisposable
    {
        public Timer()
        {
        }

        #region Private Variables

        /// <summary>
        /// 传入的参数
        /// </summary>
        private object[] _args;

        /// <summary>
        /// 是否已经释放过资源
        /// </summary>
        private bool _disposed = false;

        #region Unity Actions

        /// <summary>
        /// 计时开始时回调
        /// </summary>
        private Action<Timer> _onStart;

        /// <summary>
        /// 计时到设定时间回调
        /// </summary>
        private Action<Timer> _onCallback;

        /// <summary>
        /// 计时中回调
        /// </summary>
        private Action<Timer> _onUpdate;

        /// <summary>
        /// 计时器暂停回调
        /// </summary>
        private Action<Timer> _onPause;

        /// <summary>
        /// 计时器恢复回调
        /// </summary>
        private Action<Timer> _onResume;

        /// <summary>
        /// 计时结束回调
        /// </summary>
        private Action<Timer> _onStop;

        /// <summary>
        /// 计时取消回调
        /// </summary>
        private Action<Timer> _onCancel;

        #endregion

        #endregion
        
        #region Public Properties

        /// <summary>
        /// 计时器唯一标识符
        /// </summary>
        public string Guid { get; private set; }

        /// <summary>
        /// 总持续时间
        /// </summary>
        public float Duration { get; private set; }

        /// <summary>
        /// 计时器是否循环
        /// </summary>
        public bool Loop { get; private set; }

        /// <summary>
        /// 计时器是否暂停
        /// </summary>
        public bool IsPause { get; private set; }

        /// <summary>
        /// 计时器是否停止
        /// </summary>
        public bool IsStop
        {
            get { return !this.IsPause && this.RemainTime <= 0; }
        }

        /// <summary>
        /// 计时器是否忽略时间缩放
        /// </summary>
        public bool IgnoreTimeScale { get; private set; }

        /// <summary>
        /// 回调频率
        /// </summary>
        public float CallbackFrequency { get; private set; }

        /// <summary>
        /// 已用时间
        /// </summary>
        public float ElapsedTime
        {
            get { return this.Duration - this.RemainTime; }
        }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public float RemainTime { get; private set; }

        /// <summary>
        /// 计时器已经完成的百分比
        /// </summary>
        public float Ratio
        {
            get { return 1 - this.RemainTime / this.Duration; }
        }

        /// <summary>
        /// 下次回调时间
        /// </summary>
        public float NextCallbackTime { get; private set; }

        /// <summary>
        /// 开始次数
        /// </summary>
        /// <returns></returns>
        public int StartCount { get; private set; }

        /// <summary>
        /// 结束次数
        /// </summary>
        /// <returns></returns>
        public int FinishCount { get; private set; }

        #endregion

        #region Static Methods

        /// <summary>
        /// (私有方法)启动计时器
        /// </summary>
        /// <param name="duration">持续时间</param>
        /// <param name="onCallback">计时到设定时间回调</param>
        /// <param name="callFrequency">回调频率</param>
        /// <param name="loop">是否循环</param>
        /// <param name="ignoreTimeScale">是否忽略 TimeScale</param>
        private static Timer _startup(float duration, Action<Timer> onCallback, float callFrequency = 0f,
            bool loop = false, bool ignoreTimeScale = false)
        {
            if (onCallback != null)
            {
                var timer = Timer.Create(duration, onCallback, callFrequency, loop, ignoreTimeScale);
                timer.Startup();
                return timer;
            }
            else
                throw new Exception("启动计时器失败,回调方法不能为Null");
        }

        /// <summary>
        /// 创建一个Timer
        /// </summary>
        public static Timer Create(float duration, Action<Timer> callback, float callFrequency = 0f, bool loop = false,
            bool ignoreTimeScale = false)
        {
            if (callback != null)
            {
                var timer = TimerManager.Instance.Get();

                timer.Guid = GUIDHelper.Get();
                timer.Duration = duration;
                timer._onCallback = callback;
                timer.CallbackFrequency = callFrequency;
                timer.Loop = loop;
                timer.IgnoreTimeScale = ignoreTimeScale;

                timer.ResetRunVariable();

                return timer;
            }
            else
            {
                Debug.LogError("创建计时器失败,回调方法不能为Null");
                return null;
            }
        }

        /// <summary>
        /// 启动计时器
        /// </summary>
        /// <param name="duration">持续时间</param>
        /// <param name="onCallback">计时到设定时间回调</param>
        /// <param name="callFrequency">回调频率</param>
        /// <param name="loop">是否循环</param>
        /// <param name="ignoreTimeScale">是否忽略 TimeScale</param>
        public static Timer Startup(float duration, Action<Timer> onCallback, float callFrequency = 0f,
            bool loop = false, bool ignoreTimeScale = false)
        {
            return _startup(duration, onCallback, callFrequency, loop, ignoreTimeScale);
        }

        /// <summary>
        /// 启动计时器
        /// </summary>
        /// <param name="duration">持续时间</param>
        /// <param name="onCallback">计时到设定时间回调</param>
        /// <param name="guid">计时器唯一标识符</param>
        /// <param name="callFrequency">回调频率</param>
        /// <param name="loop">是否循环</param>
        /// <param name="ignoreTimeScale">是否忽略 TimeScale</param>
        public static Timer Startup(float duration, Action<Timer> onCallback, out string guid, float callFrequency = 0f,
            bool loop = false, bool ignoreTimeScale = false)
        {
            var timer = _startup(duration, onCallback, callFrequency, loop, ignoreTimeScale);
            if (timer != null)
                guid = timer.Guid;
            else
                throw new Exception("启动计时器失败,要启动的计时器为 Null");
            return timer;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 初始运行变量
        /// </summary>
        private void ResetRunVariable()
        {
            this.IsPause = true;
            this.RemainTime = 0f;
            this.NextCallbackTime = 0f;
        }

        /// <summary>
        /// 初始运行变量
        /// </summary>
        private void InitTick()
        {
            this.IsPause = false;
            this.RemainTime = this.Duration;
            this.StartCount++;

            if (this.CallbackFrequency > 0)
                this.NextCallbackTime = this.RemainTime - this.CallbackFrequency;
        }

        /// <summary>
        /// 重置并回收计时器
        /// </summary>
        private void ResetAndRecycle()
        {
            this.ResetRunVariable();
            ClearAllEvent();
            TimerManager.Instance.RemoveTimer(this);
        }

        /// <summary>
        /// 清理全部事件
        /// </summary>
        private void ClearAllEvent()
        {
            _onStart = null;
            _onCallback = null;
            _onUpdate = null;
            _onPause = null;
            _onResume = null;
            _onStop = null;
            _onCancel = null;
        }

        private void Close()
        {
            if (this._disposed) return;
            Guid = string.Empty;
            Duration = 0;
            Loop = false;
            CallbackFrequency = 0;
            _onStart = null;
            _onCallback = null;
            _onUpdate = null;
            _onPause = null;
            _onResume = null;
            _onStop = null;
            _onCancel = null;
            IgnoreTimeScale = false;
            IsPause = false;
            RemainTime = 0;
            NextCallbackTime = 0;
            StartCount = 0;
            FinishCount = 0;
            _args = null;

            this._disposed = true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 启动计时器
        /// </summary>
        public void Startup()
        {
            //表示未在计时
            if (this.RemainTime <= 0)
                Restart();
        }

        /// <summary>
        /// 无论是否正在计时，马上重新开始
        /// </summary>
        public void Restart()
        {
            this.InitTick();

            TimerManager.Instance.AddTimer(this);

            if (_onStart != null)
                _onStart.Invoke(this);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            if (this.IsPause) return;

            this.IsPause = true;

            if (_onPause != null)
                _onPause.Invoke(this);
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Resume()
        {
            if (!this.IsPause) return;

            this.IsPause = false;

            if (_onResume != null)
                _onResume.Invoke(this);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_onStop != null)
                _onStop.Invoke(this);

            ResetAndRecycle();
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            if (_onCancel != null)
                _onCancel.Invoke(this);

            ResetAndRecycle();
        }

        public void Tick(float deltaTime)
        {
            if (IsPause) return;

            this.RemainTime -= deltaTime;
            if (this.RemainTime <= this.NextCallbackTime)
            {
                _onCallback.Invoke(this);
                if (RemainTime <= 0f)
                {
                    if (Loop)
                    {
                        this.InitTick();
                    }
                    else
                    {
                        this.Stop();
                    }

                    this.FinishCount++;
                    return;
                }

                if (this.CallbackFrequency > 0)
                {
                    this.NextCallbackTime -= this.CallbackFrequency;
                    if (this.NextCallbackTime < 0)
                    {
                        this.NextCallbackTime = 0f;
                    }
                }
                else
                {
                    this.NextCallbackTime = 0f;
                }
            }
            else if (_onUpdate != null)
            {
                _onUpdate.Invoke(this);
            }
        }

        /// <summary>
        /// 添加计时开始回调
        /// </summary>
        public Timer AddStartCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onStart += callback;

            return this;
        }

        public Timer RemoveStartCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onStart -= callback;

            return this;
        }

        /// <summary>
        /// 添加计时到设定时间回调
        /// </summary>
        public Timer AddCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onCallback += callback;

            return this;
        }

        /// <summary>
        /// 移除计时到设定时间回调
        /// </summary>
        public Timer RemoveCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onCallback -= callback;

            return this;
        }

        /// <summary>
        /// 添加计时中回调
        /// </summary>
        public Timer AddUpdateCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onUpdate += callback;

            return this;
        }

        /// <summary>
        /// 移除计时中回调
        /// </summary>
        public Timer RemoveUpdateCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onUpdate -= callback;

            return this;
        }

        /// <summary>
        /// 添加暂停回调
        /// </summary>
        public Timer AddPauseCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onPause += callback;

            return this;
        }

        /// <summary>
        /// 移除暂停回调
        /// </summary>
        public Timer RemovePauseCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onPause -= callback;

            return this;
        }

        /// <summary>
        /// 添加恢复计时回调
        /// </summary>
        public Timer AddResumeCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onResume += callback;

            return this;
        }

        /// <summary>
        /// 移除恢复计时回调
        /// </summary>
        public Timer RemoveResumeCallback(Action<Timer> callback)
        {
            if (callback != null)
                _onResume -= callback;

            return this;
        }

        /// <summary>
        /// 添加结束回调
        /// </summary>
        public Timer AddStopCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onStop += callback;

            return this;
        }

        /// <summary>
        /// 移除计时中回调
        /// </summary>
        public Timer RemoveStopCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onStop -= callback;

            return this;
        }

        /// <summary>
        /// 添加取消回调
        /// </summary>
        public Timer AddCancelCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onCancel += callback;

            return this;
        }

        /// <summary>
        /// 移除取消回调
        /// </summary>
        public Timer RemoveCancelCallback(Action<Timer> callback)
        {
            if (callback != null)
                this._onCancel -= callback;

            return this;
        }

        /// <summary>
        /// 设置持续时间
        /// </summary>
        public Timer SetDuration(float duration)
        {
            if (duration > 0)
            {
                this.Duration = duration;
            }

            return this;
        }

        /// <summary>
        /// 设置是否循环
        /// </summary>
        public Timer SetLoop(bool loop)
        {
            this.Loop = loop;
            return this;
        }

        /// <summary>
        /// 设置回调频率
        /// </summary>
        public Timer SetCallbackFrequency(float callbackFrequency)
        {
            this.CallbackFrequency = callbackFrequency > 0 ? callbackFrequency : 0;
            return this;
        }

        /// <summary>
        /// 设置参数对象，会覆盖原有对象
        /// </summary>
        public Timer SetParams(params object[] objs)
        {
            this._args = objs;
            return this;
        }

        /// <summary>
        /// 获取参数对象
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="index">参数索引</param>
        public T GetParam<T>(int index)
        {
            if (this._args != null && index < this._args.Length)
                return (T) this._args[index];
            return default(T);
        }

        /// <summary>
        /// 获取参数对象,默认获取第0个参数
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        public T GetParam<T>()
        {
            return GetParam<T>(0);
        }

        /// <summary>
        /// 清理所有正在使用的资源
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}