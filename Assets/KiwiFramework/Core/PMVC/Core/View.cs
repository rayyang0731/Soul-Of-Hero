using System;
using System.Collections.Generic;
using KiwiFramework.Core;
using KiwiFramework.Core.Interface;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 视图层管理器
    /// </summary>
    public class View : Singleton<View>, IView
    {
        /// <summary>
        /// 中介器字典
        /// </summary>
        private readonly IDictionary<string, IMediator> _mediatorMap = new Dictionary<string, IMediator>();

        /// <summary>
        /// 注册中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        /// <exception cref="Exception">要注册的中介器不可为Null</exception>
        public void RegisterMediator(IMediator mediator)
        {
            if (mediator == null)
                throw new Exception("Can't register a Null Mediator.");

            var name = mediator.Name;

            if (_mediatorMap.ContainsKey(name)) return;
            _mediatorMap[name] = mediator;

            mediator.OnRegister();
        }

        /// <summary>
        /// 获得中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns>中介器对象</returns>
        public IMediator GetMediator(string mediatorTag)
        {
            if (!_mediatorMap.TryGetValue(mediatorTag, out var mediator))
                KiwiLog.ErrorFormat("[{0}]还未注册过.", mediatorTag);
            return mediator;
        }

        /// <summary>
        /// 获得中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <typeparam name="T">中介器类型</typeparam>
        /// <returns>中介器对象</returns>
        public T GetMediator<T>(string mediatorTag) where T : class, IMediator
        {
            return GetMediator(mediatorTag) as T;
        }

        /// <summary>
        /// 中介器是否已经被注册过
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        /// <returns>中介器对象是否已经被注册</returns>
        public bool IsExist(IMediator mediator)
        {
            return mediator != null && _mediatorMap.ContainsKey(mediator.Name);
        }

        /// <summary>
        /// 中介器是否已经被注册过
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        /// <returns>中介器对象是否已经被注册</returns>
        public bool IsExist(string mediatorTag)
        {
            return _mediatorMap.ContainsKey(mediatorTag);
        }

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediatorTag">中介器标签</param>
        public void RemoveMediator(string mediatorTag)
        {
            if (!_mediatorMap.ContainsKey(mediatorTag)) return;
            _mediatorMap[mediatorTag].OnRemove();

            _mediatorMap.Remove(mediatorTag);
        }

        /// <summary>
        /// 移除中介器
        /// </summary>
        /// <param name="mediator">中介器对象</param>
        public void RemoveMediator(IMediator mediator)
        {
            RemoveMediator(mediator.Name);
        }

        /// <summary>
        /// 移除全部中介器
        /// </summary>
        public void RemoveAllMediator()
        {
            foreach (var item in _mediatorMap)
            {
                item.Value.OnRemove();
            }

            _mediatorMap.Clear();
        }
    }
}