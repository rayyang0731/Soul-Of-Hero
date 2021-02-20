using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 长按响应按钮
    /// </summary>
    [AddComponentMenu("KiwiUI/Selectable/LongPressButton")]
    public class UILongPressButton : UIButton
    {
        [Serializable]
        public class LongPressEvent : UnityEvent<GameObject, UILongPressButton>
        {
        }

        #region Private Variables

        /// <summary>
        /// 长按响应时长
        /// </summary>
        [SerializeField, LabelText("长按响应时长")] [BoxGroup("长按响应按钮", CenterLabel = true)]
        private float longPressDuration = 2;

        [SerializeField, LabelText("忽略TimeScale")] [BoxGroup("长按响应按钮")]
        private bool ignoreTimeScale = true;

        /// <summary>
        /// 是否已经按下
        /// </summary>
        private bool _isPointerDown = false;

        /// <summary>
        /// 按下的时间点
        /// </summary>
        private float _lastRespondTime = 0;

        /// <summary>
        /// 响应事件
        /// </summary>
        [BoxGroup("长按响应按钮")] public LongPressEvent _onLongPress = new LongPressEvent();

        #endregion

        #region Public Methods

        /// <summary>
        /// 设置长按响应时长
        /// </summary>
        /// <param name="val">要按住多长时间后响应事件</param>
        public void SetLongPressDuration(float val)
        {
            longPressDuration = val;
        }

        public void AddLongPressEvent(UnityAction<GameObject, UILongPressButton> buttonEvent)
        {
            if (buttonEvent != null)
                _onLongPress.AddListener(buttonEvent);
        }

        public void RemoveLongPressEvent(UnityAction<GameObject, UILongPressButton> buttonEvent)
        {
            if (buttonEvent != null)
                _onLongPress.RemoveListener(buttonEvent);
        }

        public void ClearLongPressEvent()
        {
            _onLongPress.RemoveAllListeners();
        }

        /// <summary>
        /// 按钮按下回调
        /// </summary>
        /// <param name="eventData">事件数据</param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _isPointerDown = true;
            _lastRespondTime = ignoreTimeScale ? Time.realtimeSinceStartup : Time.time;
            base.OnPointerDown(eventData);
        }

        /// <summary>
        /// 按钮抬起回调
        /// </summary>
        /// <param name="eventData">事件数据</param>
        public override void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            _isPointerDown = false;
            base.OnPointerUp(eventData);
        }

        #endregion

        #region Unity Methods

        protected override void OnDisable()
        {
            base.OnDisable();
            _isPointerDown = false;
            _lastRespondTime = 0;
        }

        private void Update()
        {
            if (!_isPointerDown || !PointerInButton) return;

            float curTime = ignoreTimeScale ? Time.realtimeSinceStartup : Time.time;

            float deltaTime = curTime - _lastRespondTime;
            if (deltaTime >= longPressDuration)
            {
                _isPointerDown = false;
                PointerInButton = false;
                _lastRespondTime = 0;
                if (_useButtonScale)
                    _uiScaleHelper.Rest();
                if (_onLongPress != null)
                    _onLongPress.Invoke(gameObject, this);
            }
        }

        #endregion
    }
}