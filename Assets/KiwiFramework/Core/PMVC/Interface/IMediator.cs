namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 中介器接口
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// 获取中介器标签
        /// </summary>
        /// <returns></returns>
        string Name { get; }

        /// <summary>
        /// 注册时调用
        /// </summary>
        void OnRegister();

        /// <summary>
        /// 移除时调用
        /// </summary>
        void OnRemove();
    }
}