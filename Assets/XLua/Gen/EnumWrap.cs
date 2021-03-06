#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    
    public class UnityEngineSceneManagementLoadSceneModeWrap
    {
		public static void __Register(RealStatePtr L)
        {
		    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
		    Utils.BeginObjectRegister(typeof(UnityEngine.SceneManagement.LoadSceneMode), L, translator, 0, 0, 0, 0);
			Utils.EndObjectRegister(typeof(UnityEngine.SceneManagement.LoadSceneMode), L, translator, null, null, null, null, null);
			
			Utils.BeginClassRegister(typeof(UnityEngine.SceneManagement.LoadSceneMode), L, null, 3, 0, 0);

            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Single", UnityEngine.SceneManagement.LoadSceneMode.Single);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Additive", UnityEngine.SceneManagement.LoadSceneMode.Additive);
            

			Utils.RegisterFunc(L, Utils.CLS_IDX, "__CastFrom", __CastFrom);
            
            Utils.EndClassRegister(typeof(UnityEngine.SceneManagement.LoadSceneMode), L, translator);
        }
		
		[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CastFrom(RealStatePtr L)
		{
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			LuaTypes lua_type = LuaAPI.lua_type(L, 1);
            if (lua_type == LuaTypes.LUA_TNUMBER)
            {
                translator.PushUnityEngineSceneManagementLoadSceneMode(L, (UnityEngine.SceneManagement.LoadSceneMode)LuaAPI.xlua_tointeger(L, 1));
            }
			
            else if(lua_type == LuaTypes.LUA_TSTRING)
            {

			    if (LuaAPI.xlua_is_eq_str(L, 1, "Single"))
                {
                    translator.PushUnityEngineSceneManagementLoadSceneMode(L, UnityEngine.SceneManagement.LoadSceneMode.Single);
                }
				else if (LuaAPI.xlua_is_eq_str(L, 1, "Additive"))
                {
                    translator.PushUnityEngineSceneManagementLoadSceneMode(L, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                }
				else
                {
                    return LuaAPI.luaL_error(L, "invalid string for UnityEngine.SceneManagement.LoadSceneMode!");
                }

            }
			
            else
            {
                return LuaAPI.luaL_error(L, "invalid lua type for UnityEngine.SceneManagement.LoadSceneMode! Expect number or string, got + " + lua_type);
            }

            return 1;
		}
	}
    
}