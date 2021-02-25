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
    public class KiwiFrameworkCoreKiwiLogWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(KiwiFramework.Core.KiwiLog);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 8, 3, 3);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Info", _m_Info_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InfoFormat", _m_InfoFormat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Warning", _m_Warning_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "WarningFormat", _m_WarningFormat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Error", _m_Error_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ErrorFormat", _m_ErrorFormat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Exception", _m_Exception_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LogEnabled", _g_get_LogEnabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "LogWriteEnabled", _g_get_LogWriteEnabled);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OutputStackTraceEnabled", _g_get_OutputStackTraceEnabled);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LogEnabled", _s_set_LogEnabled);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "LogWriteEnabled", _s_set_LogWriteEnabled);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OutputStackTraceEnabled", _s_set_OutputStackTraceEnabled);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "KiwiFramework.Core.KiwiLog does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Info_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Info( _message );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING))) 
                {
                    string[] _messages = translator.GetParams<string>(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Info( _messages );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Object>(L, 2)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    KiwiFramework.Core.KiwiLog.Info( _message, _context );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 1&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string[] _messages = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.Info( _context, _messages );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.Info!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InfoFormat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    string _format = LuaAPI.lua_tostring(L, 1);
                    string[] _args = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.InfoFormat( _format, _args );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _format = LuaAPI.lua_tostring(L, 2);
                    string[] _args = translator.GetParams<string>(L, 3);
                    
                    KiwiFramework.Core.KiwiLog.InfoFormat( _context, _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.InfoFormat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Warning_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Warning( _message );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING))) 
                {
                    string[] _messages = translator.GetParams<string>(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Warning( _messages );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Object>(L, 2)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    KiwiFramework.Core.KiwiLog.Warning( _message, _context );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 1&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string[] _messages = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.Warning( _context, _messages );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.Warning!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WarningFormat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    string _format = LuaAPI.lua_tostring(L, 1);
                    string[] _args = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.WarningFormat( _format, _args );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _format = LuaAPI.lua_tostring(L, 2);
                    string[] _args = translator.GetParams<string>(L, 3);
                    
                    KiwiFramework.Core.KiwiLog.WarningFormat( _context, _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.WarningFormat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Error_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Error( _message );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 0&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 1) || (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING))) 
                {
                    string[] _messages = translator.GetParams<string>(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Error( _messages );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Object>(L, 2)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    KiwiFramework.Core.KiwiLog.Error( _message, _context );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 1&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string[] _messages = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.Error( _context, _messages );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.Error!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ErrorFormat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count >= 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 2) || (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))) 
                {
                    string _format = LuaAPI.lua_tostring(L, 1);
                    string[] _args = translator.GetParams<string>(L, 2);
                    
                    KiwiFramework.Core.KiwiLog.ErrorFormat( _format, _args );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count >= 2&& translator.Assignable<UnityEngine.Object>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING))) 
                {
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 1, typeof(UnityEngine.Object));
                    string _format = LuaAPI.lua_tostring(L, 2);
                    string[] _args = translator.GetParams<string>(L, 3);
                    
                    KiwiFramework.Core.KiwiLog.ErrorFormat( _context, _format, _args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.ErrorFormat!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Exception_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Exception>(L, 1)) 
                {
                    System.Exception _e = (System.Exception)translator.GetObject(L, 1, typeof(System.Exception));
                    
                    KiwiFramework.Core.KiwiLog.Exception( _e );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    
                    KiwiFramework.Core.KiwiLog.Exception( _message );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Exception>(L, 1)&& translator.Assignable<UnityEngine.Object>(L, 2)) 
                {
                    System.Exception _e = (System.Exception)translator.GetObject(L, 1, typeof(System.Exception));
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    KiwiFramework.Core.KiwiLog.Exception( _e, _context );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Object>(L, 2)) 
                {
                    string _message = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.Object _context = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
                    
                    KiwiFramework.Core.KiwiLog.Exception( _message, _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.KiwiLog.Exception!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LogEnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, KiwiFramework.Core.KiwiLog.LogEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LogWriteEnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, KiwiFramework.Core.KiwiLog.LogWriteEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OutputStackTraceEnabled(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, KiwiFramework.Core.KiwiLog.OutputStackTraceEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LogEnabled(RealStatePtr L)
        {
		    try {
                
			    KiwiFramework.Core.KiwiLog.LogEnabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LogWriteEnabled(RealStatePtr L)
        {
		    try {
                
			    KiwiFramework.Core.KiwiLog.LogWriteEnabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OutputStackTraceEnabled(RealStatePtr L)
        {
		    try {
                
			    KiwiFramework.Core.KiwiLog.OutputStackTraceEnabled = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
