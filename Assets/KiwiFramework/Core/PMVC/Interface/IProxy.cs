namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 代理接口
    /// </summary>
    public interface IProxy
    {
        /// <summary>
        /// 注册代理时调用
        /// </summary>
        void OnRegister();

        /// <summary>
        /// 移除代理是调用
        /// </summary>
        void OnRemove();
    }
}