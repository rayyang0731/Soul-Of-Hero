using GameFramework;
using JetBrains.Annotations;
using UnityEngine;
using XLua;

namespace KiwiFramework.Core.XLuaModule
{
    /// <summary>
    /// Lua 虚拟机管理器
    /// </summary>
    public class LuaVM : Singleton<LuaVM>
    {
        private readonly LuaEnv _luaEnv;

        /// <summary>
        /// Lua GC 间隔时间
        /// </summary>
        private const float GcTimeGap = 15f;

        /// <summary>
        /// Lua GC 计时器
        /// </summary>
        private readonly Timer _gcTimer;

        private LuaVM()
        {
            _luaEnv = new LuaEnv();

            _luaEnv.AddLoader(OnLoader);
            //初始化 GC 回收 Tick
            _gcTimer = Timer.Startup(GcTimeGap, timer => { _luaEnv.Tick(); }, loop: true, ignoreTimeScale: true);
        }

        ~LuaVM()
        {
            _gcTimer.Stop();
            _luaEnv.Dispose();
        }

        /// <summary>
        /// 创建 Lua Table
        /// </summary>
        /// <returns>Lua Table 对象</returns>
        public LuaTable CreateTable()
        {
            return _luaEnv.NewTable();
        }

        /// <summary>
        /// 当有lua文件require时调用
        /// </summary>
        /// <param name="luaFileName">Lua 文件名称</param>
        /// <returns></returns>
        private static byte[] OnLoader(ref string luaFileName)
        {
            return LuaLoader(luaFileName, out var lua) ? System.Text.Encoding.UTF8.GetBytes(lua) : null;
        }


        /// <summary>
        /// lua 加载器
        /// </summary>
        private static bool LuaLoader(string luaFileName, out string lua)
        {
            if (luaFileName == "emmy_core")
            {
                lua = null;
                return false;
            }

            var textAsset = AssetManager.Instance.Load<TextAsset>(luaFileName);
            if (textAsset.text != null)
            {
                lua = textAsset.text;
                return true;
            }

            lua = string.Empty;
            return false;
        }

        public LuaTable NewLuaTable()
        {
            var table = _luaEnv.NewTable();
            var metaTable = _luaEnv.NewTable();

            metaTable.Set("__index", _luaEnv.Global);
            table.SetMetaTable(metaTable);

            metaTable.Dispose();

            return table;
        }

        /// <summary>
        /// 加载 Lua 文件
        /// </summary>
        /// <param name="luaName">Lua 文件名称</param>
        /// <param name="luaTable">要对应的 LuaTable 对象</param>
        public void DoFile(string luaName, LuaTable luaTable = null)
        {
            var luaContent = $"require '{luaName}'";
            DoString(luaContent, luaName, luaTable);
        }

        public object[] DoString(string lua, string chunk, LuaTable env)
        {
            return _luaEnv.DoString(lua, chunk, env);
        }
    }
}