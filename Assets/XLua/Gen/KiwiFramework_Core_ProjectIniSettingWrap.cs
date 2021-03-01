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
    public class KiwiFrameworkCoreProjectIniSettingWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(KiwiFramework.Core.ProjectIniSetting);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 15, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBool", _m_GetBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetInt", _m_GetInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetLong", _m_GetLong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDouble", _m_GetDouble_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetString", _m_GetString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetBytes", _m_GetBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetDateTime", _m_GetDateTime_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetBool", _m_SetBool_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetInt", _m_SetInt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLong", _m_SetLong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetDouble", _m_SetDouble_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetString", _m_SetString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetBytes", _m_SetBytes_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetDateTime", _m_SetDateTime_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "All", _g_get_All);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "KiwiFramework.Core.ProjectIniSetting does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _defaultValue = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetBool( _sectionName, _key, _defaultValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetBool( _sectionName, _key );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetBool!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    int _defaultValue = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetInt( _sectionName, _key, _defaultValue );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetInt( _sectionName, _key );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetInt!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLong_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) || LuaAPI.lua_isint64(L, 3))) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    long _defaultValue = LuaAPI.lua_toint64(L, 3);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetLong( _sectionName, _key, _defaultValue );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetLong( _sectionName, _key );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetLong!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDouble_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    double _defaultValue = LuaAPI.lua_tonumber(L, 3);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetDouble( _sectionName, _key, _defaultValue );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetDouble( _sectionName, _key );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetDouble!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    string _defaultValue = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetString( _sectionName, _key, _defaultValue );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetString( _sectionName, _key );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetBytes( _sectionName, _key );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    byte[] _returnValue;
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetBytes( _sectionName, _key, out _returnValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushstring(L, _returnValue);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    byte[] _defaultValue = LuaAPI.lua_tobytes(L, 3);
                    byte[] _returnValue;
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetBytes( _sectionName, _key, _defaultValue, out _returnValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushstring(L, _returnValue);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetBytes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDateTime_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetDateTime( _sectionName, _key );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    System.DateTime _returnValue;
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetDateTime( _sectionName, _key, out _returnValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _returnValue);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.DateTime>(L, 3)) 
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    System.DateTime _defaultValue;translator.Get(L, 3, out _defaultValue);
                    System.DateTime _returnValue;
                    
                        var gen_ret = KiwiFramework.Core.ProjectIniSetting.GetDateTime( _sectionName, _key, _defaultValue, out _returnValue );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _returnValue);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ProjectIniSetting.GetDateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBool_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    bool _value = LuaAPI.lua_toboolean(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetBool( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetInt_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    int _value = LuaAPI.xlua_tointeger(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetInt( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLong_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    long _value = LuaAPI.lua_toint64(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetLong( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDouble_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    double _value = LuaAPI.lua_tonumber(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetDouble( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    string _value = LuaAPI.lua_tostring(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetString( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBytes_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    byte[] _value = LuaAPI.lua_tobytes(L, 3);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetBytes( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDateTime_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _sectionName = LuaAPI.lua_tostring(L, 1);
                    string _key = LuaAPI.lua_tostring(L, 2);
                    System.DateTime _value;translator.Get(L, 3, out _value);
                    
                    KiwiFramework.Core.ProjectIniSetting.SetDateTime( _sectionName, _key, _value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_All(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, KiwiFramework.Core.ProjectIniSetting.All);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
