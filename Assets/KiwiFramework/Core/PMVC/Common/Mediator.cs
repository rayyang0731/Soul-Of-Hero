using System;
using System.Collections.Generic;
using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /// <summary>
    /// View 中介器
    /// 主要职责：
    ///     负责处理 ViewComponent 派发的事件和系统其他部分发出来的通知
    /// </summary>
    public abstract class Mediator : Notifier, IMediator
    {
        /// <summary>
        /// 监听方法
        /// </summary>
        private class ObserveMethod
        {
            public string Name { get; }
            public Action<INotice> Method { get; set; }

            public ObserveMethod(string name, Action<INotice> action)
            {
                Name = name;
                Method = action;
            }
        }

        public string Name { get; private set; }

        /// <summary>
        /// 监听列表
        /// </summary>
        private List<ObserveMethod> _observeList;

        /// <summary>
        /// 设置中介器名称
        /// </summary>
        /// <param name="name">中介器名称</param>
        internal void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 加载时调用
        /// </summary>
        protected abstract void OnLoad();

        /// <summary>
        /// 卸载时调用
        /// </summary>
        protected abstract void OnUnload();

        /// <summary>
        /// 注册时调用
        /// </summary>
        public virtual void OnRegister()
        {
            OnLoad();
        }

        /// <summary>
        /// 移除时调用
        /// </summary>
        public virtual void OnRemove()
        {
            OnUnload();
            RemoveAllListens();
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="msgCode">消息号</param>
        /// <param name="function">消息数据</param>
        public void AddListener(string msgCode, Action<INotice> function)
        {
            if (_observeList == null)
                _observeList = new List<ObserveMethod>();

            var observe = _observeList.Find(om => om.Name == msgCode);

            if (observe == null)
            {
                // 新添加一个监听
                observe = new ObserveMethod(msgCode, function);
                _observeList.Add(observe);
            }
            else
            {
                // 移除旧的监听
                NotifySystem.RemoveListener(msgCode, observe.Method);
                // 设置新的监听
                observe.Method = function;
            }

            // 开始监听
            NotifySystem.AddListener(msgCode, observe.Method);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="msgCode">消息号</param>
        private void RemoveListener(string msgCode)
        {
            var observe = _observeList?.Find(om => om.Name == msgCode);

            if (observe == null) return;

            // 移除旧的监听
            NotifySystem.RemoveListener(msgCode, observe.Method);
            // 移除
            _observeList.Remove(observe);
        }

        /// <summary>
        /// 移除本次注册的所有监听
        /// </summary>
        public void RemoveAllListens()
        {
            if (_observeList == null) return;

            for (int i = 0, count = _observeList.Count; i < count; i++)
            {
                var observe = _observeList[i];

                if (observe != null)
                {
                    // 移除旧的监听
                    NotifySystem.RemoveListener(observe.Name, observe.Method);
                }
            }

            _observeList.Clear();
            _observeList = null;
        }
    }
}