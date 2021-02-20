using System.Collections.Generic;
using KiwiFramework.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KiwiFramework.Core
{
    [RequireComponent(typeof(ViewDefine)), DisallowMultipleComponent]
    public abstract class ViewMonoBehaviour : MonoBehaviour, IUpdate, ILateUpdate
    {
        #region 内部字段

        [ShowInInspector, BoxGroup("内部字段", CenterLabel = true), ReadOnly, HideIf("@parentView == null")]
        [LabelText("父界面")]
        public BaseView parentView = null;

        [ShowInInspector, BoxGroup("内部字段"), ReadOnly, HideIf("@ChildViews.Count <= 0")] [LabelText("子界面")]
        protected readonly Dictionary<string, BaseView> ChildViews = new Dictionary<string, BaseView>();

        [ShowInInspector, BoxGroup("内部字段"), ReadOnly,
         InfoBox("界面设置不能为空", InfoMessageType.Error, VisibleIf = "@define == null")]
        [LabelText("界面设置")]
        public ViewDefine define = null;

        #endregion

        public bool ExecuteUpdate
        {
            get => define.ExecuteUpdate;
            set
            {
                define.ExecuteUpdate = value;
                if (value)
                    ViewManager.Instance.AddUpdate(this);
                else
                    ViewManager.Instance.RemoveUpdate(this);
            }
        }

        public virtual int UpdateOrder
        {
            get => define.UpdateOrder;
            set => define.UpdateOrder = value;
        }

        public bool ExecuteLateUpdate
        {
            get => define.ExecuteLateUpdate;
            set
            {
                define.ExecuteLateUpdate = value;
                if (value)
                    ViewManager.Instance.AddLateUpdate(this);
                else
                    ViewManager.Instance.RemoveLateUpdate(this);
            }
        }

        public virtual int LateUpdateOrder
        {
            get => define.LateUpdateOrder;
            set => define.LateUpdateOrder = value;
        }

        /*-----------------------------------------------------------------------------------*/

        #region View Lifecycle Methods

        protected virtual void OnAwake()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnLateUpdate()
        {
        }

        protected virtual void OnDestroyed()
        {
        }

        #endregion

        #region Unity Methods

        private void Awake()
        {
            define = GetComponent<ViewDefine>();

            if (ExecuteUpdate)
                ViewManager.Instance.AddUpdate(this);
            if (ExecuteLateUpdate)
                ViewManager.Instance.AddLateUpdate(this);

            OnAwake();
        }

        private void OnDestroy()
        {
            if (ExecuteUpdate && ViewManager.Instance)
                ViewManager.Instance.RemoveUpdate(this);
            if (ExecuteLateUpdate && ViewManager.Instance)
                ViewManager.Instance.RemoveLateUpdate(this);

            OnDestroyed();
        }

        #endregion

#if UNITY_EDITOR
        private void Reset()
        {
            define = GetComponent<ViewDefine>();
        }
#endif
    }
}