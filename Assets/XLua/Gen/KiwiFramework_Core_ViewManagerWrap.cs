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
    public class KiwiFrameworkCoreViewManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(KiwiFramework.Core.ViewManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OpenView", _m_OpenView);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseView", _m_CloseView);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "mainCanvas", _g_get_mainCanvas);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "mainCanvas", _s_set_mainCanvas);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 4, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NormalCanvasSortOrder", KiwiFramework.Core.ViewManager.NormalCanvasSortOrder);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "ForwardCanvasSortOrder", KiwiFramework.Core.ViewManager.ForwardCanvasSortOrder);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "TopCanvasSortOrder", KiwiFramework.Core.ViewManager.TopCanvasSortOrder);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new KiwiFramework.Core.ViewManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to KiwiFramework.Core.ViewManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OpenView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                KiwiFramework.Core.ViewManager gen_to_be_invoked = (KiwiFramework.Core.ViewManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _viewName = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.OpenView( _viewName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                KiwiFramework.Core.ViewManager gen_to_be_invoked = (KiwiFramework.Core.ViewManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _viewName = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.CloseView( _viewName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mainCanvas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                KiwiFramework.Core.ViewManager gen_to_be_invoked = (KiwiFramework.Core.ViewManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.mainCanvas);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mainCanvas(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                KiwiFramework.Core.ViewManager gen_to_be_invoked = (KiwiFramework.Core.ViewManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mainCanvas = (UnityEngine.Canvas)translator.GetObject(L, 2, typeof(UnityEngine.Canvas));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
