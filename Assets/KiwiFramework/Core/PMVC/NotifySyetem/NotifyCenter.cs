using System;
using System.Collections;
using System.Collections.Generic;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 通知中心,用键值存储单参数的委托
    /// </summary>
    /// <typeparam name="TK">键类型</typeparam>
    /// <typeparam name="T">委托参数类型</typeparam>
    public class NotifyCenter<TK, T>
    {
        /// <summary>
        /// 通知字典
        /// </summary>
        private readonly Dictionary<TK, Action<T>> _notifiesMap;

        public NotifyCenter()
        {
            _notifiesMap = new Dictionary<TK, Action<T>>();
        }

        /// <summary>
        /// 当前被注册的通知数量
        /// </summary>
        public int Count => _notifiesMap.Count;

        /// <summary>
        /// 已有注册命令
        /// </summary>
        public ICollection<TK> Commands => _notifiesMap.Keys;

        /// <summary>
        /// 监听这个命令，可以多个事件监听同一条命令
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="function">通知事件</param>
        public void Listen(TK command, Action<T> function)
        {
            if (!_notifiesMap.ContainsKey(command))
                _notifiesMap.Add(command, function);
            else
                _notifiesMap[command] += function;
        }

        /// <summary>
        /// 移除命令下的某个监听，不会移除此命令下的其他监听
        /// </summary>
        /// <param name="command">指令对象</param>
        /// <param name="function">移除的事件</param>
        public void RemoveListen(TK command, Action<T> function)
        {
            if (function == null) return;

            if (!_notifiesMap.ContainsKey(command)) return;

            _notifiesMap[command] -= function;

            if (_notifiesMap[command] == null)
                _notifiesMap.Remove(command);
        }

        /// <summary>
        /// 移除整个命令,包含此条命令的所有监听.
        /// </summary>
        /// <param name="command">指令对象</param>
        /// <returns>是否移除成功</returns>
        public bool RemoveCommand(TK command)
        {
            if (!_notifiesMap.ContainsKey(command)) return false;

            _notifiesMap.Remove(command);
            return true;
        }

        /// <summary>
        /// 给该命令下的所有监听发送通知
        /// </summary>
        /// <param name="command">指令对象</param>
        /// <param name="param">参数</param>
        public void Send(TK command, T param)
        {
            if (_notifiesMap.TryGetValue(command, out var notifier))
            {
                notifier.Invoke(param);
            }
        }

        /// <summary>
        /// 清除所有命令、监听
        /// </summary>
        public void ClearAll()
        {
            _notifiesMap.Clear();
        }
    }
}