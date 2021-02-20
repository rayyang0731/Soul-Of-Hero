using System;
using System.Collections.Generic;
using KiwiFramework.Core.Interface;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 控制层管理器
    /// </summary>
    public class Controller : Singleton<Controller>, IController
    {
        /// <summary>
        /// 指令字典
        /// </summary>
        private readonly Dictionary<string, Type> _commandMap = new Dictionary<string, Type>();

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <typeparam name="T">指令类型</typeparam>
        public void RegisterCommand<T>(string commandTag) where T : ICommand
        {
            RegisterCommand(commandTag, typeof(T));
        }

        /// <summary>
        /// 注册指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        /// <param name="commandType">指令类型</param>
        public void RegisterCommand(string commandTag, Type commandType)
        {
            if (!_commandMap.ContainsKey(commandTag))
            {
                _commandMap.Add(commandTag, commandType);
                return;
            }

            _commandMap[commandTag] = commandType;
        }

        /// <summary>
        /// 执行指令
        /// </summary>
        /// <param name="notice">消息数据</param>
        public void ExecuteCommand(INotice notice)
        {
            if (!_commandMap.TryGetValue(notice.Name, out var commandType)) return;

            if (Activator.CreateInstance(commandType) is ICommand command)
                command.Execute(notice);
        }

        /// <summary>
        /// 移除指令
        /// </summary>
        /// <param name="commandTag">指令标签</param>
        public void RemoveCommand(string commandTag)
        {
            if (_commandMap.ContainsKey(commandTag))
                _commandMap.Remove(commandTag);
        }

        /// <summary>
        /// 移除全部指令
        /// </summary>
        public void RemoveAllCommand()
        {
            _commandMap.Clear();
        }
    }
}