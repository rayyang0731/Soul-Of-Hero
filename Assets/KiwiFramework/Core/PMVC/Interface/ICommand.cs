namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 指令接口
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="notice">消息数据</param>
        void Execute(INotice notice);
    }
}