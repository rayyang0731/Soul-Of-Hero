namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 消息结构接口
    /// </summary>
    public interface INotice
    {
        /// <summary>
        /// 消息号
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 消息体
        /// </summary>
        object Body { get; set; }

        /// <summary>
        /// 尝试获取消息体
        /// </summary>
        /// <param name="body">消息体对象</param>
        /// <typeparam name="T">消息体类型</typeparam>
        /// <returns>是否成功获取到消息体</returns>
        bool TryGetBody<T>(out T body) where T : class;

        /// <summary>
        /// 获取消息体
        /// </summary>
        /// <typeparam name="T">消息体类型</typeparam>
        /// <returns>消息体对象</returns>
        T GetBody<T>();
    }
}