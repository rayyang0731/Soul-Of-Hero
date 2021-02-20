using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 取消面板组件
    /// </summary>
    [AddComponentMenu("KiwiUI/Component/CancelBoard")]
    [HideMonoScript, RequireComponent(typeof(Graphic))]
    public class UICancelBoard : UIComponentBase, ISelectHandler, IDeselectHandler
    {
        #region Private Variables

        /// <summary>
        /// 点击屏幕时,点击点是否在面板内
        /// </summary>
        [ShowInInspector, ReadOnly, LabelText("是否在面板内")]
        private bool _pointerInBoard;

        /// <summary>
        /// 子面板
        /// </summary>
        [ShowInInspector, ReadOnly, LabelText("子面板")]
        private List<GameObject> boardOfChildren = new List<GameObject>();

        /// <summary>
        /// 取消操作响应的事件
        /// </summary>
        [SerializeField] private Button.ButtonClickedEvent _onDeselectedEvent = new Button.ButtonClickedEvent();

        #endregion

        #region Public Methods

        /// <summary>
        /// 添加子面板
        /// </summary>
        /// <param name="child">要添加的子面板</param>
        public void AddChildBoard(GameObject child)
        {
            if (child == null)
                return;

            if (!boardOfChildren.Contains(child))
                boardOfChildren.Add(child);
        }

        /// <summary>
        /// 移除子面板
        /// </summary>
        /// <param name="child">要移除的子面板</param>
        public void RemoveChildBoard(GameObject child)
        {
            if (child == null)
                return;

            if (boardOfChildren.Contains(child))
                boardOfChildren.Remove(child);
        }

        /// <summary>
        /// 清除全部子面板
        /// </summary>
        public void ClearChildBoard()
        {
            boardOfChildren.Clear();
        }

        public void AddDeselectEvent(UnityAction deselectEvent)
        {
            if (deselectEvent != null)
                _onDeselectedEvent.AddListener(deselectEvent);
        }

        public void RemoveDeselectEvent(UnityAction deselectEvent)
        {
            if (deselectEvent != null)
                _onDeselectedEvent.RemoveListener(deselectEvent);
        }

        public void ClearDeselectEvent()
        {
            _onDeselectedEvent.RemoveAllListeners();
        }

        public void OnSelect(BaseEventData eventData)
        {
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (eventData is PointerEventData == false)
            {
                _pointerInBoard = true;
                return;
            }

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll((PointerEventData) eventData, raycastResults);
            foreach (var result in raycastResults)
            {
                if (result.gameObject.Equals(gameObject))
                {
                    _pointerInBoard = true;
                    return;
                }

                if (boardOfChildren == null || boardOfChildren.Count <= 0) continue;
                if (!boardOfChildren.Any(child => child.gameObject.Equals(result.gameObject))) continue;
                _pointerInBoard = true;
                return;
            }

            if (_onDeselectedEvent != null)
                _onDeselectedEvent.Invoke();

            _pointerInBoard = false;
        }

        /// <summary>
        /// 对象被选中
        /// </summary>
        public void Select()
        {
            if (EventSystem.current == null || EventSystem.current.alreadySelecting)
                return;
            _pointerInBoard = true;
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        #endregion

        #region Unity Methods

        protected override void OnEnable()
        {
            base.OnEnable();
            Select();
        }

        private void LateUpdate()
        {
            if (_pointerInBoard)
            {
                _pointerInBoard = false;
                Select();
            }
        }

        #endregion
    }
}