using System;
using KiwiFramework.Core.Interface;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 全局通知系统
    /// </summary>
    public static class NotifySystem
    {
        /// <summary>
        /// 通知中心
        /// </summary>
        private static readonly NotifyCenter<string, INotice> Center = new NotifyCenter<string, INotice>();

        /// <summary>
        /// 发送通知
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="notice">消息数据</param>
        public static void Send(string msgCode, INotice notice)
        {
            Center.Send(msgCode, notice);
        }

        /// <summary>
        /// 添加通知监听
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="function">通知执行事件</param>
        public static void AddListener(string msgCode, Action<INotice> function)
        {
            Center.Listen(msgCode, function);
        }

        /// <summary>
        /// 移除通知监听
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="function">通知执行事件</param>
        public static void RemoveListener(string msgCode, Action<INotice> function)
        {
            Center.RemoveListen(msgCode, function);
        }

        /// <summary>
        /// 移除所有监听
        /// </summary>
        /// <param name="msgCode">消息号</param>
        public static void RemoveAllListeners(string msgCode)
        {
            Center.RemoveCommand(msgCode);
        }

        /// <summary>
        /// 清除所有监听
        /// </summary>
        public static void ClearAll()
        {
            Center.ClearAll();
        }
    }
}