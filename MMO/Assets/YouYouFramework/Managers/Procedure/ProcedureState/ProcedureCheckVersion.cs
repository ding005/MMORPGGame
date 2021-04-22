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
    /// 检查更新流程
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureCheckVersion");

#if DISABLE_ASSETBUNDLE
            GameEntry.Procedure.ChangeState(ProcedureState.Preload);
#else
            GameEntry.Resource.InitStreamingAssetsBundleInfo();
#endif
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureCheckVersion");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}