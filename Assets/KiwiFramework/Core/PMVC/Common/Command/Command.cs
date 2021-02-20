using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /// <summary>
    /// Controller 指令
    /// </summary>
    public abstract class Command : Notifier, ICommand
    {
        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="notice">消息数据</param>
        public abstract void Execute(INotice notice);
    }
}