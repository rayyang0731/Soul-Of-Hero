using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 消息结构
    /// </summary>
    public class Notice : INotice
    {
        /// <summary>
        /// 消息号
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 消息体
        /// </summary>
        public object Body { get; set; }

        public Notice(string name, object body = null)
        {
            Name = name;
            Body = body;
        }

        /// <summary>
        /// 尝试获取消息体
        /// </summary>
        /// <param name="body">消息体对象</param>
        /// <typeparam name="T">消息体类型</typeparam>
        /// <returns>是否成功获取消息对象</returns>
        public bool TryGetBody<T>(out T body) where T : class
        {
            body = Body as T;
            return body != null;
        }

        /// <summary>
        /// 获取消息体
        /// </summary>
        /// <typeparam name="T">消息体类型</typeparam>
        /// <returns>消息体对象</returns>
        public T GetBody<T>()
        {
            return (T) Body;
        }
    }
}