using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==============================
//Author:			Mr.ding
//CreateTime:		2021-04-27 15:01:27
//Version:			1.0.1
//==============================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    private void Awake()
    {
        gameObject.AddComponent<LuaMgr>();
    }
    void Start()
    {
        //执行第一个lua脚本
        //LuaMgr.Instance.DoString("require'Download/XLuaLogic/Main'");
    }

    void Update()
    {

    }
}

