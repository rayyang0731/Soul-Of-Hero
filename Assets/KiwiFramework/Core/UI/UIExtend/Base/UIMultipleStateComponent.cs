using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;

#endif

namespace KiwiFramework.UI
{
    public abstract class UIMultipleStateComponent<T> : UIComponentBase, IMultipleStates<T> where T : struct
    {
        #region Editor

#if UNITY_EDITOR
        /// <summary>
        /// 最小状态数量
        /// </summary>
        protected const int const_minStateCount = 0;

        /// <summary>
        /// 最大状态数量
        /// </summary>
        protected const int const_maxStateCount = 10;

        /// <summary>
        /// 所有状态的名称
        /// </summary>
        protected virtual string[] stateNames
        {
            get { return new string[1] {"无"}; }
        }

        protected virtual void OnStateDatasTitleBarGUI()
        {
            UnityEditor.EditorGUILayout.BeginHorizontal();
            SirenixEditorFields.SegmentedProgressBarField(mStateDatas.Count, const_minStateCount, const_maxStateCount);
            UnityEditor.EditorGUILayout.LabelField("默认状态", GUILayout.Width(50));
            mDefaultState = UnityEditor.EditorGUILayout.Popup(mDefaultState + 1, stateNames, GUILayout.Width(80)) - 1;
            UnityEditor.EditorGUILayout.EndHorizontal();
        }

        protected virtual void OnStateDatasBeginListElementGUI(int index)
        {
            SirenixEditorGUI.BeginIndentedVertical(SirenixGUIStyles.BoxContainer);
        }

        protected virtual void OnStateDatasEndListElementGUI(int index)
        {
            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.x + rect.width - 16;
            rect.y = rect.y + rect.height - 16;
            rect.size = Vector2.one * 16;
            if (SirenixEditorGUI.IconButton(rect, Sirenix.Utilities.Editor.EditorIcons.MagnifyingGlass, "预览状态效果"))
                SetState(index, true);
            SirenixEditorGUI.EndIndentedVertical();
        }

        protected virtual void OnStateDatasRemoveElement(T data)
        {
            if (mStateDatas.Count <= const_minStateCount)
                return;
            mStateDatas.Remove(data);
        }

        protected virtual void OnStateDatasAddElement()
        {
        }
#endif

        #endregion

        #region Private Variables

        [SerializeField, HideInInspector] protected int mDefaultState = -1;
        protected bool mAffectedByParent = true;
        protected int mCurrentState = 0;

        /// <summary>
        /// 全部状态数据
        /// </summary>
#if UNITY_EDITOR
        [SerializeField, LabelText("状态数据"), PropertySpace]
        [ListDrawerSettings(
            ShowIndexLabels = true,
            ListElementLabelName = "name",
            OnTitleBarGUI = "OnStateDatasTitleBarGUI",
            OnBeginListElementGUI = "OnStateDatasBeginListElementGUI",
            OnEndListElementGUI = "OnStateDatasEndListElementGUI",
            CustomRemoveElementFunction = "OnStateDatasRemoveElement",
            CustomAddFunction = "OnStateDatasAddElement")]
#endif
        protected List<T> mStateDatas = new List<T>();

        #endregion

        #region Public Properties

        /// <summary>
        /// 默认状态,如果为-1,则为无默认状态
        /// </summary>
        public int DefaultState
        {
            get { return mDefaultState; }
            private set { mDefaultState = value; }
        }

        /// <summary>
        /// 本地状态是否受到父物体状态影响
        /// </summary>
        public bool AffectedByParent
        {
            get { return mAffectedByParent; }
            set
            {
                if (mAffectedByParent != value)
                    mAffectedByParent = value;
            }
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        [ShowInInspector, HideInEditorMode, PropertyOrder(-1), LabelText("当前状态")]
        [DisableInPlayMode, DisplayAsString]
        public int CurrentState
        {
            get { return mCurrentState; }
            protected set { mCurrentState = Mathf.Clamp(value, 0, mStateDatas.Count); }
        }

        /// <summary>
        /// 状态数量
        /// </summary>
        public int StateCount
        {
            get { return mStateDatas.Count; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 初始化状态数据
        /// </summary>
        public virtual void Initialize()
        {
            if (mStateDatas == null)
                mStateDatas = new List<T>();
        }

        /// <summary>
        /// 添加/插入状态
        /// </summary>
        /// <param name="data">要添加/插入的状态数据</param>
        /// <param name="insetIndex">新状态要插入的索引,可缺省,默认为-1,状态添加到末尾</param>
        /// <returns>添加/插入状态是否成功</returns>
        public virtual void AddState(T data, int insetIndex = -1)
        {
            if (insetIndex < 0 || insetIndex >= mStateDatas.Count)
                mStateDatas.Add(data);
            else
                mStateDatas.Insert(insetIndex, data);
        }

        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="index">状态索引，可缺省，缺省时移除最后一个状态</param>
        /// <returns>移除状态是否成功</returns>
        public virtual bool RemoveState(int index = -1)
        {
            if (index > mStateDatas.Count - 1)
                return false;

            if (index < 0)
                index = mStateDatas.Count - 1;

            mStateDatas.RemoveAt(index);
            return true;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="targetState">状态索引</param>
        /// <param name="force">是否强制设置状态索引,可缺省,默认为false</param>
        /// <returns>修改状态是否成功</returns>
        public virtual bool SetState(int targetState, bool force = false)
        {
            return true;
        }

        /// <summary>
        /// 获得状态
        /// </summary>
        /// <param name="index">目标状态索引值</param>
        /// <returns>状态数据,可为Null</returns>
        public virtual T? GetState(int index)
        {
            if (mStateDatas.Count == 0)
                return null;
            if (index < 0 || index >= mStateDatas.Count)
                return null;
            return mStateDatas[index];
        }

        /// <summary>
        /// 修改状态数据
        /// </summary>
        /// <param name="index">目标状态索引值</param>
        /// <param name="data">要修改的状态数据</param>
        /// <returns>修改数据状态是否成功</returns>
        public virtual bool ChangeStateData(int index, T data)
        {
            if (mStateDatas.Count == 0)
                return false;

            if (index < 0 || index >= mStateDatas.Count)
                return true;

            mStateDatas[index] = data;
            return true;
        }

        /// <summary>
        /// 清除全部状态
        /// </summary>
        /// <returns>清除状态是否成功</returns>
        public virtual bool ClearState()
        {
            if (mStateDatas == null)
                return false;
            if (mStateDatas.Count == 0)
                return true;

            mStateDatas.Clear();

            return true;
        }

        /// <summary>
        /// 重置为默认状态
        /// </summary>
        /// <returns>重置状态是否成功</returns>
        public virtual bool ResetState()
        {
            if (mDefaultState < 0 || mStateDatas == null || mStateDatas.Count == 0)
                return false;
            SetState(mDefaultState, true);

            return true;
        }

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            Initialize();
            ResetState();
        }

        #endregion
    }
}