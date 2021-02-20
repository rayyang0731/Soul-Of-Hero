namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// 通知观察者
        /// </summary>
        /// <param name="notice">消息数据</param>
        void NotifyObserver(INotice notice);
    }
}