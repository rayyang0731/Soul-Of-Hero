using System.Collections.Generic;
using System.Linq;
using KiwiFramework.Core;
using KiwiFramework.Core.Interface;
using Sirenix.OdinInspector;
using Sirenix.Utilities;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 界面基类
    /// </summary>
    [HideMonoScript]
    public abstract class BaseView : ViewMonoBehaviour
    {
        #region Framework

        #region Command

        /// <summary>
        /// 注册指令监听
        /// </summary>
        protected virtual void RegisterCommands()
        {
        }

        /// <summary>
        /// 注销指令监听
        /// </summary>
        protected virtual void UnregisterCommands()
        {
        }

        #endregion

        #region Elements

        private readonly List<string> _elements = new List<string>();

        /// <summary>
        /// 创建 Element
        /// </summary>
        /// <param name="elementTag">Element 标签</param>
        /// <typeparam name="TE">Element 类型</typeparam>
        /// <returns>被创建的 Element 对象</returns>
        protected TE CreateElement<TE>(string elementTag) where TE : Element, new()
        {
            var element = new TE();
            element.SetName(elementTag);

            return element;
        }

        /// <summary>
        /// 添加 Element
        /// </summary>
        protected void AddElement<TE>(TE element) where TE : Element, new()
        {
            if (AppFacade.Instance.IsExistMediator(element))
            {
                KiwiLog.InfoFormat("[{0}] Element 已经存在,返回已经存在的 Element.", element.Name);
                return;
            }

            AppFacade.Instance.RegisterMediator(element);
            _elements.Add(element.Name);
        }

        /// <summary>
        /// 移除全部 Element
        /// </summary>
        private void RemoveAllElements()
        {
            foreach (var element in _elements)
            {
                AppFacade.Instance.RemoveMediator(element);
            }

            _elements.Clear();
        }

        /// <summary>
        /// 注册 Elements
        /// </summary>
        protected virtual void RegisterElements()
        {
        }

        #endregion

        #endregion

        #region View Public Methods

        /// <summary>
        /// 打开其他界面
        /// <para>用于打开其他界面,把此界面压入回退栈中</para>
        /// </summary>
        /// <param name="viewName">要打开的界面名称</param>
        public void OpenOtherView(string viewName)
        {
            ViewManager.Instance.OpenView(viewName);
        }

        /// <summary>
        /// 打开子界面
        /// <para>打开一个指定名称的界面作为此界面的子界面</para>
        /// <para>当调用此界面的 OnViewResume,OnViewShow,OnViewHide 方法时,同时调用子界面的这些方法</para>
        /// <para>在关闭此界面时,会先关闭子界面,再关闭自己</para>
        /// </summary>
        /// <param name="viewName">要打开的界面名称</param>
        public void OpenChildView(string viewName)
        {
            var childView = ViewManager.Instance.OpenView(viewName);
            ChildViews.Add(viewName, childView);
        }

        /// <summary>
        /// 剥离子界面
        /// </summary>
        /// <param name="viewName">要剥离的界面名称</param>
        public void DetachChildView(string viewName)
        {
            if (ChildViews.ContainsKey(viewName))
                ChildViews.Remove(viewName);
        }

        /// <summary>
        /// 拉起界面
        /// </summary>
        public void Resume()
        {
            OnViewResume();
            ChildViews.ForEach(view => view.Value.Resume());
        }

        /// <summary>
        /// 显示界面
        /// </summary>
        public void Show()
        {
            OnViewShow();
            ChildViews.ForEach(view => view.Value.Show());
        }

        /// <summary>
        /// 隐藏界面
        /// </summary>
        public void Hide()
        {
            OnViewHide();
            ChildViews.ForEach(view => view.Value.Hide());
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        public void Close()
        {
            UnregisterCommands();
            RemoveAllElements();

            OnViewClosed();
        }

        #endregion

        #region View Lifecycle Methods

        /// <summary>
        /// 当界面被创建
        /// <para>相当于MonoBehaviour.Awake</para>
        /// <para>只操作数据,不操作界面中的对象</para>
        /// </summary>
        protected virtual void OnViewCreated()
        {
        }

        /// <summary>
        /// 当界面实例化完成
        /// <para>相当于 MonoBehaviour.Start</para>
        /// </summary>
        protected virtual void OnViewOpened()
        {
        }

        /// <summary>
        /// 界面Update
        /// <para>相当于 MonoBehaviour.Update</para>
        /// </summary>
        protected virtual void OnViewUpdate()
        {
        }

        /// <summary>
        /// 界面 LateUpdate
        /// <para>相当于 MonoBehaviour.LateUpdate</para>
        /// </summary>
        protected virtual void OnViewLateUpdate()
        {
        }

        /// <summary>
        /// 当界面关闭
        /// </summary>
        protected virtual void OnViewClosed()
        {
        }

        /// <summary>
        /// 当界面被删除
        /// 相当于 MonoBehaviour.OnDestroy
        /// </summary>
        protected virtual void OnViewDestroyed()
        {
        }

        /// <summary>
        /// 当界面被拉起
        /// <para>当从其他界面回到本界面或再次打开本界面时调用</para>
        /// </summary>
        protected virtual void OnViewResume()
        {
        }

        /// <summary>
        /// 当界面显示时调用
        /// </summary>
        protected virtual void OnViewShow()
        {
        }

        /// <summary>
        /// 当界面隐藏时调用
        /// </summary>
        protected virtual void OnViewHide()
        {
        }

        #endregion

        #region Unity Lifecycle Methods

        protected sealed override void OnAwake()
        {
            OnViewCreated();
        }

        protected void Start()
        {
            OnViewOpened();
            RegisterCommands();
            RegisterElements();
        }

        public sealed override void OnUpdate()
        {
            OnViewUpdate();
        }

        public sealed override void OnLateUpdate()
        {
            OnViewLateUpdate();
        }

        protected sealed override void OnDestroyed()
        {
            OnViewDestroyed();
        }

        #endregion
    }
}