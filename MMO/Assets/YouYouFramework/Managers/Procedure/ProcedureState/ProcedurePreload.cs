//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 预加载流程
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        /// <summary>
        /// 目标进度
        /// </summary>
        private float m_TargetProgress = 0;

        /// <summary>
        /// 当前进度
        /// </summary>
        private float m_CurrProgress = 0;

        /// <summary>
        /// 预加载参数
        /// </summary>
        private BaseParams m_PreloadParams;


        public override void OnEnter()
        {
            base.OnEnter();

            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedurePreload");
            GameEntry.Event.CommonEvent.AddEventListener(SysEventId.LoadOneDataTableComplete, OnLoadOneDataTableComplete);
            GameEntry.Event.CommonEvent.AddEventListener(SysEventId.LoadDataTableComplete, OnLoadDataTableComplete);
            GameEntry.Event.CommonEvent.AddEventListener(SysEventId.LoadLuaDataTableComplete, OnLoadLuaDataTableComplete);

            GameEntry.Log(LogCategory.Normal, "预加载开始");
            m_PreloadParams = GameEntry.Pool.DequeueClassObject<BaseParams>();
            m_PreloadParams.Reset();
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.PreloadBegin);

            m_TargetProgress = 99;

#if !DISABLE_ASSETBUNDLE
            GameEntry.Resource.InitAssetInfo(() =>
            {
                LoadReport();
            });
#else
            LoadReport();
#endif

            GameEntry.DataTable.LoadDataAllTable();
        }

        /// <summary>
        /// 加载日志预设
        /// </summary>
        private void LoadReport()
        {
#if DEBUG_MODEL
            GameEntry.Resource.ResourceLoaderManager.LoadMainAsset(AssetCategory.Reporter, ConstDefine.ReporterPath, (ResourceEntity resourceEntity) =>
            {
                UnityEngine.Object.Instantiate(resourceEntity.Target as GameObject);
            });
#endif
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (m_LoadDataTableStatus == 1)
            {
                m_LoadDataTableStatus = 2;

                //执行Lua初始化
                GameEntry.Lua.Init();
            }

            if (m_CurrProgress < m_TargetProgress || m_TargetProgress < 100)
            {
                m_CurrProgress = m_CurrProgress + Time.deltaTime * 200; //根据实际情况调节速度
                m_PreloadParams.FloatParam1 = m_CurrProgress;
                GameEntry.Event.CommonEvent.Dispatch(SysEventId.PreloadUpdate, m_PreloadParams);
            }
            else if (m_CurrProgress >= 100)
            {
                m_CurrProgress = 100;
                m_PreloadParams.FloatParam1 = m_CurrProgress;
                GameEntry.Event.CommonEvent.Dispatch(SysEventId.PreloadUpdate, m_PreloadParams);

                GameEntry.Log(LogCategory.Normal, "预加载完毕");
                GameEntry.Event.CommonEvent.Dispatch(SysEventId.PreloadComplete);
                GameEntry.Pool.EnqueueClassObject(m_PreloadParams);

                GameEntry.Procedure.ChangeState(ProcedureState.LogOn);
            }
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedurePreload");

            GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.LoadOneDataTableComplete, OnLoadOneDataTableComplete);
            GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.LoadDataTableComplete, OnLoadDataTableComplete);
            GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.LoadLuaDataTableComplete, OnLoadLuaDataTableComplete);
        }

        /// <summary>
        /// 加载单一表完毕
        /// </summary>
        /// <param name="userData"></param>
        private void OnLoadOneDataTableComplete(object userData)
        {
            GameEntry.DataTable.CurrLoadTableCount++;
            if (GameEntry.DataTable.CurrLoadTableCount == GameEntry.DataTable.TotalTableCount)
            {
                GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadDataTableComplete);
            }
        }

        /// <summary>
        /// 加载表格状态0=未加载 1=加载完毕
        /// </summary>
        byte m_LoadDataTableStatus = 0;

        /// <summary>
        /// 加载所有表完毕
        /// </summary>
        /// <param name="userData"></param>
        private void OnLoadDataTableComplete(object userData)
        {
            GameEntry.Log(LogCategory.Normal, "加载所有c#表格完毕");
            m_LoadDataTableStatus = 1;
        }

        private void OnLoadLuaDataTableComplete(object userData)
        {
            GameEntry.Log(LogCategory.Normal, "加载所有lua表格完毕");
            LoadAudio();
        }

        /// <summary>
        /// 加载声音
        /// </summary>
        private void LoadAudio()
        {
            GameEntry.Audio.LoadBanks(() =>
            {
                LoadShader();
            });
        }

        /// <summary>
        /// 加载Shader
        /// </summary>
        private void LoadShader()
        {
#if DISABLE_ASSETBUNDLE
            m_TargetProgress = 100;
#else
            GameEntry.Resource.ResourceLoaderManager.LoadAssetBundle(ConstDefine.CusShadersAssetBundlePath, onComplete: (AssetBundle bundle) =>
            {
                bundle.LoadAllAssets();
                Shader.WarmupAllShaders();
                GameEntry.Log(LogCategory.Normal, "加载资源包中的自定义Shader完毕");
                m_TargetProgress = 100;
            });
#endif
        }

    }
}