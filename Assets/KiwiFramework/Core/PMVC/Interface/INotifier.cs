namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 消息发送器接口
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="body">消息体</param>
        void SendNotify(string msgCode, object body = null);
    }
}