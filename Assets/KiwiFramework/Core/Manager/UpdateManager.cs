using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace KiwiFramework.Core
{
    /// <summary>
    /// Update管理器
    /// </summary>
    public class UpdateManager : MonoSingleton<UpdateManager>
    {
        #region Private Variables

        [TitleGroup("Update Runtime", "Centralized processing update object", TitleAlignments.Centered)]
        [ShowInInspector, LabelText("Update Pool")]
        [ListDrawerSettings(IsReadOnly = true, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        private readonly List<IUpdate> _updateStore = new List<IUpdate>();

        [ShowInInspector, LabelText("FixedUpdate Pool")]
        [ListDrawerSettings(IsReadOnly = true, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        private readonly List<IFixedUpdate> _fixedUpdateStore = new List<IFixedUpdate>();

        [ShowInInspector, LabelText("LateUpdate Pool")]
        [ListDrawerSettings(IsReadOnly = true, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        private readonly List<ILateUpdate> _lateUpdateStore = new List<ILateUpdate>();

        #endregion

        #region Unity Editor

#if UNITY_EDITOR
        protected virtual string Name { get; } = "[UpdateRuntime]";
        protected override void Awake()
        {
            base.Awake();
            this.name = Name;
        }
#endif

        #endregion

        #region Private Methods

        private void AddUpdate(IUpdate update)
        {
            if (_updateStore.Contains(update)) return;
            _updateStore.Add(update);
            _updateStore.Sort((x, y) => x.UpdateOrder.CompareTo(y.UpdateOrder));
        }


        private void RemoveUpdate(IUpdate update)
        {
            if (_updateStore.Contains(update))
                _updateStore.Remove(update);
        }

        private void AddFixedUpdate(IFixedUpdate fixedUpdate)
        {
            if (_fixedUpdateStore.Contains(fixedUpdate)) return;
            _fixedUpdateStore.Add(fixedUpdate);
            _fixedUpdateStore.Sort((x, y) => x.FixedUpdateOrder.CompareTo(y.FixedUpdateOrder));
        }

        private void RemoveFixedUpdate(IFixedUpdate fixedUpdate)
        {
            if (_fixedUpdateStore.Contains(fixedUpdate))
                _fixedUpdateStore.Remove(fixedUpdate);
        }

        private void AddLateUpdate(ILateUpdate lateUpdate)
        {
            if (_lateUpdateStore.Contains(lateUpdate)) return;
            _lateUpdateStore.Add(lateUpdate);
            _lateUpdateStore.Sort((x, y) => x.LateUpdateOrder.CompareTo(y.LateUpdateOrder));
        }

        private void RemoveLateUpdate(ILateUpdate lateUpdate)
        {
            if (_lateUpdateStore.Contains(lateUpdate))
                _lateUpdateStore.Remove(lateUpdate);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 向更新列表中添加对象
        /// </summary>
        /// <param name="obj">要添加的更新对象</param>
        /// <typeparam name="T">实现IUpdate,IFixedUpdate或ILateUpdate接口的对象</typeparam>
        public void Add<T>(T obj)
        {
            if (obj is IUpdate update)
                AddUpdate(update);

            if (obj is IFixedUpdate fixedUpdate)
                AddFixedUpdate(fixedUpdate);

            if (obj is ILateUpdate lateUpdate)
                AddLateUpdate(lateUpdate);
        }

        /// <summary>
        /// 从更新列表中移除对象
        /// </summary>
        /// <param name="obj">要移除的更新对象</param>
        /// <typeparam name="T"></typeparam>
        public void Remove<T>(T obj)
        {
            if (obj is IUpdate update)
                RemoveUpdate(update);

            if (obj is IFixedUpdate fixedUpdate)
                RemoveFixedUpdate(fixedUpdate);

            if (obj is ILateUpdate lateUpdate)
                RemoveLateUpdate(lateUpdate);
        }

        /// <summary>
        /// 是否存在此实例
        /// </summary>
        /// <param name="obj">要判断的更新对象</param>
        /// <returns></returns>
        public bool Exist<T>(T obj)
        {
            switch (obj)
            {
                case IUpdate update:
                    return _updateStore.Contains(update);
                case IFixedUpdate fixedUpdate:
                    return _fixedUpdateStore.Contains(fixedUpdate);
                case ILateUpdate lateUpdate:
                    return _lateUpdateStore.Contains(lateUpdate);
                default:
                    return false;
            }
        }

        #endregion

        #region Unity Methods

        private void Update()
        {
            if (_updateStore.Count == 0) return;

            foreach (var obj in _updateStore.Where(obj => obj != null))
                obj.OnUpdate();
        }

        private void FixedUpdate()
        {
            if (_fixedUpdateStore.Count == 0) return;

            foreach (var obj in _fixedUpdateStore.Where(obj => obj != null))
                obj.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            if (_lateUpdateStore.Count == 0) return;

            foreach (var obj in _lateUpdateStore.Where(obj => obj != null))
                obj.OnLateUpdate();
        }

        #endregion
    }
}