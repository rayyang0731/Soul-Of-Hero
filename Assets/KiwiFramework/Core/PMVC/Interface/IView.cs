namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 视图接口
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 注册中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        void RegisterMediator(IMediator mediator);

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns>中介器对象</returns>
        IMediator GetMediator(string mediatorTag);

        /// <summary>
        /// 获取中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <typeparam name="T">中介器类型</typeparam>
        /// <returns>中介器对象</returns>
        T GetMediator<T>(string mediatorTag) where T : class, IMediator;

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        void RemoveMediator(string mediatorTag);

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        void RemoveMediator(IMediator mediator);

        /// <summary>
        /// 移除全部中介器
        /// </summary>
        void RemoveAllMediator();
    }
}