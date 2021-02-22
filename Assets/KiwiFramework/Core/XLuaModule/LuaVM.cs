using System;
using System.Collections.Generic;
using System.IO;
using KiwiFramework.Core;
using KiwiFramework.Core.Interface;
using UnityEngine;
using XLua;


/// <summary>
/// Lua 虚拟机管理器
/// </summary>
[LuaCallCSharp]
public class LuaVM : Singleton<LuaVM>, IUpdate
{
    private readonly LuaEnv _luaEnv;

    /// <summary>
    /// Lua GC 间隔时间
    /// </summary>
    private const float GCTimeGap = 15f;

    /// <summary>
    /// Lua GC 计时器
    /// </summary>
    private Timer GCTimer;

    private LuaVM()
    {
        _luaEnv = new LuaEnv();

        _luaEnv.AddLoader(OnLoader);
        //初始化 GC 回收 Tick
        GCTimer = Timer.Startup(GCTimeGap, timer => { _luaEnv.Tick(); }, loop: true, ignoreTimeScale: true);
    }

    ~LuaVM()
    {
        GCTimer.Stop();
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
    /// 当有lua文件require时
    /// </summary>
    private byte[] OnLoader(ref string filepath)
    {
        filepath = LuaDir(filepath);
        LuaLoader(filepath, out var lua);

        return !string.IsNullOrEmpty(lua) ? System.Text.Encoding.UTF8.GetBytes(lua) : null;
    }

    /// <summary>
    /// lua path
    /// </summary>
    private string LuaDir(string fileName)
    {
        return string.Format("Luas/{0}.lua", fileName);
    }

    /// <summary>
    /// lua 加载器
    /// </summary>
    public bool LuaLoader(string path, out string lua)
    {
#if UNITY_EDITOR
        if (Config.IsSimulationMode)
        {
            path = Path.Combine(Application.dataPath, path);

            Debug.Log(path);

            if (File.Exists(path))
            {
                lua = File.ReadAllText(path);
                return true;
            }
            else
                Debug.LogError("加载lua失败，path：" + path);
        }
        else
        {
            TextAsset ta = AssetLoader.Load<TextAsset>(path.ToLower(), AssetType.TXT);

            if (ta != null)
            {
                lua = ta.text;
                return true;
            }
            else
            {
                Debug.LogError("加载lua失败，path：" + path);
            }
        }

#else //加载bundle
        TextAsset ta = AssetLoader.Load<TextAsset>(path.ToLower(), AssetType.TXT);

        if(ta != null)
        {
            lua = ta.text;
            return true;
        }
        else
        {
            Debug.LogError("加载lua失败，path：" + path);
        }
#endif
        lua = string.Empty;
        return false;
    }

    public LuaTable NewScript()
    {
        LuaTable script = _luaEnv.NewTable();

        LuaTable meta = _luaEnv.NewTable();
        meta.Set("__index", _luaEnv.Global);
        script.SetMetaTable(meta);
        meta.Dispose();

        return script;
    }

    public void DoString(string lua, string chunk, LuaTable env)
    {
        _luaEnv.DoString(lua, chunk, env);
    }
}