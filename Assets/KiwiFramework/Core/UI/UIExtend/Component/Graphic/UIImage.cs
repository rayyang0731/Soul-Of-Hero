using KiwiFramework.Core;
using UnityEngine;
using UnityEngine.UI;
using KiwiFramework.UI;
using Sirenix.OdinInspector;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 可多状态图片显示组件
    /// </summary>
    [AddComponentMenu("KiwiUI/Graphic/Image")]
    [RequireComponent(typeof(Image))]
    [ExecuteInEditMode, HideMonoScript]
    public class UIImage : UIMultipleStateComponent<ImageStateData>, IGrayable
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
            var data = ImageStateData.Default;
            data.name = "State " + mStateDatas.Count;
            mStateDatas.Add(data);
        }
#endif

        #endregion

        #region NativeImage

        private Image _img;

        public Image Native
        {
            get
            {
                if (_img == null)
                    _img = GetComponent<Image>();
                return _img;
            }
        }

        public Color color
        {
            get { return Native.color; }
            set { Native.color = value; }
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

            ImageStateData data = mStateDatas[targetState];

            Native.sprite = data.sprite;

            if (data.overrideColor)
                Native.color = data.color;

            if (data.autoUseNativeSize && (Native.type == Image.Type.Simple || Native.type == Image.Type.Filled))
                Native.SetNativeSize();
            else if (data.overrideSize)
            {
                this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, data.size.x);
                this.rectTransform().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, data.size.y);
            }

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
                var data = ImageStateData.Default;
#if UNITY_EDITOR
                data.name = "State " + i;
#endif
                AddState(data);
            }
        }

        #endregion
    }
}