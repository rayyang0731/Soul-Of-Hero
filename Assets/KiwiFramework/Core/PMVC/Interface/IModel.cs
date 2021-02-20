using System;

namespace KiwiFramework.Core.Interface
{
    /// <summary>
    /// 数据模型接口
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// 注册代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        void RegisterProxy(IProxy proxy);

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>代理对象</returns>
        T GetProxy<T>() where T : class, IProxy;

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns>代理对象</returns>
        IProxy GetProxy(Type type);

        /// <summary>
        /// 尝试获取代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>是否获取代理成功</returns>
        bool TryGetProxy<T>(out T proxy) where T : class, IProxy;

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>是否移除代理成功</returns>
        bool RemoveProxy<T>() where T : class, IProxy;

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns>是否移除代理成功</returns>
        bool RemoveProxy(Type type);

        /// <summary>
        /// 移除全部代理
        /// </summary>
        void RemoveAllProxy();
    }
}