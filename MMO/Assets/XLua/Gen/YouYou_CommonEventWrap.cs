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
    public class YouYouCommonEventWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(YouYou.CommonEvent);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddEventListener", _m_AddEventListener);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveEventListener", _m_RemoveEventListener);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispatch", _m_Dispatch);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "dic", _g_get_dic);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "dic", _s_set_dic);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new YouYou.CommonEvent();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to YouYou.CommonEvent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddEventListener(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort _key = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    YouYou.CommonEvent.OnActionHandler _handler = translator.GetDelegate<YouYou.CommonEvent.OnActionHandler>(L, 3);
                    
                    gen_to_be_invoked.AddEventListener( _key, _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveEventListener(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort _key = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    YouYou.CommonEvent.OnActionHandler _handler = translator.GetDelegate<YouYou.CommonEvent.OnActionHandler>(L, 3);
                    
                    gen_to_be_invoked.RemoveEventListener( _key, _handler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispatch(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<object>(L, 3)) 
                {
                    ushort _key = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    object _userData = translator.GetObject(L, 3, typeof(object));
                    
                    gen_to_be_invoked.Dispatch( _key, _userData );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    ushort _key = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.Dispatch( _key );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to YouYou.CommonEvent.Dispatch!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dic);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.CommonEvent gen_to_be_invoked = (YouYou.CommonEvent)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dic = (System.Collections.Generic.Dictionary<ushort, System.Collections.Generic.LinkedList<YouYou.CommonEvent.OnActionHandler>>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<ushort, System.Collections.Generic.LinkedList<YouYou.CommonEvent.OnActionHandler>>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
