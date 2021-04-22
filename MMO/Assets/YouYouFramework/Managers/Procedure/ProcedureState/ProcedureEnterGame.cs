//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 进入游戏流程
    /// </summary>
    public class ProcedureEnterGame : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("OnEnter ProcedureEnterGame");

            string name = GameEntry.Procedure.GetData<string>("name");
            int code = GameEntry.Procedure.GetData<int>("code");

            Debug.Log("name=" + name);
            Debug.Log("code=" + code);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            Debug.Log("OnLeave ProcedureEnterGame");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}