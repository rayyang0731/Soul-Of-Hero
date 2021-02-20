using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 通知者
    /// </summary>
    public abstract class Notifier : INotifier
    {
        protected IFacade Facade { get; } = AppFacade.Instance;

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="body">消息体</param>
        public void SendNotify(string msgCode, object body = null)
        {
            Facade.SendNotify(msgCode, body);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="notice">消息数据</param>
        public void SendNotify(INotice notice)
        {
            Facade.SendNotify(notice);
        }
    }
}