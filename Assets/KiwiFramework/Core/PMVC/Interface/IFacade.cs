using System;

namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 外观接口
    /// </summary>
    public interface IFacade
    {
        #region Proxy 代理

        /// <summary>
        /// 注册代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 尝试获取代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <typeparam name="T">代理对象类型</typeparam>
        /// <returns>是否获取成功</returns>
        bool TryGetProxy<T>(out T proxy) where T : class, IProxy;

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>获取到的代理对象</returns>
        T GetProxy<T>() where T : class, IProxy;

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns></returns>
        IProxy GetProxy(Type type);

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <typeparam name="T">代理类型</typeparam>
        void RemoveProxy<T>() where T : class, IProxy;

        #endregion

        #region Command 指令

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <typeparam name="T">指令类型</typeparam>
        void RegisterCommand<T>(string commandTag) where T : ICommand;

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <param name="commandType">指令类型</param>
        void RegisterCommand(string commandTag, Type commandType);

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="body">消息体</param>
        void ExecuteCommand(string msgCode, object body = null);

        /// <summary>
        /// 移除指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        void RemoveCommand(string commandTag);

        #endregion

        #region Mediator 中介器

        /// <summary>
        /// 注册中介器
        /// </summary>
        /// <param name="mediator">中介器数据</param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns>中介器对象</returns>
        IMediator GetMediator(string mediatorTag);

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <typeparam name="T">中介器类型</typeparam>
        /// <returns>中介器对象</returns>
        T GetMediator<T>(string mediatorTag) where T : class, IMediator;

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        void RemoveMediator(string mediatorTag);

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        void RemoveMediator(IMediator mediator);

        #endregion

        #region Notice 消息通知

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="notice">消息数据</param>
        void SendNotify(INotice notice);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="body">消息体</param>
        void SendNotify(string msgCode, object body = null);

        #endregion

        /// <summary>
        /// 清理释放
        /// </summary>
        void ClearApp();
    }
}