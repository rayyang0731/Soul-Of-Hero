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
    public class SystemConvertWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(System.Convert);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 24, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTypeCode", _m_GetTypeCode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsDBNull", _m_IsDBNull_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ChangeType", _m_ChangeType_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToBoolean", _m_ToBoolean_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToChar", _m_ToChar_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToSByte", _m_ToSByte_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToByte", _m_ToByte_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToInt16", _m_ToInt16_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToUInt16", _m_ToUInt16_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToInt32", _m_ToInt32_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToUInt32", _m_ToUInt32_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToInt64", _m_ToInt64_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToUInt64", _m_ToUInt64_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToSingle", _m_ToSingle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToDouble", _m_ToDouble_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToDecimal", _m_ToDecimal_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToDateTime", _m_ToDateTime_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToString", _m_ToString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToBase64String", _m_ToBase64String_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ToBase64CharArray", _m_ToBase64CharArray_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromBase64String", _m_FromBase64String_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FromBase64CharArray", _m_FromBase64CharArray_xlua_st_);
            
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "DBNull", System.Convert.DBNull);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "System.Convert does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTypeCode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.GetTypeCode( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDBNull_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.IsDBNull( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeType_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.TypeCode>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.TypeCode _typeCode;translator.Get(L, 2, out _typeCode);
                    
                        var gen_ret = System.Convert.ChangeType( _value, _typeCode );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.Type>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.Type _conversionType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        var gen_ret = System.Convert.ChangeType( _value, _conversionType );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.TypeCode>(L, 2)&& translator.Assignable<System.IFormatProvider>(L, 3)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.TypeCode _typeCode;translator.Get(L, 2, out _typeCode);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ChangeType( _value, _typeCode, _provider );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.Type>(L, 2)&& translator.Assignable<System.IFormatProvider>(L, 3)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.Type _conversionType = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 3, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ChangeType( _value, _conversionType, _provider );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ChangeType!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToBoolean_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToBoolean( _value );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToBoolean( _value, _provider );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToBoolean( _value, _provider );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToBoolean!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToChar_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToChar( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToChar( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToChar( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToChar!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToSByte_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToSByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToSByte( _value, _fromBase );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToSByte( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToSByte( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToSByte!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToByte_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToByte( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToByte( _value, _fromBase );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToByte( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToByte( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToByte!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToInt16_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToInt16( _value, _fromBase );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt16( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt16( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToInt16!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToUInt16_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt16( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToUInt16( _value, _fromBase );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt16( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt16( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToUInt16!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToInt32_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt32( _value );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToInt32( _value, _fromBase );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt32( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt32( _value, _provider );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToInt32!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToUInt32_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt32( _value );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToUInt32( _value, _fromBase );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt32( _value, _provider );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt32( _value, _provider );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToUInt32!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToInt64_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToInt64( _value );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToInt64( _value, _fromBase );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt64( _value, _provider );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToInt64( _value, _provider );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToInt64!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToUInt64_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToUInt64( _value );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    int _fromBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToUInt64( _value, _fromBase );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt64( _value, _provider );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToUInt64( _value, _provider );
                        LuaAPI.lua_pushuint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToUInt64!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToSingle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToSingle( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToSingle( _value, _provider );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToSingle( _value, _provider );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToSingle!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToDouble_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDouble( _value );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDouble( _value, _provider );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDouble( _value, _provider );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToDouble!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToDecimal_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDecimal( _value );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDecimal( _value, _provider );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDecimal( _value, _provider );
                        translator.PushDecimal(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToDecimal!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToDateTime_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToDateTime( _value );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDateTime( _value, _provider );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToDateTime( _value, _provider );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToDateTime!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    int _toBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToString( _value, _toBase );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    int _toBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToString( _value, _toBase );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    int _toBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToString( _value, _toBase );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    int _toBase = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = System.Convert.ToString( _value, _toBase );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<object>(L, 1)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<System.DateTime>(L, 1)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.ToString( _value );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    bool _value = LuaAPI.lua_toboolean(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    char _value = (char)LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    sbyte _value = (sbyte)LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    byte _value = (byte)LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    short _value = (short)LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    ushort _value = (ushort)LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    int _value = LuaAPI.xlua_tointeger(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    uint _value = LuaAPI.xlua_touint(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isint64(L, 1))&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    long _value = LuaAPI.lua_toint64(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || LuaAPI.lua_isuint64(L, 1))&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    ulong _value = LuaAPI.lua_touint64(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    float _value = (float)LuaAPI.lua_tonumber(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    double _value = LuaAPI.lua_tonumber(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<object>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    object _value = translator.GetObject(L, 1, typeof(object));
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1) || translator.IsDecimal(L, 1))&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    decimal _value;translator.Get(L, 1, out _value);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<System.DateTime>(L, 1)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    System.DateTime _value;translator.Get(L, 1, out _value);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.IFormatProvider>(L, 2)) 
                {
                    string _value = LuaAPI.lua_tostring(L, 1);
                    System.IFormatProvider _provider = (System.IFormatProvider)translator.GetObject(L, 2, typeof(System.IFormatProvider));
                    
                        var gen_ret = System.Convert.ToString( _value, _provider );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToString!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToBase64String_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    
                        var gen_ret = System.Convert.ToBase64String( _inArray );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    int _offset = LuaAPI.xlua_tointeger(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = System.Convert.ToBase64String( _inArray, _offset, _length );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Base64FormattingOptions>(L, 2)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    System.Base64FormattingOptions _options;translator.Get(L, 2, out _options);
                    
                        var gen_ret = System.Convert.ToBase64String( _inArray, _options );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<System.Base64FormattingOptions>(L, 4)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    int _offset = LuaAPI.xlua_tointeger(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    System.Base64FormattingOptions _options;translator.Get(L, 4, out _options);
                    
                        var gen_ret = System.Convert.ToBase64String( _inArray, _offset, _length, _options );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToBase64String!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToBase64CharArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<char[]>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    int _offsetIn = LuaAPI.xlua_tointeger(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    char[] _outArray = (char[])translator.GetObject(L, 4, typeof(char[]));
                    int _offsetOut = LuaAPI.xlua_tointeger(L, 5);
                    
                        var gen_ret = System.Convert.ToBase64CharArray( _inArray, _offsetIn, _length, _outArray, _offsetOut );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<char[]>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)&& translator.Assignable<System.Base64FormattingOptions>(L, 6)) 
                {
                    byte[] _inArray = LuaAPI.lua_tobytes(L, 1);
                    int _offsetIn = LuaAPI.xlua_tointeger(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    char[] _outArray = (char[])translator.GetObject(L, 4, typeof(char[]));
                    int _offsetOut = LuaAPI.xlua_tointeger(L, 5);
                    System.Base64FormattingOptions _options;translator.Get(L, 6, out _options);
                    
                        var gen_ret = System.Convert.ToBase64CharArray( _inArray, _offsetIn, _length, _outArray, _offsetOut, _options );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to System.Convert.ToBase64CharArray!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromBase64String_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _s = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = System.Convert.FromBase64String( _s );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FromBase64CharArray_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    char[] _inArray = (char[])translator.GetObject(L, 1, typeof(char[]));
                    int _offset = LuaAPI.xlua_tointeger(L, 2);
                    int _length = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = System.Convert.FromBase64CharArray( _inArray, _offset, _length );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
