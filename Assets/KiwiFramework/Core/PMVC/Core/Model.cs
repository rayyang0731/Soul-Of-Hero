using System;
using System.Collections.Generic;
using KiwiFramework.Core.Interface;
using Sirenix.Utilities;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 数据层管理器
    /// </summary>
    public class Model : Singleton<Model>, IModel
    {
        /// <summary>
        /// 代理字典
        /// </summary>
        private readonly Dictionary<Type, IProxy> _proxyMap = new Dictionary<Type, IProxy>();

        /// <summary>
        /// 注册代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <exception cref="Exception">要注册的代理不可为Null</exception>
        public void RegisterProxy(IProxy proxy)
        {
            if (proxy == null)
                throw new Exception("Can't register a Null Proxy.");

            var type = proxy.GetType();

            if (_proxyMap.ContainsKey(type)) return;
            _proxyMap[type] = proxy;

            proxy.OnRegister();
        }

        /// <summary>
        /// 获得代理
        /// </summary>
        /// <typeparam name="T">代理对象</typeparam>
        /// <returns></returns>
        public T GetProxy<T>() where T : class, IProxy
        {
            var proxy = GetProxy(typeof(T));
            return proxy as T;
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns>代理对象</returns>
        public IProxy GetProxy(Type type)
        {
            if (_proxyMap.TryGetValue(type, out var proxy)) return proxy;

            proxy = Activator.CreateInstance(type) as Proxy;
            RegisterProxy(proxy);

            return proxy;
        }

        /// <summary>
        /// 尝试获得代理
        /// </summary>
        /// <param name="proxy">代理对象</param>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>是否成功获得代理</returns>
        public bool TryGetProxy<T>(out T proxy) where T : class, IProxy
        {
            if (_proxyMap.TryGetValue(typeof(T), out var temp))
            {
                proxy = temp as T;
                return proxy != null;
            }

            proxy = null;
            return false;
        }

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <typeparam name="T">代理类型</typeparam>
        /// <returns>是否成功移除代理</returns>
        public bool RemoveProxy<T>() where T : class, IProxy
        {
            return RemoveProxy(typeof(T));
        }

        /// <summary>
        /// 移除代理
        /// </summary>
        /// <param name="type">代理类型</param>
        /// <returns>是否成功移除</returns>
        public bool RemoveProxy(Type type)
        {
            if (!_proxyMap.ContainsKey(type)) return false;

            _proxyMap[type].OnRemove();
            _proxyMap.Remove(type);
            return true;
        }

        /// <summary>
        /// 移除全部代理
        /// </summary>
        public void RemoveAllProxy()
        {
            _proxyMap.ForEach(item => item.Value.OnRemove());
            _proxyMap.Clear();
        }
    }
}