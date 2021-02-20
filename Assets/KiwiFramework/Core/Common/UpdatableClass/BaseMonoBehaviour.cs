using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 托管Manager执行Update的Mono基类
    /// </summary>
    public abstract class BaseMonoBehaviour : MonoBehaviour
    {
        protected virtual void OnAwake()
        {
        }

        protected virtual void OnDestroyed()
        {
        }

        private void Awake()
        {
            UpdateManager.Instance.Add(this);
            OnAwake();
        }


        private void OnDestroy()
        {
            if (UpdateManager.Instance)
                UpdateManager.Instance.Remove(this);
            OnDestroyed();
        }
    }
}