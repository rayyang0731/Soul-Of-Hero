using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 数据模型[Model] 代理
    /// 主要负责：数据的收发
    /// </summary>
    public abstract class Proxy : Notifier, IProxy
    {
        /// <summary>
        /// 注册时调用
        /// </summary>
        public abstract void OnRegister();

        /// <summary>
        /// 移除时调用
        /// </summary>
        public abstract void OnRemove();
    }
}