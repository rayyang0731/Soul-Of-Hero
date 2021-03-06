using System;
using System.Collections.Generic;
using System.Linq;
using KiwiFramework.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace KiwiFramework.Core
{
    [HideMonoScript]
    public sealed class ViewManager : MonoSingleton<ViewManager>
    {
        #region Public Variables

        /// <summary>
        /// UI 主 Canvas
        /// </summary>
        public Canvas mainCanvas;

        public const int NormalCanvasSortOrder = 0;
        public const int ForwardCanvasSortOrder = 100;
        public const int TopCanvasSortOrder = 200;

        #endregion

        #region Private Variables

        [BoxGroup("View Update Runtime", CenterLabel = true)]
        [ShowInInspector, LabelText("Update Pool")]
        [ListDrawerSettings(IsReadOnly = true, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        private readonly List<IUpdate> _updateStore = new List<IUpdate>();

        [BoxGroup("View Update Runtime")]
        [ShowInInspector, LabelText("LateUpdate Pool")]
        [ListDrawerSettings(IsReadOnly = true, DraggableItems = false, HideAddButton = true, HideRemoveButton = true)]
        private readonly List<ILateUpdate> _lateUpdateStore = new List<ILateUpdate>();

        /// <summary>
        /// 全部界面(key:界面名称 value:界面对象)
        /// </summary>
        [ShowInInspector, LabelText("全部界面")]
        private readonly Dictionary<string, BaseView> _allViewMap = new Dictionary<string, BaseView>();

        /// <summary>
        /// 界面回退栈
        /// </summary>
        [ShowInInspector, LabelText("界面回退栈")] private readonly Stack<string> _stackRollback = new Stack<string>();

        /// <summary>
        /// 底层 Canvas
        /// </summary>
        private Canvas _normalCanvas;

        private CanvasGroup _normalCanvasGroup;

        /// <summary>
        /// 上层 Canvas
        /// </summary>
        private Canvas _forwardCanvas;

        private CanvasGroup _forwardCanvasGroup;

        /// <summary>
        /// 顶层 Canvas
        /// </summary>
        private Canvas _topCanvas;

        private CanvasGroup _topCanvasGroup;

        #endregion

        #region Private Methods

        /// <summary>
        /// 尝试获得 UI 主 Canvas
        /// </summary>
        private void TryToGetMainCanvas()
        {
            if (mainCanvas != null && !mainCanvas.Equals(null)) return;

            var mainCanvasGo = GameObject.FindWithTag("MainCanvas");

            if (mainCanvasGo == null)
            {
                var mainCanvasPrefab = Resources.Load<GameObject>("UI/MainCanvas");
                mainCanvasGo = Instantiate(mainCanvasPrefab, Vector3.one, Quaternion.identity);
                mainCanvasGo.name = "MainCanvas";
                DontDestroyOnLoad(mainCanvasGo);
            }

            mainCanvas = mainCanvasGo.GetComponent<Canvas>();
        }

        /// <summary>
        /// 尝试获得 UI 子 Canvas
        /// </summary>
        private void TryToGetSubCanvas()
        {
            if (mainCanvas == null || mainCanvas.Equals(null))
                return;

            if (_normalCanvas == null || _normalCanvas.Equals(null))
            {
                _normalCanvas = mainCanvas.transform.Find("Normal").GetComponent<Canvas>();
                _normalCanvasGroup = _normalCanvas.GetComponent<CanvasGroup>();
                _normalCanvas.sortingOrder = NormalCanvasSortOrder;
            }

            if (_forwardCanvas == null || _forwardCanvas.Equals(null))
            {
                _forwardCanvas = mainCanvas.transform.Find("Forward").GetComponent<Canvas>();
                _forwardCanvasGroup = _forwardCanvas.GetComponent<CanvasGroup>();
                _forwardCanvas.sortingOrder = ForwardCanvasSortOrder;
            }

            if (_topCanvas == null || _topCanvas.Equals(null))
            {
                _topCanvas = mainCanvas.transform.Find("Top").GetComponent<Canvas>();
                _topCanvasGroup = _topCanvas.GetComponent<CanvasGroup>();
                _topCanvas.sortingOrder = TopCanvasSortOrder;
            }
        }

        /// <summary>
        /// 尝试压入回退栈
        /// </summary>
        /// <param name="viewName">界面名称</param>
        private void TryToPushInRollbackStack(string viewName)
        {
            var lastViewName = string.Empty;
            if (_stackRollback.Count > 0)
            {
                lastViewName = _stackRollback.Peek();
                if (lastViewName == viewName) return;
            }

            if (!string.IsNullOrEmpty(lastViewName))
                CloseView(lastViewName);

            _stackRollback.Push(viewName);
        }

        /// <summary>
        /// 尝试回退到栈顶的界面
        /// </summary>
        /// <param name="viewName">当前被关闭的界面名称</param>
        private void TryToPopUpRollbackStack(string viewName)
        {
            var view = _allViewMap[viewName];
            var stackViewName = string.Empty;
            if (_stackRollback.Count > 0)
            {
                stackViewName = _stackRollback.Peek();
                if (stackViewName != viewName)
                {
                    var wannaRollBackViewName = _stackRollback.Pop();
                    if (wannaRollBackViewName != null)
                        OpenView(wannaRollBackViewName);
                }
                else
                {
                    view.Resume();
                }
            }

            if (stackViewName != viewName)
                InternalCloseView(viewName);
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="viewName">要关闭的界面名称</param>
        private void InternalCloseView(string viewName)
        {
            var view = _allViewMap[viewName];
            _allViewMap.Remove(viewName);
            view.Close();
            Destroy(view.gameObject);
        }

        /// <summary>
        /// 根据层级排序值获得子 Canvas
        /// </summary>
        /// <param name="sortLayer">界面层级排序值</param>
        /// <returns></returns>
        private Canvas GetSubCanvas(int sortLayer)
        {
            if (sortLayer >= _topCanvas.sortingOrder)
                return _topCanvas;
            if (sortLayer >= _forwardCanvas.sortingOrder)
                return _forwardCanvas;

            return _normalCanvas;
        }

        /// <summary>
        /// 控制子 Canvas 的显隐,如果 Canvas 下没有界面,则关闭子 Canvas 的渲染和响应,反之则打开
        /// </summary>
        private void ControlSubCanvasDisplay()
        {
            ControlSubCanvasDisplay(_normalCanvasGroup, _normalCanvas.transform.childCount > 0);
            ControlSubCanvasDisplay(_forwardCanvasGroup, _forwardCanvas.transform.childCount > 0);
            ControlSubCanvasDisplay(_topCanvasGroup, _topCanvas.transform.childCount > 0);
        }

        private void ControlSubCanvasDisplay(CanvasGroup canvasGroup, bool display)
        {
            var alpha = display ? 1 : 0;
            if (Math.Abs(alpha - canvasGroup.alpha) > 0.00001f)
                canvasGroup.alpha = alpha;

            if (display != canvasGroup.interactable)
                canvasGroup.interactable = display;

            if (display != canvasGroup.blocksRaycasts)
                canvasGroup.blocksRaycasts = display;
        }

        #endregion

        #region Public Methods

        internal void AddUpdate(IUpdate update)
        {
            if (_updateStore.Contains(update)) return;
            _updateStore.Add(update);
            if (update.UpdateOrder > 0)
                _updateStore.Sort((x, y) => x.UpdateOrder.CompareTo(y.UpdateOrder));
        }

        internal void RemoveUpdate(IUpdate update)
        {
            if (_updateStore.Contains(update))
                _updateStore.Remove(update);
        }

        internal void AddLateUpdate(ILateUpdate lateUpdate)
        {
            if (_lateUpdateStore.Contains(lateUpdate)) return;
            _lateUpdateStore.Add(lateUpdate);
            if (lateUpdate.LateUpdateOrder > 0)
                _lateUpdateStore.Sort((x, y) => x.LateUpdateOrder.CompareTo(y.LateUpdateOrder));
        }

        internal void RemoveLateUpdate(ILateUpdate lateUpdate)
        {
            if (_lateUpdateStore.Contains(lateUpdate))
                _lateUpdateStore.Remove(lateUpdate);
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
                case ILateUpdate lateUpdate:
                    return _lateUpdateStore.Contains(lateUpdate);
                default:
                    return false;
            }
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="viewName">界面名称</param>
        /// <param name="viewAlias">界面别名</param>
        /// <returns>被打开的界面对象</returns>
        public BaseView OpenView(string viewName, string viewAlias = null)
        {
            if (viewAlias == null)
                viewAlias = viewName;

            if (_allViewMap.TryGetValue(viewAlias, out var view))
            {
                view.Resume();
                return view;
            }

            var viewGo = AssetManager.Instance.Load<GameObject>(viewAlias);
            var viewDefine = viewGo.GetComponent<ViewDefine>();

            viewGo = Instantiate(viewGo, GetSubCanvas(viewDefine.SortLayer).rectTransform());
            viewGo.name = viewAlias;
            view = viewGo.ForceGetComponent(viewName) as BaseView;

            _allViewMap.Add(viewAlias, view);

            if (view != null && view.define.ViewLogicType != VIEW_LOGIC_TYPE.ROLLBACK) return view;

            TryToPushInRollbackStack(viewAlias);

            ControlSubCanvasDisplay();

            return view;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="viewName">界面名称</param>
        public void CloseView(string viewName)
        {
            if (!_allViewMap.ContainsKey(viewName))
            {
                KiwiLog.ErrorFormat("[{0}]界面并没有被打开过,无法执行关闭操作", viewName);
                return;
            }

            var view = _allViewMap[viewName];
            var viewLogicType = view.define.ViewLogicType;

            if (viewLogicType == VIEW_LOGIC_TYPE.ROLLBACK)
                TryToPopUpRollbackStack(viewName);
            else
                InternalCloseView(viewName);

            ControlSubCanvasDisplay();
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
#if UNITY_EDITOR
            name = "[ViewManager]";
#endif
            TryToGetMainCanvas();
            TryToGetSubCanvas();
        }

        private void Update()
        {
            if (_updateStore.Count == 0) return;

            foreach (var obj in _updateStore.Where(obj => obj != null))
                obj.OnUpdate();
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