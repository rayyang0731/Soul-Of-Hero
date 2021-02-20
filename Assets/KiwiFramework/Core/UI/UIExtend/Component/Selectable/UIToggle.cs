using KiwiFramework.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 开关组件
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    [AddComponentMenu("KiwiUI/Graphic/Toggle")]
    public class UIToggle : UIComponentBase, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        /// <summary>
        /// 开关效果类型
        /// </summary>
        enum TOGGLE_TYPE
        {
            /// <summary>
            /// UNITY Toggle 类型
            /// </summary>
            NATIVE,

            /// <summary>
            /// 切换对象类型
            /// </summary>
            SWITCH_OBJECTS,

            /// <summary>
            /// 切换图片类型
            /// </summary>
            SWITCH_IMAGES
        }

        #region Static

        #endregion

        #region Editor

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            if (soundHelper == null)
                soundHelper = new UISoundHelper();

            if (_toggleType == TOGGLE_TYPE.NATIVE)
            {
                Native.toggleTransition = Toggle.ToggleTransition.Fade;
                if (_uiImage != null)
                {
                    DestroyImmediate(_uiImage);
                    _uiImage = null;
                }

                if (_off != null)
                {
                    DestroyImmediate(_off);
                    _off = null;
                }

                if (_on != null)
                {
                    DestroyImmediate(_on);
                    _on = null;
                }
            }
            else
            {
                Native.toggleTransition = Toggle.ToggleTransition.None;
                if (_toggleType == TOGGLE_TYPE.SWITCH_IMAGES)
                {
                    if (_off != null)
                    {
                        DestroyImmediate(_off);
                        _off = null;
                    }

                    if (_on != null)
                    {
                        DestroyImmediate(_on);
                        _on = null;
                    }

                    if (_uiImage == null)
                        _uiImage = gameObject.ForceGetComponent<UIImage>();

                    if (_uiImage.StateCount < 2)
                        while (_uiImage.StateCount < 2)
                            _uiImage.AddState(ImageStateData.Default);
                    else if (_uiImage.StateCount > 2)
                        while (_uiImage.StateCount > 2)
                            _uiImage.RemoveState(_uiImage.StateCount - 1);

                    string[] stateNames = new string[2] {"OFF", "ON"};
                    for (int i = 0; i < 2; i++)
                    {
                        var data = _uiImage.GetState(i);
                        var imageStateData = data.Value;
                        imageStateData.name = stateNames[i];
                        _uiImage.ChangeStateData(i, imageStateData);
                    }
                }
                else
                {
                    if (_uiImage != null)
                    {
                        DestroyImmediate(_uiImage);
                        _uiImage = null;
                    }

                    if (_off == null)
                    {
                        foreach (Transform child in transform)
                        {
                            if (child.name.ToLower().Contains("off"))
                            {
                                _off = child.gameObject;
                                break;
                            }
                        }

                        if (_off == null)
                        {
                            _off = new GameObject("OFF", typeof(RectTransform));
                            _off.rectTransform().pivot = this.rectTransform().pivot;
                            _off.rectTransform().SetParent(this.transform, Vector3.zero);
                            _off.rectTransform().pivot = Vector2.one * 0.5f;
                        }
                    }

                    if (_on == null)
                    {
                        foreach (Transform child in transform)
                        {
                            if (child.name.ToLower().Contains("on"))
                            {
                                _on = child.gameObject;
                                break;
                            }
                        }

                        if (_on == null)
                        {
                            _on = new GameObject("ON", typeof(RectTransform));
                            _on.rectTransform().pivot = this.rectTransform().pivot;
                            _on.rectTransform().SetParent(this.transform, Vector3.zero);
                            _on.rectTransform().pivot = Vector2.one * 0.5f;
                        }
                    }
                }
            }
        }

        protected override void Reset()
        {
            base.Reset();
            usePlaySound = true;
            soundHelper = new UISoundHelper();

            if (Native.targetGraphic == null)
                Native.targetGraphic = GetComponent<Image>();
            if (Native.targetGraphic == null)
                Native.transition = Selectable.Transition.None;
        }
#endif

        #endregion

        #region Native

        public Image Image
        {
            get
            {
                if (Native.targetGraphic == null)
                {
                    Native.targetGraphic = GetComponent<Image>();
                    if (Native.targetGraphic == null)
                    {
                        Debug.LogWarning("Image Component is not exist.", this.gameObject);
                        return null;
                    }
                }

                return Native.targetGraphic as Image;
            }
        }

        private Toggle _tog;

        public Toggle Native
        {
            get
            {
                if (_tog == null)
                    _tog = GetComponent<Toggle>();
                return _tog;
            }
        }

        #endregion

        #region Pirvate Variables

        [SerializeField, LabelText("开关效果类型"), EnumPaging]
        [PropertyTooltip("Toggle切换的显示效果\n" +
                         "NATIVE - Unity Toggle\n" +
                         "SWITCH_OBJECTS - 切换对象\n" +
                         "SWITCH_IMAGES - 切换图片")]
        private TOGGLE_TYPE _toggleType = TOGGLE_TYPE.NATIVE;

        /// <summary>
        /// 图片多状态图片组件
        /// </summary>
        private UIImage _uiImage;

        /// <summary>
        /// 开关的ON对象
        /// </summary>
        [SerializeField, Indent, LabelText("ON 对象"), ShowIf("_toggleType", TOGGLE_TYPE.SWITCH_OBJECTS)]
        private GameObject _on;

        /// <summary>
        /// 开关的OFF对象
        /// </summary>
        [SerializeField, Indent, LabelText("OFF 对象"), ShowIf("_toggleType", TOGGLE_TYPE.SWITCH_OBJECTS)]
        private GameObject _off;

        #region 缩放

        /// <summary>
        /// 按钮点击是否应用缩放
        /// </summary>
        [SerializeField, ToggleGroup("_useButtonScale", ToggleGroupTitle = "缩放", Order = 1)]
        protected bool _useButtonScale = false;

        [SerializeField, ToggleGroup("_useButtonScale"), HideLabel]
        protected UIScaleHelper _uiScaleHelper;

        #endregion

        #region 音效

        /// <summary>
        /// 按钮点击是否播放音效
        /// </summary>
        [SerializeField, ToggleGroup("usePlaySound", ToggleGroupTitle = "音效", Order = 2)]
        private bool usePlaySound = true;

        [SerializeField, ToggleGroup("usePlaySound"), HideLabel]
        private UISoundHelper soundHelper;

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

        /// <summary>
        /// 值发生改变事件
        /// </summary>
        [SerializeField] private Toggle.ToggleEvent _onValueChanged = new Toggle.ToggleEvent();

        #endregion

        #region Public Variables

        #endregion

        #region Private Properties

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

        #region Public Properties

        #endregion

        #region Private Methods

        private void PointerDown()
        {
            if (!Native.IsActive() || !Native.IsInteractable())
                return;
            UISystemProfilerApi.AddMarker("UIToggle.onPointerDown", (UnityEngine.Object) this);
            if (_useButtonScale)
                _uiScaleHelper.Execute();
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.DOWN);
        }

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
                        SetValid(true);
                }).AddStartCallback((timer) =>
                {
                    canClick = false;
                    if (_preventContinuousWillGray)
                        SetValid(false);
                    if (_useButtonScale)
                        _uiScaleHelper.Rest();
                }).Startup();
            }

            UISystemProfilerApi.AddMarker("UIToggle.onPointerUp", (UnityEngine.Object) this);
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.UP);
        }

        private void SetValid(bool state)
        {
            if (!_useInvalidState)
                return;

            Native.interactable = !state;

            if (_invalidAffectChild)
                UIEffectHelper.SetGrayRecursion(gameObject, !state);
            else
                UIEffectHelper.SetGray(Image, !state);
        }

        private void OnValueChanged(bool value)
        {
            if (_toggleType == TOGGLE_TYPE.SWITCH_IMAGES)
            {
                _uiImage.SetState(value ? 1 : 0);
            }
            else if (_toggleType == TOGGLE_TYPE.SWITCH_OBJECTS)
            {
                _on.SetActive(value);
                _off.SetActive(!value);
            }

            if (_onValueChanged != null)
                _onValueChanged.Invoke(value);
        }

        #endregion

        #region Public Methods

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            PointerDown();
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            PointerUp();
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            if (usePlaySound)
                soundHelper.Play(POINTER_TYPE.CLICK);
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            Native.onValueChanged.AddListener(OnValueChanged);
            base.Awake();

            OnValueChanged(_tog.isOn);
        }

        #endregion
    }
}