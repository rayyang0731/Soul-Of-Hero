using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 重复响应按钮
    /// </summary>
    [AddComponentMenu("KiwiUI/Selectable/RepeatButton")]
    public class UIRepeatButton : UIButton
    {
        /// <summary>
        /// 间隔时间类型
        /// </summary>
        private enum INTERVAL_TYPE
        {
            /// <summary>
            /// 曲线类型
            /// </summary>
            CURVE,

            /// <summary>
            /// 固定时间
            /// </summary>
            FIXED,
        }

        #region Private Variables

        /// <summary>
        /// 使用曲线控制响应间隔时间
        /// </summary>
        [BoxGroup("重复响应按钮", CenterLabel = true), PropertyOrder(-1)] [SerializeField, LabelText("间隔时间类型"), EnumPaging]
        private INTERVAL_TYPE _intervalType = INTERVAL_TYPE.CURVE;

        /// <summary>
        /// 响应间隔时间曲线
        /// </summary>
        [SerializeField, LabelText("时间曲线")]
        [ShowIfGroup("重复响应按钮/curve", MemberName = "_intervalType", Value = INTERVAL_TYPE.CURVE)]
        [BoxGroup("重复响应按钮/curve/Box")]
        [InfoBox("Y轴的值代表间隔时间,X轴的值仅代表长度,不影响间隔时间的值.", InfoMessageType.Info)]
        private AnimationCurve _intervalCurve = new AnimationCurve(new Keyframe(0, 0.5f), new Keyframe(1, 0.5f));

        /// <summary>
        /// 曲线拆分节点数量
        /// </summary>
        [SerializeField, LabelText("时间节点数量")]
        [ShowIfGroup("重复响应按钮/curve", MemberName = "_intervalType", Value = INTERVAL_TYPE.CURVE)]
        [BoxGroup("重复响应按钮/curve/Box", ShowLabel = false)]
        private int _CurveNodeCount = 5;

        /// <summary>
        /// 固定响应间隔时间
        /// </summary>
        [SerializeField, LabelText("固定间隔时间")]
        [ShowIfGroup("重复响应按钮/fixed", MemberName = "_intervalType", Value = INTERVAL_TYPE.FIXED)]
        [BoxGroup("重复响应按钮/fixed/Box", ShowLabel = false)]
        private float _fixedInterval = 0.2f;

        [SerializeField, LabelText("忽略TimeScale")] [BoxGroup("重复响应按钮")]
        private bool ignoreTimeScale = true;

        /// <summary>
        /// 按下的时候立即执行
        /// </summary>
        [SerializeField, LabelText("立即执行"), PropertyTooltip("按下按钮时,是否立即执行响应时间,如果不进行勾选,事件将会在第一个时间节点到达时调用")]
        [BoxGroup("重复响应按钮")]
        private bool _immediateDo = true;

        /// <summary>
        /// 当前调用次数
        /// </summary>
        private int _curTimes = 0;

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
        [BoxGroup("重复响应按钮")] public Button.ButtonClickedEvent _onRespond = new Button.ButtonClickedEvent();

        #endregion

        #region Private Properties

        /// <summary>
        /// 调用间隔时间
        /// </summary>
        private float Interval
        {
            get
            {
                return _intervalType == INTERVAL_TYPE.FIXED
                    ? _fixedInterval
                    : _intervalCurve.Evaluate((TotalLength / _CurveNodeCount) * _curTimes);
            }
        }

        /// <summary>
        /// 间隔时间变化最大时长
        /// </summary>
        private float TotalLength
        {
            get { return _intervalCurve.keys[_intervalCurve.length - 1].time; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 设置固定间隔时间(并且会自动把间隔时间改为使用固定间隔时间)
        /// </summary>
        /// <param name="val">间隔时间</param>
        public void SetFixInterval(float val)
        {
            _intervalType = INTERVAL_TYPE.FIXED;
            _fixedInterval = val;
        }

        /// <summary>
        /// 设置响应时间曲线
        /// </summary>
        /// <param name="keys">曲线上的时间点数组,请保持与values的个数一致</param>
        /// <param name="values">曲线上每个时间点的值得数组,请保持与keys的个数一致</param>
        /// <param name="count">变化阶段次数</param>
        public void SetCurveInterval(float[] keys, float[] values, int count)
        {
            if (keys == null || keys.Length <= 0 || values == null || values.Length <= 0 || count <= 1)
            {
                Debug.LogError("要添加的曲线数据有问题,改用默认固定间隔时间");
                SetFixInterval(0.2f);
                return;
            }

            _intervalType = INTERVAL_TYPE.CURVE;
            _CurveNodeCount = count;
            _intervalCurve = new AnimationCurve();
            int minCount = Mathf.Min(keys.Length, values.Length);
            for (int i = 0; i < minCount; i++)
            {
                _intervalCurve.AddKey(keys[i], values[i]);
            }
        }

        /// <summary>
        /// 设置响应时间曲线
        /// </summary>
        /// <param name="curve">响应曲线</param>
        /// <param name="count">变化阶段次数</param>
        public void SetCurveInterval(AnimationCurve curve, int count)
        {
            if (curve == null || curve.keys.Length <= 0 || count <= 1)
            {
                Debug.LogError("要添加的曲线数据有问题,改用默认固定间隔时间");
                SetFixInterval(0.2f);
                return;
            }

            _intervalType = INTERVAL_TYPE.CURVE;
            _CurveNodeCount = count;
            _intervalCurve = curve;
        }

        /// <summary>
        /// 添加重复响应事件
        /// </summary>
        /// <param name="buttonEvent">要添加的响应事件</param>
        public void AddRespondEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onRespond.AddListener(buttonEvent);
        }

        /// <summary>
        /// 移除重复响应事件
        /// </summary>
        /// <param name="buttonEvent">要移除的响应事件</param>
        public void RemoveRespondEvent(UnityAction buttonEvent)
        {
            if (buttonEvent != null)
                _onRespond.RemoveListener(buttonEvent);
        }

        /// <summary>
        /// 清空全部响应事件
        /// </summary>
        public void ClearRespondEvent()
        {
            _onRespond.RemoveAllListeners();
        }

        /// <summary>
        /// 按钮按下回调
        /// </summary>
        /// <param name="eventData">事件数据</param>
        public override void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
            _lastRespondTime = ignoreTimeScale ? Time.realtimeSinceStartup : Time.time;
            _curTimes = 0;

            if (_immediateDo && _onRespond != null)
            {
                _onRespond.Invoke();
                if (usePlaySound)
                    soundHelper.Play(POINTER_TYPE.REPEAT_RESPONE);
            }

            base.OnPointerDown(eventData);
        }

        /// <summary>
        /// 按钮抬起回调
        /// </summary>
        /// <param name="eventData">事件数据</param>
        public override void OnPointerUp(PointerEventData eventData)
        {
            _isPointerDown = false;
            base.OnPointerUp(eventData);
        }

        #endregion

        #region Unity Methods

        protected override void OnDisable()
        {
            base.OnDisable();
            _isPointerDown = false;
            PointerInButton = false;
            _lastRespondTime = 0;
        }

        private void Update()
        {
            if (!_isPointerDown || !PointerInButton) return;

            float curTime = ignoreTimeScale ? Time.realtimeSinceStartup : Time.time;

            float deltaTime = curTime - _lastRespondTime;

            if (!(deltaTime >= Interval)) return;

            _lastRespondTime = ignoreTimeScale ? Time.realtimeSinceStartup : Time.time;

            _curTimes = Mathf.Min(++_curTimes, _CurveNodeCount);

            if (_onRespond != null)
            {
                _onRespond.Invoke();
                if (usePlaySound)
                    soundHelper.Play(POINTER_TYPE.REPEAT_RESPONE);
            }
        }

        #endregion
    }
}