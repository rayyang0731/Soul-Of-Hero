using System.Collections.Generic;
using System.Linq;
using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 可穿透点击遮罩
    /// </summary>
    [HideMonoScript]
    [AddComponentMenu("KiwiUI/Graphic/Background")]
    [ExecuteInEditMode]
    public class UIBackground : UIComponentBase, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        private enum MASK_TYPE
        {
            /// <summary>
            /// 有色半透
            /// </summary>
            COLOR,

            /// <summary>
            /// 背景虚化
            /// </summary>
            BLUR,

            /// <summary>
            /// 全透
            /// </summary>
            TRANSPARENT,
        }

        #region Static Variables

        private static Sprite _defaultSprite = null;

        private static Sprite DefaultSprite
        {
            get
            {
                if (_defaultSprite != null) return _defaultSprite;

                var tex2D = Texture2D.whiteTexture;
                tex2D.name = "kiwi.UIBackground";
                _defaultSprite = Sprite.Create(tex2D, new Rect(0, 0, 4, 4), Vector2.zero);
                _defaultSprite.name = "Kiwi.Sprite.UIBackground";

                return _defaultSprite;
            }
        }


        /// <summary>
        /// 有色遮罩时的颜色
        /// </summary>
        private static readonly Color MaskColor = new Color(0, 0, 0, 0.5f);

        #endregion

        #region Private Variables

        /// <summary>
        /// 遮罩类型
        /// </summary>
        private MASK_TYPE _maskType = MASK_TYPE.COLOR;

        /// <summary>
        /// 是否可以点击
        /// </summary>
        [SerializeField, ToggleGroup("enableClick", ToggleGroupTitle = "是否可以点击")]
        private bool enableClick = false;

        /// <summary>
        /// 是否可以穿透
        /// </summary>
        [SerializeField, LabelText("是否可以穿透"), ToggleGroup("enableClick"),
         BoxGroup("enableClick/Box", ShowLabel = false)]
        private bool enablePass = false;

        /// <summary>
        /// 点击事件
        /// </summary>
        [SerializeField, ToggleGroup("enableClick"), BoxGroup("enableClick/Box")]
        private Button.ButtonClickedEvent _onButtonClick = new Button.ButtonClickedEvent();

        /// <summary>
        /// 按下事件
        /// </summary>
        [SerializeField, ToggleGroup("enableClick"), BoxGroup("enableClick/Box")]
        private Button.ButtonClickedEvent _onButtonDown = new Button.ButtonClickedEvent();

        /// <summary>
        /// 抬起事件
        /// </summary>
        [SerializeField, ToggleGroup("enableClick"), BoxGroup("enableClick/Box")]
        private Button.ButtonClickedEvent _onButtonUp = new Button.ButtonClickedEvent();

        #endregion

        #region Private Properties

        /// <summary>
        /// 遮罩类型
        /// </summary>
        [ShowInInspector, LabelText("遮罩类型"), EnumPaging, PropertyOrder(-1)]
        private MASK_TYPE maskType
        {
            get => _maskType;
            set
            {
                if (value == MASK_TYPE.TRANSPARENT)
                {
                    var graphic = GetComponent<Image>();
                    if (graphic != null)
                        DestroyImmediate(graphic);

                    gameObject.ForceGetComponent<UITransparentGraphic>();
                }
                else
                {
                    var transGraphic = GetComponent<UITransparentGraphic>();
                    if (transGraphic != null)
                        DestroyImmediate(transGraphic);

                    var graphic = gameObject.ForceGetComponent<Image>();
                    
                    UIEffectHelper.SetBlur(graphic, value == MASK_TYPE.BLUR);
                    
                    if (value == MASK_TYPE.COLOR)
                    {
                        graphic.sprite = DefaultSprite;
                        graphic.color = MaskColor;
                    }
                    else if (value == MASK_TYPE.BLUR)
                    {
                        UIEffectHelper.SetBlur(graphic, value == MASK_TYPE.BLUR);
                        graphic.color = Color.white;
                    }
                }

                _maskType = value;
            }
        }

        #endregion

        #region Private Methods

        private void PassEvent<T>(PointerEventData data, ExecuteEvents.EventFunction<T> callback)
            where T : IEventSystemHandler
        {
            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(data, results);

            GameObject current = data.pointerCurrentRaycast.gameObject;
            if (current == null)
                return;

            foreach (var result in results.Where(result => current != result.gameObject))
            {
                ExecuteEvents.Execute(result.gameObject, data, callback);
                break;
            }
        }

        #endregion


        #region Public Methods

        #region Pointer Click

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!enableClick)
                return;

            if (_onButtonClick != null)
                _onButtonClick.Invoke();

            if (enablePass)
                PassEvent(eventData, ExecuteEvents.pointerClickHandler);
        }

        public void AddPointerClickEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonClick.AddListener(pointerEvent);
        }

        public void RemovePointerClickEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonClick.RemoveListener(pointerEvent);
        }

        public void ClearPointerClickEvent()
        {
            _onButtonClick.RemoveAllListeners();
        }

        #endregion

        #region Pointer Down

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!enableClick)
                return;

            if (_onButtonDown != null)
                _onButtonDown.Invoke();

            if (enablePass)
                PassEvent(eventData, ExecuteEvents.pointerDownHandler);
        }

        public void AddPointerDownEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonDown.AddListener(pointerEvent);
        }

        public void RemovePointerDownEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonDown.RemoveListener(pointerEvent);
        }

        public void ClearPointerDownEvent()
        {
            _onButtonDown.RemoveAllListeners();
        }

        #endregion

        #region Pointer Up

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!enableClick)
                return;

            if (_onButtonUp != null)
                _onButtonUp.Invoke();

            if (enablePass)
                PassEvent(eventData, ExecuteEvents.pointerUpHandler);
        }

        public void AddPointerUpEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonUp.AddListener(pointerEvent);
        }

        public void RemovePointerUpEvent(UnityAction pointerEvent)
        {
            if (pointerEvent != null)
                _onButtonUp.RemoveListener(pointerEvent);
        }

        public void ClearPointerUpEvent()
        {
            _onButtonUp.RemoveAllListeners();
        }

        #endregion

        #endregion

        #region Editor

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();

            maskType = MASK_TYPE.COLOR;
        }
#endif

        #endregion
    }
}