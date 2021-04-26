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
    public class YouYouDataTableChapterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(YouYou.DataTable.Chapter);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 9, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "__init", _m___init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "__assign", _m___assign);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChapterNameBytes", _m_GetChapterNameBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetChapterNameArray", _m_GetChapterNameArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBGPicBytes", _m_GetBGPicBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBGPicArray", _m_GetBGPicArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BranchLevelId", _m_BranchLevelId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBranchLevelIdBytes", _m_GetBranchLevelIdBytes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBranchLevelIdArray", _m_GetBranchLevelIdArray);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BranchLevelName", _m_BranchLevelName);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "ByteBuffer", _g_get_ByteBuffer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Id", _g_get_Id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ChapterName", _g_get_ChapterName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GameLevelCount", _g_get_GameLevelCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BGPic", _g_get_BGPic);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BranchLevelIdLength", _g_get_BranchLevelIdLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BranchLevelNameLength", _g_get_BranchLevelNameLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Uvx", _g_get_Uvx);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Uvy", _g_get_Uvy);
            
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 19, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetRootAsChapter", _m_GetRootAsChapter_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateChapter", _m_CreateChapter_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartChapter", _m_StartChapter_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddId", _m_AddId_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddChapterName", _m_AddChapterName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddGameLevelCount", _m_AddGameLevelCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddBGPic", _m_AddBGPic_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddBranchLevelId", _m_AddBranchLevelId_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateBranchLevelIdVector", _m_CreateBranchLevelIdVector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateBranchLevelIdVectorBlock", _m_CreateBranchLevelIdVectorBlock_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartBranchLevelIdVector", _m_StartBranchLevelIdVector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddBranchLevelName", _m_AddBranchLevelName_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateBranchLevelNameVector", _m_CreateBranchLevelNameVector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CreateBranchLevelNameVectorBlock", _m_CreateBranchLevelNameVectorBlock_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartBranchLevelNameVector", _m_StartBranchLevelNameVector_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddUvx", _m_AddUvx_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddUvy", _m_AddUvy_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "EndChapter", _m_EndChapter_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(YouYou.DataTable.Chapter));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to YouYou.DataTable.Chapter constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRootAsChapter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<FlatBuffers.ByteBuffer>(L, 1)) 
                {
                    FlatBuffers.ByteBuffer __bb = (FlatBuffers.ByteBuffer)translator.GetObject(L, 1, typeof(FlatBuffers.ByteBuffer));
                    
                        YouYou.DataTable.Chapter gen_ret = YouYou.DataTable.Chapter.GetRootAsChapter( __bb );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<FlatBuffers.ByteBuffer>(L, 1)&& translator.Assignable<YouYou.DataTable.Chapter>(L, 2)) 
                {
                    FlatBuffers.ByteBuffer __bb = (FlatBuffers.ByteBuffer)translator.GetObject(L, 1, typeof(FlatBuffers.ByteBuffer));
                    YouYou.DataTable.Chapter _obj;translator.Get(L, 2, out _obj);
                    
                        YouYou.DataTable.Chapter gen_ret = YouYou.DataTable.Chapter.GetRootAsChapter( __bb, _obj );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to YouYou.DataTable.Chapter.GetRootAsChapter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m___init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int __i = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.ByteBuffer __bb = (FlatBuffers.ByteBuffer)translator.GetObject(L, 3, typeof(FlatBuffers.ByteBuffer));
                    
                    gen_to_be_invoked.__init( __i, __bb );
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m___assign(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int __i = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.ByteBuffer __bb = (FlatBuffers.ByteBuffer)translator.GetObject(L, 3, typeof(FlatBuffers.ByteBuffer));
                    
                        YouYou.DataTable.Chapter gen_ret = gen_to_be_invoked.__assign( __i, __bb );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChapterNameBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        System.Nullable<System.ArraySegment<byte>> gen_ret = gen_to_be_invoked.GetChapterNameBytes(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetChapterNameArray(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.GetChapterNameArray(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBGPicBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        System.Nullable<System.ArraySegment<byte>> gen_ret = gen_to_be_invoked.GetBGPicBytes(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBGPicArray(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.GetBGPicArray(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BranchLevelId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _j = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.BranchLevelId( _j );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBranchLevelIdBytes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        System.Nullable<System.ArraySegment<byte>> gen_ret = gen_to_be_invoked.GetBranchLevelIdBytes(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBranchLevelIdArray(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int[] gen_ret = gen_to_be_invoked.GetBranchLevelIdArray(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BranchLevelName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _j = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.BranchLevelName( _j );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateChapter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 9&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<FlatBuffers.StringOffset>(L, 5)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 6)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 9)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    FlatBuffers.StringOffset _BG_PicOffset;translator.Get(L, 5, out _BG_PicOffset);
                    FlatBuffers.VectorOffset _BranchLevelIdOffset;translator.Get(L, 6, out _BranchLevelIdOffset);
                    FlatBuffers.VectorOffset _BranchLevelNameOffset;translator.Get(L, 7, out _BranchLevelNameOffset);
                    float _Uvx = (float)LuaAPI.lua_tonumber(L, 8);
                    float _Uvy = (float)LuaAPI.lua_tonumber(L, 9);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount, _BG_PicOffset, _BranchLevelIdOffset, _BranchLevelNameOffset, _Uvx, _Uvy );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 8&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<FlatBuffers.StringOffset>(L, 5)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 6)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 7)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 8)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    FlatBuffers.StringOffset _BG_PicOffset;translator.Get(L, 5, out _BG_PicOffset);
                    FlatBuffers.VectorOffset _BranchLevelIdOffset;translator.Get(L, 6, out _BranchLevelIdOffset);
                    FlatBuffers.VectorOffset _BranchLevelNameOffset;translator.Get(L, 7, out _BranchLevelNameOffset);
                    float _Uvx = (float)LuaAPI.lua_tonumber(L, 8);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount, _BG_PicOffset, _BranchLevelIdOffset, _BranchLevelNameOffset, _Uvx );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 7&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<FlatBuffers.StringOffset>(L, 5)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 6)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 7)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    FlatBuffers.StringOffset _BG_PicOffset;translator.Get(L, 5, out _BG_PicOffset);
                    FlatBuffers.VectorOffset _BranchLevelIdOffset;translator.Get(L, 6, out _BranchLevelIdOffset);
                    FlatBuffers.VectorOffset _BranchLevelNameOffset;translator.Get(L, 7, out _BranchLevelNameOffset);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount, _BG_PicOffset, _BranchLevelIdOffset, _BranchLevelNameOffset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 6&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<FlatBuffers.StringOffset>(L, 5)&& translator.Assignable<FlatBuffers.VectorOffset>(L, 6)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    FlatBuffers.StringOffset _BG_PicOffset;translator.Get(L, 5, out _BG_PicOffset);
                    FlatBuffers.VectorOffset _BranchLevelIdOffset;translator.Get(L, 6, out _BranchLevelIdOffset);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount, _BG_PicOffset, _BranchLevelIdOffset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 5&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<FlatBuffers.StringOffset>(L, 5)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    FlatBuffers.StringOffset _BG_PicOffset;translator.Get(L, 5, out _BG_PicOffset);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount, _BG_PicOffset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 4);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset, _GameLevelCount );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<FlatBuffers.StringOffset>(L, 3)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 3, out _ChapterNameOffset);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id, _ChapterNameOffset );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder, _Id );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<FlatBuffers.FlatBufferBuilder>(L, 1)) 
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.CreateChapter( _builder );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to YouYou.DataTable.Chapter.CreateChapter!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartChapter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    
                    YouYou.DataTable.Chapter.StartChapter( _builder );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddId_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _Id = LuaAPI.xlua_tointeger(L, 2);
                    
                    YouYou.DataTable.Chapter.AddId( _builder, _Id );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddChapterName_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.StringOffset _ChapterNameOffset;translator.Get(L, 2, out _ChapterNameOffset);
                    
                    YouYou.DataTable.Chapter.AddChapterName( _builder, _ChapterNameOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddGameLevelCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _GameLevelCount = LuaAPI.xlua_tointeger(L, 2);
                    
                    YouYou.DataTable.Chapter.AddGameLevelCount( _builder, _GameLevelCount );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBGPic_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.StringOffset _BGPicOffset;translator.Get(L, 2, out _BGPicOffset);
                    
                    YouYou.DataTable.Chapter.AddBGPic( _builder, _BGPicOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBranchLevelId_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.VectorOffset _BranchLevelIdOffset;translator.Get(L, 2, out _BranchLevelIdOffset);
                    
                    YouYou.DataTable.Chapter.AddBranchLevelId( _builder, _BranchLevelIdOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateBranchLevelIdVector_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int[] _data = (int[])translator.GetObject(L, 2, typeof(int[]));
                    
                        FlatBuffers.VectorOffset gen_ret = YouYou.DataTable.Chapter.CreateBranchLevelIdVector( _builder, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateBranchLevelIdVectorBlock_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int[] _data = (int[])translator.GetObject(L, 2, typeof(int[]));
                    
                        FlatBuffers.VectorOffset gen_ret = YouYou.DataTable.Chapter.CreateBranchLevelIdVectorBlock( _builder, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartBranchLevelIdVector_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _numElems = LuaAPI.xlua_tointeger(L, 2);
                    
                    YouYou.DataTable.Chapter.StartBranchLevelIdVector( _builder, _numElems );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddBranchLevelName_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.VectorOffset _BranchLevelNameOffset;translator.Get(L, 2, out _BranchLevelNameOffset);
                    
                    YouYou.DataTable.Chapter.AddBranchLevelName( _builder, _BranchLevelNameOffset );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateBranchLevelNameVector_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.StringOffset[] _data = (FlatBuffers.StringOffset[])translator.GetObject(L, 2, typeof(FlatBuffers.StringOffset[]));
                    
                        FlatBuffers.VectorOffset gen_ret = YouYou.DataTable.Chapter.CreateBranchLevelNameVector( _builder, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateBranchLevelNameVectorBlock_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    FlatBuffers.StringOffset[] _data = (FlatBuffers.StringOffset[])translator.GetObject(L, 2, typeof(FlatBuffers.StringOffset[]));
                    
                        FlatBuffers.VectorOffset gen_ret = YouYou.DataTable.Chapter.CreateBranchLevelNameVectorBlock( _builder, _data );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartBranchLevelNameVector_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    int _numElems = LuaAPI.xlua_tointeger(L, 2);
                    
                    YouYou.DataTable.Chapter.StartBranchLevelNameVector( _builder, _numElems );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddUvx_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    float _Uvx = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    YouYou.DataTable.Chapter.AddUvx( _builder, _Uvx );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddUvy_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    float _Uvy = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    YouYou.DataTable.Chapter.AddUvy( _builder, _Uvy );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EndChapter_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    FlatBuffers.FlatBufferBuilder _builder = (FlatBuffers.FlatBufferBuilder)translator.GetObject(L, 1, typeof(FlatBuffers.FlatBufferBuilder));
                    
                        FlatBuffers.Offset<YouYou.DataTable.Chapter> gen_ret = YouYou.DataTable.Chapter.EndChapter( _builder );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ByteBuffer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.ByteBuffer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ChapterName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ChapterName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GameLevelCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.GameLevelCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BGPic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.BGPic);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BranchLevelIdLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BranchLevelIdLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BranchLevelNameLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BranchLevelNameLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Uvx(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Uvx);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Uvy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                YouYou.DataTable.Chapter gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.Uvy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
