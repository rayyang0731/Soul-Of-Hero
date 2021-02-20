using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// UnityObjectPool 对象池标记
    /// </summary>
    [HideMonoScript]
    public class UnityObjectPoolSign : BaseMonoBehaviour
    {
        #region Private Variables

        /// <summary>
        /// 所属对象池
        /// </summary>
        [SerializeField, DisableInPlayMode] [LabelText("所属对象池")]
        private UnityObjectPool pool;

        /// <summary>
        /// 计时器GUID
        /// </summary>
        [SerializeField, DisableInPlayMode] [LabelText("计时器GUID"), HideIf("@string.IsNullOrEmpty(timerGuid)")]
        private string timerGuid;

        #endregion

        #region Private Methods

        /// <summary>
        /// 释放计时器
        /// </summary>
        private void ReleaseTimer()
        {
            if (TimerManager.Instance.ExistTimer(timerGuid))
            {
                Timer timer = TimerManager.Instance.GetTimer(timerGuid);
                timer.Stop();
            }
        }

        /// <summary>
        /// 释放这个对象
        /// </summary>
        private void Release()
        {
            pool = null;
            Destroy(this);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 签署这个对象
        /// </summary>
        public void Sign(UnityObjectPool _pool)
        {
            this.pool = _pool;
        }

        /// <summary>
        /// 让对象池回收这个对象
        /// </summary>
        public void Recycle()
        {
            ReleaseTimer();
            if (pool == null || !pool.Recycle(this.gameObject))
                DestroySignObject();
        }

        /// <summary>
        /// 延迟让对象池回收这个对象
        /// </summary>
        /// <param name="delay">延迟时间</param>
        public void RecycleDelay(float delay)
        {
            if (pool != null)
                Timer.Startup(delay, (t) => Recycle(), out timerGuid);
        }

        /// <summary>
        /// 销毁掉这个签署的对象
        /// </summary>
        public void DestroySignObject()
        {
            Release();
            if (this.transform.parent != null)
                this.transform.SetParent(null);
            Destroy(this.gameObject);
        }

        #endregion

        #region Unity Methods

        /// <summary>
        /// 对象正在销毁
        /// </summary>
        protected override void OnDestroyed()
        {
            ReleaseTimer();
            if (pool != null)
            {
                Debug.LogWarningFormat(
                    "有被对象池签署标记的对象没按正常流程销毁，销毁对象名称：{0}，PoolName: {1}",
                    gameObject.name, pool.PoolName);
                pool = null;
            }
        }

        #endregion
    }
}