using System;
using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    public class Facade<T> : Singleton<T>, IFacade where T : Singleton<T>
    {
        #region Command

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <typeparam name="TC">指令类型</typeparam>
        public void RegisterCommand<TC>(string commandTag) where TC : ICommand
        {
            KiwiLog.InfoFormat("Register command: {0}", commandTag);
            Controller.Instance.RegisterCommand(commandTag, typeof(TC));
        }

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <param name="commandType">指令类型</param>
        public void RegisterCommand(string commandTag, Type commandType)
        {
            KiwiLog.InfoFormat("Register command: {0}", commandTag);
            Controller.Instance.RegisterCommand(commandTag, commandType);
        }

        /// <summary>
        /// 移除指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        public void RemoveCommand(string commandTag)
        {
            Controller.Instance.RemoveCommand(commandTag);
            KiwiLog.InfoFormat("Remove command: {0}", commandTag);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="body">消息体</param>
        public void ExecuteCommand(string msgCode, object body = null)
        {
            var notice = new Notice(msgCode, body);
            ExecuteCommand(notice);
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="notice">消息数据</param>
        public void ExecuteCommand(INotice notice)
        {
            KiwiLog.InfoFormat("Execute command: {0}", notice.Name);
            Controller.Instance.ExecuteCommand(notice);
        }

        #endregion

        #region Proxy

        /// <summary>
        /// 注册代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        public void RegisterProxy(IProxy proxy)
        {
            KiwiLog.InfoFormat("Register proxy: {0}", proxy.ToString());
            Model.Instance.RegisterProxy(proxy);
        }

        /// <summary>
        /// 尝试获取代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <typeparam name="TP">代理类型</typeparam>
        /// <returns>是否成功获取代理</returns>
        public bool TryGetProxy<TP>(out TP proxy) where TP : class, IProxy
        {
            return Model.Instance.TryGetProxy(out proxy);
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns>代理对象</returns>
        public IProxy GetProxy(Type type)
        {
            return Model.Instance.GetProxy(type);
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <typeparam name="TP">代理类型</typeparam>
        /// <returns>代理对象</returns>
        public TP GetProxy<TP>() where TP : class, IProxy
        {
            return Model.Instance.GetProxy<TP>();
        }

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <typeparam name="TP">代理类型</typeparam>
        public void RemoveProxy<TP>() where TP : class, IProxy
        {
            Model.Instance.RemoveProxy(typeof(TP));
        }

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <param name="type">代理类型</param>
        public void RemoveProxy(Type type)
        {
            KiwiLog.InfoFormat("Remove proxy: {0}", type.Name);
            Model.Instance.RemoveProxy(type);
        }

        #endregion

        #region Mediator

        /// <summary>
        /// 注册中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        public void RegisterMediator(IMediator mediator)
        {
            KiwiLog.InfoFormat("Register mediator: {0}", mediator.Name);
            View.Instance.RegisterMediator(mediator);
        }

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns></returns>
        public IMediator GetMediator(string mediatorTag)
        {
            return View.Instance.GetMediator(mediatorTag);
        }

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <typeparam name="TM">中介器类型</typeparam>
        /// <returns>中介器对象</returns>
        public TM GetMediator<TM>(string mediatorTag) where TM : class, IMediator
        {
            return View.Instance.GetMediator<TM>(mediatorTag);
        }

        /// <summary>
        /// 中介器是否已经被注册过
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        /// <returns>中介器对象是否已经被注册</returns>
        public bool IsExistMediator(IMediator mediator)
        {
            return View.Instance.IsExist(mediator.Name);
        }

        /// <summary>
        /// 中介器是否已经被注册过
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns>中介器对象是否已经被注册</returns>
        public bool IsExistMediator(string mediatorTag)
        {
            return View.Instance.IsExist(mediatorTag);
        }

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        public void RemoveMediator(string mediatorTag)
        {
            KiwiLog.InfoFormat("Remove mediator: {0}", mediatorTag);
            View.Instance.RemoveMediator(mediatorTag);
        }

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        public void RemoveMediator(IMediator mediator)
        {
            KiwiLog.InfoFormat("Remove mediator: {0}", mediator.Name);
            View.Instance.RemoveMediator(mediator);
        }

        #endregion

        /// <summary>
        /// 发送通知
        /// </summary>
        public void SendNotify(INotice notice)
        {
            KiwiLog.InfoFormat("Send notify: {0}", notice.Name);
            ExecuteCommand(notice);
            NotifySystem.Send(notice.Name, notice);
        }

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <param name="msgCode">消息</param>
        /// <param name="body">参数</param>
        public void SendNotify(string msgCode, object body = null)
        {
            SendNotify(new Notice(msgCode, body));
        }

        /// <summary>
        /// 清理释放
        /// </summary>
        public void ClearApp()
        {
            Model.Instance.RemoveAllProxy();
            Controller.Instance.RemoveAllCommand();
            View.Instance.RemoveAllMediator();

            NotifySystem.ClearAll();
        }
    }
}