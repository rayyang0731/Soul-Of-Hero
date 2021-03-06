using System;
using XLua;

namespace KiwiFramework.Core.XLuaModule
{
    public class LuaBaseView : BaseView
    {
        private string _tableName;

        private Action _luaRegisterCommands;
        private Action _luaUnregisterCommands;

        private Action _luaRegisterElements;

        private Action _luaOnViewOpened;
        private Action _luaOnViewUpdate;
        private Action _luaOnViewLateUpdate;
        private Action _luaOnViewClosed;
        private Action _luaOnViewDestroyed;
        private Action _luaOnViewResume;

        private Action _luaOnViewShow;
        private Action _luaOnViewHide;

        private LuaTable _luaScript;

        public void Bind(string tableName, LuaTable luaScript)
        {
            _tableName = tableName;

            _luaScript = luaScript;
            luaScript.Set("view", this);

            _luaScript.Get("RegisterCommands", out _luaRegisterCommands);
            _luaScript.Get("UnregisterCommands", out _luaUnregisterCommands);

            _luaScript.Get("RegisterElements", out _luaRegisterElements);

            _luaScript.Get("OnViewOpened", out _luaOnViewOpened);
            _luaScript.Get("OnViewUpdate", out _luaOnViewUpdate);
            _luaScript.Get("OnViewLateUpdate", out _luaOnViewLateUpdate);
            _luaScript.Get("OnViewClosed", out _luaOnViewClosed);
            _luaScript.Get("OnViewDestroyed", out _luaOnViewDestroyed);
            _luaScript.Get("OnViewResume", out _luaOnViewResume);

            _luaScript.Get("OnViewShow", out _luaOnViewShow);
            _luaScript.Get("OnViewHide", out _luaOnViewHide);
        }

        /// <summary>
        /// 注册指令监听
        /// </summary>
        protected override void RegisterCommands()
        {
            _luaRegisterCommands?.Invoke();
        }

        /// <summary>
        /// 注销指令监听
        /// </summary>
        protected override void UnregisterCommands()
        {
            _luaUnregisterCommands?.Invoke();
        }
    }
}