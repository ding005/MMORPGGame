using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

//==============================
//Author:			Mr.ding
//CreateTime:		2021-04-26 16:59:43
//Version:			1.0.1
//==============================


//lua 环境管理器
public class LuaMgr : MonoBehaviour {
    public static LuaMgr Instance { private set; get; }
    public static LuaEnv luaEnv;
    void Awake()
    {
        Instance = this;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(CoustomLoader);
        SafeDoString("require ('Main')");
    }
    void Start ()
    {
        
    }

    // 从项目中加载原始的Lua脚本，仅在editor模式下执行
    public byte[] CoustomLoader(ref string filepath)
    {
        string path = Application.dataPath + "/Download/xLuaLogic/" + filepath + ".lua";
        Debug.Log("path = " + path);
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重定向失败，文件名为" + filepath);
        }
        return null;
    }

    void LoadScript(string scriptName)
    {
        SafeDoString(string.Format("require('{0}')", scriptName));
    }

    public void SafeDoString(string scriptContent)
    {
        Debug.Log("scriptContent = " + scriptContent + "  luaEnv == " + luaEnv);
        if (luaEnv != null)
        {
            try
            {
                luaEnv.DoString(scriptContent);
            }
            catch (System.Exception ex)
            {
                string msg = string.Format("xLua exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }

    public void DoString(string str)
    {
        luaEnv.DoString(str);
    }

    void Update () {
        if (luaEnv != null)
        {
            // void Tick()： 清除Lua的未手动释放的LuaBase（比如，LuaTable， LuaFunction），以及其它一些事情。需要定期调用，比如在MonoBehaviour的Update中调用。
            luaEnv.Tick();

            if (Time.frameCount % 100 == 0)
            {
                luaEnv.FullGc();
            }
        }
    }
}
