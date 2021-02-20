using System;
using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace KiwiFramework.UI
{
    public class UIDrag : UITransparentGraphic, IPointerUpHandler, IPointerDownHandler, IDragHandler, ISelectHandler
    {
        #region Editor

#if UNITY_EDITOR

#endif

        #endregion

        #region Private Variables

        /// <summary>
        /// 拖拽是否可用
        /// </summary>
        private bool _interactable = true;

        /// <summary>
        /// 是否可以水平拖拽
        /// </summary>
        private bool _canHorizontal = true;

        /// <summary>
        /// 是否可以垂直拖拽
        /// </summary>
        private bool _canVertical = true;

        /// <summary>
        /// 是否按住拖拽物
        /// </summary>
        private bool _hisOnDragObj = false;

        /// <summary>
        /// 是否控制拖拽范围
        /// </summary>
        private bool _canOutOfArea = true;

        /// <summary>
        /// 拖拽对象
        /// </summary>
        private RectTransform _dragObj;

        /// <summary>
        /// 点击按下位置
        /// </summary>
        private Vector2 _pointerDownPos;

        /// <summary>
        /// 点击按下时拖拽对象位置
        /// </summary>
        private Vector2 _objDownPos;

        /// <summary>
        /// 是否正在拖拽中
        /// </summary>
        private bool _isDraging = false;

        /// <summary>
        /// 拖拽物极限范围(x-left,y,-top,z-right,w-bottom)
        /// </summary>
        private Vector4 _maxminArea;

        #endregion

        #region Public Variables

        /// <summary>
        /// 是否需要按在拖拽物上才可以拖动
        /// </summary>
        [LabelText("需要按住拖拽物")]
        public bool needHitObj = false;

        /// <summary>
        /// 点击事件
        /// </summary>
        public DragClickedEvent onDragClickedEvent = null;

        #endregion

        #region Private Properties

        #endregion

        #region Public Properties

        public bool interactable
        {
            get { return _interactable; }
            set
            {
                if (!SetPropertyUtil.SetStruct(ref _interactable, value))
                    return;

                if (!_interactable)
                {
                    _isDraging = false;
                    _pointerDownPos = Vector2.zero;
                    _objDownPos = Vector2.zero;
                }
            }
        }

        /// <summary>
        /// 是否可以水平拖拽
        /// </summary>
        public bool Horizontal
        {
            get { return _canHorizontal; }
            set { SetPropertyUtil.SetStruct(ref _canHorizontal, value); }
        }

        /// <summary>
        /// 是否可以垂直拖拽
        /// </summary>
        public bool Vertical
        {
            get { return _canVertical; }
            set { SetPropertyUtil.SetStruct(ref _canVertical, value); }
        }

        /// <summary>
        /// 是否控制拖拽范围
        /// </summary>
        public bool CanOutOfArea
        {
            get { return _canOutOfArea; }
            set
            {
                if (!SetPropertyUtil.SetStruct(ref _canOutOfArea, value))
                    return;

                if (!_canOutOfArea)
                    CalMaxminArea();
            }
        }

        /// <summary>
        /// 拖拽物极限范围(x-left,y,-top,z-right,w-bottom)
        /// </summary>
        public Vector4 MaxmainArea
        {
            get { return _maxminArea; }
        }

        #endregion

        #region Pirvate Methods

        /// <summary>
        /// 限制拖拽对象在可拖拽范围内
        /// </summary>
        /// <param name="pos">拖拽对象当前目标坐标</param>
        private void ClampToArea(ref Vector2 pos)
        {
            pos.x = Mathf.Clamp(pos.x, _maxminArea.x, _maxminArea.z);
            pos.y = Mathf.Clamp(pos.y, _maxminArea.y, _maxminArea.w);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 计算拖拽物极限范围
        /// </summary>
        public void CalMaxminArea(float x = 0, float y = 0)
        {
            if (_dragObj == null) return;
            Vector2 baseArea = this.rectTransform.GetSize();
            Vector2 dragObjSize = _dragObj.GetSize();
            if (x != 0 || y != 0)
                dragObjSize = new Vector2(x, y);

            if (_dragObj.IsAnchorHorizontal(AnchorHorizontal.Left))
            {
                _maxminArea.x = (baseArea.x > dragObjSize.x) ? 0 : (baseArea.x - dragObjSize.x);
                _maxminArea.z = (baseArea.x > dragObjSize.x) ? (baseArea.x - dragObjSize.x) : 0;
            }
            else if (_dragObj.IsAnchorHorizontal(AnchorHorizontal.Center))
            {
                _maxminArea.x = (baseArea.x > dragObjSize.x)
                    ? ((dragObjSize.x - baseArea.x) * 0.5f)
                    : ((baseArea.x - dragObjSize.x) * 0.5f);
                _maxminArea.z = (baseArea.x > dragObjSize.x)
                    ? ((baseArea.x - dragObjSize.x) * 0.5f)
                    : ((dragObjSize.x - baseArea.x) * 0.5f);
            }
            else if (_dragObj.IsAnchorHorizontal(AnchorHorizontal.Right))
            {
                _maxminArea.x = (baseArea.x > dragObjSize.x) ? (dragObjSize.x - baseArea.x) : 0;
                _maxminArea.z = (baseArea.x > dragObjSize.x) ? 0 : (dragObjSize.x - baseArea.x);
            }

            if (_dragObj.IsAnchorVertical(AnchorVertical.Top))
            {
                _maxminArea.y = (baseArea.y > dragObjSize.y) ? (dragObjSize.y - baseArea.y) : 0;
                _maxminArea.w = (baseArea.y > dragObjSize.y) ? 0 : (dragObjSize.y - baseArea.y);
            }
            else if (_dragObj.IsAnchorVertical(AnchorVertical.Middle))
            {
                _maxminArea.y = (baseArea.y > dragObjSize.y)
                    ? ((dragObjSize.y - baseArea.y) * 0.5f)
                    : ((baseArea.y - dragObjSize.y) * 0.5f);
                _maxminArea.w = (baseArea.y > dragObjSize.y)
                    ? ((baseArea.y - dragObjSize.y) * 0.5f)
                    : ((dragObjSize.y - baseArea.y) * 0.5f);
            }
            else if (_dragObj.IsAnchorVertical(AnchorVertical.Bottom))
            {
                _maxminArea.y = (baseArea.y > dragObjSize.y) ? 0 : (baseArea.y - dragObjSize.y);
                _maxminArea.w = (baseArea.y > dragObjSize.y) ? (baseArea.y - dragObjSize.y) : 0;
            }
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
#if UNITY_EDITOR
            if (Application.isPlaying)
            {
                if (_dragObj == null)
                {
                    Debug.LogException(new System.Exception("拖拽对象为空"), this.gameObject);
                }
            }
#endif
            if (!_canOutOfArea)
                CalMaxminArea();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.onDragClickedEvent.RemoveAllListeners();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!interactable || _dragObj == null || _isDraging) return;

            Vector2 pointerUpPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.rectTransform(),
                eventData.position,
                eventData.pressEventCamera,
                out pointerUpPos
            );
            if (onDragClickedEvent != null)
                onDragClickedEvent.Invoke(
                    pointerUpPos.x - _dragObj.anchoredPosition.x,
                    pointerUpPos.y - _dragObj.anchoredPosition.y
                );
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interactable || _dragObj == null) return;

            _isDraging = false;

            _objDownPos = _dragObj.anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.rectTransform(),
                eventData.position,
                eventData.pressEventCamera,
                out _pointerDownPos
            );

            if (needHitObj)
                _hisOnDragObj = eventData.pointerCurrentRaycast.gameObject == _dragObj.gameObject;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!interactable || _dragObj == null) return;
            if (needHitObj && !_hisOnDragObj) return;

            _isDraging = true;

            Vector2 localPointerPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.rectTransform(),
                eventData.position,
                eventData.pressEventCamera,
                out localPointerPos
            );

            Vector2 targetPos = _objDownPos + localPointerPos - _pointerDownPos;

            if (!_canHorizontal)
                targetPos.x = _objDownPos.x;
            if (!_canVertical)
                targetPos.y = _objDownPos.y;

            if (!_canOutOfArea)
                ClampToArea(ref targetPos);

            _dragObj.anchoredPosition = targetPos;
        }

        public void OnSelect(BaseEventData eventData)
        {
        }

        #endregion

        [Serializable]
        public class DragClickedEvent : UnityEvent<float, float>
        {
        }
    }
}