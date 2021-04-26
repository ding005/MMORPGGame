using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaManager : MonoBehaviour {

    public static LuaEnv _evn;

    public static LuaManager Instance;

    private void Awake()
    {
        Instance = this;

        _evn = new LuaEnv();
        //_evn.DoString("require 'Main.lua'");

        TextAsset textAsset = Resources.Load<TextAsset>("Main.lua") as TextAsset;
        _evn.DoString(textAsset.text,"");
    }

    public void DoString(string str)
    {
        _evn.DoString(str);
    }

    void Update()
    {
        // ÿ֡gc
        if (_evn != null)
        {
            _evn.Tick();
        }
    }

    public void OnDestroy()
    {
        _evn.Dispose();
    }
}
