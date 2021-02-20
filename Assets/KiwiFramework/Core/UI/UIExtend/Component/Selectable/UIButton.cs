using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    // <summary>
    /// 点击按钮组件
    /// </summary>
    [HideMonoScript, ExecuteInEditMode]
    [RequireComponent(typeof(Graphic))]
    [RequireComponent(typeof(Button))]
    [AddComponentMenu("KiwiUI/Selectable/Button")]
    public class UIButton : UIComponentBase, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler,
        IPointerEnterHandler,
        IPointerExitHandler
    {
        #region Public Variables

        /// <summary>
        /// 是否点在按钮上
        /// </summary>
        protected bool PointerInButton = false;

        #region 音效

        /// <summary>
        /// 按钮点击是否播放音效
        /// </summary>
        [SerializeField, ToggleGroup("usePlaySound", ToggleGroupTitle = "音效", Order = 2)]
        protected bool usePlaySound = true;

        [SerializeField, ToggleGroup("usePlaySound"), HideLabel]
        protected UISoundHelper soundHelper;

        #endregion

        #endregion

        #region Private Variables

        /// <summary>
        /// 点击是否进行透明检测
        /// </summary>
        private bool _whetherToAlphaHit = false;

        #region 缩放

        /// <summary>
        /// 按钮点击是否应用缩放
        /// </summary>
        [SerializeField, ToggleGroup("_useButtonScale", ToggleGroupTitle = "缩放", Order = 1)]
        protected bool _useButtonScale = false;

        [SerializeField, ToggleGroup("_useButtonScale"), HideLabel]
        protected UIScaleHelper _uiScaleHelper;

        #endregion

        #region 无效与置灰

        /// <summary>
        /// 是否可以使用按钮置灰状态
        /// </summary>
        [SerializeField, LabelText("是否允许置灰")] [ToggleGroup("_useInvalidState", ToggleGroupTitle = "无效置灰", Order = 3)]
        private bool _useInvalidState = true;

        /// <summary>
        /// 置灰状态是否影响子物体
        /// </summary>
        [SerializeField, LabelText("是否影响子物体")] [ToggleGroup("_useInvalidState")]
        private bool _invalidAffectChild = true;

        /// <summary>
        /// 无效状态下是否可点击
        /// </summary>
        [SerializeField, LabelText("无效是否可点击")] [ToggleGroup("_useInvalidState")]
        private bool _invalidCanClick = false;

        #endregion

        #region 防连点

        [SerializeField, LabelText("允许点击"), ReadOnly] [ToggleGroup("_preventContinuousClick", Order = 4)]
        private bool _canClick = true;

        /// <summary>
        /// 是否防止连续点击
        /// </summary>
        [SerializeField, LabelText("是否防连点")] [ToggleGroup("_preventContinuousClick", ToggleGroupTitle = "防止连续点击")]
        private bool _preventContinuousClick = false;

        /// <summary>
        /// 防止连续点击时间
        /// </summary>
        [SerializeField, LabelText("防连点时间(秒)")] [ToggleGroup("_preventContinuousClick")]
        private float _preventContinuousTime = 1f;

        /// <summary>
        /// 防止连续点击是否置灰
        /// </summary>
        [SerializeField, LabelText("防连点是否置灰")] [ToggleGroup("_preventContinuousClick")]
        private bool _preventContinuousWillGray = false;

        /// <summary>
        /// 防止连点进行中点击事件
        /// </summary>
        [SerializeField, ToggleGroup("_preventContinuousClick")]
        private Button.ButtonClickedEvent _onPreventContinuousClick = new Button.ButtonClickedEvent();

        /// <summary>
        /// 防止连点已结束事件
        /// </summary>
        [SerializeField, ToggleGroup("_preventContinuousClick")]
        private Button.ButtonClickedEvent _onPreventContinuousCompleted = new Button.ButtonClickedEvent();

        #endregion

        #region 事件

        /// <summary>
        /// 按钮被按下事件
        /// </summary>
        [SerializeField, FoldoutGroup("Event", Order = 5)]
        private Button.ButtonClickedEvent _onPointerDown = new Button.ButtonClickedEvent();

        /// <summary>
        /// 按钮抬起事件
        /// </summary>
        [SerializeField, FoldoutGroup("Event")]
        private Button.ButtonClickedEvent _onPointerUp = new Button.ButtonClickedEvent();

        /// <summary>
        /// 按钮点击时间
        /// </summary>
        [SerializeField]
        private Button.ButtonClickedEvent _onPointerClick
        {
            get { return Native.onClick; }
        }

        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        /// 是否为可用状态
        /// </summary>
        [LabelText("是否可用"), ShowInInspector, PropertyOrder(-1)]
        public bool interactable
        {
            get { return Native.interactable; }
            set
            {
                if (!_useInvalidState)
                    Native.interactable = value;
                else
                    SetValid(value);
            }
        }

        #endregion

        #region Private Properties

        /// <summary>
        /// 点击是否进行透明检测
        /// </summary>
        [ShowInInspector, LabelText("点击Alpha检测"), PropertyOrder(-1)]
        private bool WhetherToAlphaHit
        {
            get { return Image != null && _whetherToAlphaHit; }
            set
            {
                var result = value;
                if (Image == null)
                    result = false;
                _whetherToAlphaHit = result;
            }
        }

        /// <summary>
        /// 是否在防连点状态中
        /// </summary>
        private bool canClick
        {
            get { return _canClick; }
            set
            {
                Native.interactable = value;
                _canClick = value;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 当按钮按下执行按下事件
        /// </summary>
        private void PointerDown()
        {
            if (!Native.IsActive() || !Native.IsInteractable())
                return;
            PointerInButton = true;
            UISystemProfilerApi.AddMarker("UIButton.onPointerDown", (UnityEngine.Object) this);
            if (_useButtonScale)
                _uiScaleHelper.Execute();
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.DOWN);
            _onPointerDown.Invoke();
        }

        /// <summary>
        /// 当按钮抬起执行抬起事件
        /// </summary>
        private void PointerUp()
        {
            if (!Native.IsActive())
                return;
            if (_useButtonScale)
                _uiScaleHelper.Rest();

            if (_preventContinuousClick)
            {
                if (!canClick)
                {
                    if (_onPreventContinuousClick != null)
                        _onPreventContinuousClick.Invoke();
                    return;
                }

                Timer.Create(_preventContinuousTime, (timer) =>
                {
                    canClick = true;
                    if (_onPreventContinuousCompleted != null)
                        _onPreventContinuousCompleted.Invoke();
                    if (_preventContinuousWillGray)
                        SetValid(true, false);
                }).AddStartCallback((timer) =>
                {
                    canClick = false;
                    if (_preventContinuousWillGray)
                        SetValid(false, false);
                    if (_useButtonScale)
                        _uiScaleHelper.Rest();
                    if (Native.onClick != null)
                        Native.onClick.Invoke();
                }).Startup();
            }

            UISystemProfilerApi.AddMarker("UIButton.onPointerUp", (UnityEngine.Object) this);
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.UP);
            _onPointerUp.Invoke();
        }

        private void SetValid(bool state, bool invalidCanClick = false)
        {
            if (!_useInvalidState)
                return;

            _invalidCanClick = invalidCanClick || _invalidCanClick;

            if (!state)
                Native.interactable = _invalidCanClick;
            else
                Native.interactable = true;

            if (_invalidAffectChild)
                UIEffectHelper.SetGrayRecursion(gameObject, !state);
            else
                UIEffectHelper.SetGray(Image, !state);
        }

        #endregion


        #region Public Methods

        #region PointerDown

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            PointerInButton = true;
            PointerDown();
        }

        /// <summary>
        /// 添加按钮按下事件
        /// </summary>
        /// <param name="buttonEvent">要添加的按下事件</param>
        public void AddButtonDownEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerDown.AddListener(buttonEvent);
        }

        /// <summary>
        /// 移除按钮按下事件
        /// </summary>
        /// <param name="buttonEvent">要移除的按下事件</param>
        public void RemoveButtonDownEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerDown.RemoveListener(buttonEvent);
        }

        /// <summary>
        /// 清空按钮按下事件
        /// </summary>
        public void ClearButtonDownEvent()
        {
            _onPointerDown.RemoveAllListeners();
        }

        #endregion

        #region PointerUp

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            PointerUp();
        }

        /// <summary>
        /// 添加按钮抬起事件
        /// </summary>
        /// <param name="buttonEvent">要添加的事件</param>
        public void AddButtonUpEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerUp.AddListener(buttonEvent);
        }

        /// <summary>
        /// 移除按钮抬起事件
        /// </summary>
        /// <param name="buttonEvent">要移除的事件</param>
        public void RemoveButtonUpEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerUp.RemoveListener(buttonEvent);
        }

        /// <summary>
        /// 清空按钮抬起事件
        /// </summary>
        public void ClearButtonUpEvent()
        {
            _onPointerUp.RemoveAllListeners();
        }

        #endregion

        #region PointerClick

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.CLICK);
        }

        /// <summary>
        /// 添加按钮抬起事件
        /// </summary>
        /// <param name="buttonEvent">要添加的事件</param>
        public void AddButtonClickEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerClick.AddListener(buttonEvent);
        }

        /// <summary>
        /// 移除按钮抬起事件
        /// </summary>
        /// <param name="buttonEvent">要移除的事件</param>
        public void RemoveButtonClickEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onPointerClick.RemoveListener(buttonEvent);
        }

        /// <summary>
        /// 清空按钮抬起事件
        /// </summary>
        public void ClearButtonClickEvent()
        {
            _onPointerClick.RemoveAllListeners();
        }

        #endregion


        #region PointerEnter&Exit

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerInButton = true;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            PointerInButton = false;
        }

        #endregion

        #endregion

        #region Native

        public Image Image
        {
            get
            {
                if (Native.targetGraphic == null)
                    Native.targetGraphic = GetComponent<Image>();
                if (Native.targetGraphic == null)
                    return null;
                return Native.targetGraphic as Image;
            }
        }

        private Button _btn;

        public Button Native
        {
            get
            {
                if (_btn == null)
                    _btn = GetComponent<Button>();
                return _btn;
            }
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            if (Image != null && WhetherToAlphaHit)
                Image.alphaHitTestMinimumThreshold = 0.1f;

            _canClick = true;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            if (_useButtonScale)
                _uiScaleHelper.Rest();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            PointerInButton = false;
        }

        #endregion

        #region Editor

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            if (_uiScaleHelper == null)
                _uiScaleHelper = new UIScaleHelper(this.rectTransform());
            if (soundHelper == null)
                soundHelper = new UISoundHelper();
        }

        protected override void Reset()
        {
            base.Reset();
            usePlaySound = true;
            _useButtonScale = true;
            _uiScaleHelper = new UIScaleHelper(this.rectTransform());
            soundHelper = new UISoundHelper();

            if (Native.targetGraphic == null)
                Native.targetGraphic = GetComponent<Image>();
            if (Native.targetGraphic == null)
                Native.transition = Selectable.Transition.None;
        }
#endif

        #endregion
    }
}