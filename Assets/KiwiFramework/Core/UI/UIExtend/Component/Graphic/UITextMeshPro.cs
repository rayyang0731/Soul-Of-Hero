using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 可多状态图片显示组件
    /// </summary>
    [AddComponentMenu("KiwiUI/Graphic/TextMeshPro")]
    [RequireComponent(typeof(TextMeshProUGUI))]
    [ExecuteInEditMode, HideMonoScript]
    public class UITextMeshPro : UIMultipleStateComponent<TMPStateData>, IGrayable
    {
        #region Editor

#if UNITY_EDITOR
        protected override string[] stateNames
        {
            get
            {
                string[] values = new string[mStateDatas.Count + 1];
                values[0] = "无";
                for (int i = 1; i < values.Length; i++)
                {
                    values[i] = (i - 1) + " : " + mStateDatas[i - 1].name;
                }

                return values;
            }
        }

        protected override void OnStateDatasTitleBarGUI()
        {
            if (mDefaultState >= stateNames.Length)
                mDefaultState = -1;
            base.OnStateDatasTitleBarGUI();
        }

        protected override void OnStateDatasAddElement()
        {
            if (mStateDatas.Count >= const_maxStateCount)
                return;
            var data = TMPStateData.Default;
            data.name = "State " + mStateDatas.Count;
            mStateDatas.Add(data);
        }
#endif

        #endregion

        #region NativeText

        private TextMeshProUGUI _text;

        public TextMeshProUGUI Native
        {
            get
            {
                if (_text == null)
                    _text = GetComponent<TextMeshProUGUI>();
                return _text;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="targetState">状态索引</param>
        /// <param name="force">是否强制设置状态索引,可缺省,默认为false</param>
        /// <returns>修改状态是否成功</returns>
        public override bool SetState(int targetState, bool force = false)
        {
            if (!force && CurrentState == targetState)
                return false;

            if (targetState < 0 || targetState >= mStateDatas.Count || mStateDatas.Count == 1)
                return false;

            CurrentState = targetState;

            TMPStateData data = mStateDatas[targetState];

            if (data.overrideFont)
                Native.font = data.font;
            if (data.overrideColor)
                Native.color = data.color;

            return true;
        }

        /// <summary>
        /// 设置置灰状态
        /// </summary>
        /// <param name="isGray">是否置灰</param>
        public void SetGray(bool isGray)
        {
            UIEffectHelper.SetGray(this.Native, isGray);
        }

        #endregion

        #region Unity Methods

        protected override void Reset()
        {
            base.Reset();
            for (int i = 0; i < const_minStateCount; i++)
            {
                var data = TMPStateData.Default;
#if UNITY_EDITOR
                data.name = "State " + i;
#endif
                AddState(data);
            }
        }

        #endregion
    }
}