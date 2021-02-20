namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 控制器接口
    /// </summary>
    public interface IController
    {
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
        void RegisterCommand(string commandTag, System.Type commandType);

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="notice">消息数据</param>
        void ExecuteCommand(INotice notice);

        /// <summary>
        /// 移除指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        void RemoveCommand(string commandTag);

        /// <summary>
        /// 移除全部指令
        /// </summary>
        void RemoveAllCommand();
    }
}