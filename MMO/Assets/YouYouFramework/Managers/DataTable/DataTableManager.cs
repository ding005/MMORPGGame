using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou.DataTable;

namespace YouYou
{
    public class DataTableManager : ManagerBase, IDisposable
    {
        public DataTableManager()
        {
            AlreadyLoadTable = new Dictionary<string, ushort>();
        }

        public override void Init()
        {

        }

        /// <summary>
        /// 已经在c#加载的表格
        /// </summary>
        public Dictionary<string, ushort> AlreadyLoadTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 添加到已加载字典
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="version"></param>
        public void AddToAlreadyLoadTable(string tableName, ushort version)
        {
            AlreadyLoadTable[tableName] = version;
        }

        /// <summary>
        /// 根据表格名称和版本号检查是否已经在c#加载
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public bool CheckAlreadyLoadTable(string tableName, ushort version)
        {
            ushort ver = 0;
            if (AlreadyLoadTable.TryGetValue(tableName, out ver))
            {
                if (ver == version)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 总共需要加载的表格数量
        /// </summary>
        public int TotalTableCount = 0;

        /// <summary>
        /// 当前加载的表格数量
        /// </summary>
        public int CurrLoadTableCount = 0;

        public Sys_LocalizationList Sys_LocalizationList;
        public Sys_AudioList Sys_AudioList;
        public Sys_CodeList Sys_CodeList;
        public Sys_EffectList Sys_EffectList;
        public Sys_PrefabList Sys_PrefabList;
        public Sys_SceneList Sys_SceneList;
        public Sys_SceneDetailList Sys_SceneDetailList;
        public Sys_StorySoundList Sys_StorySoundList;
        public Sys_UIFormList Sys_UIFormList;

        public ChapterList ChapterList;

        /// <summary>
        /// 加载表格
        /// </summary>
        public void LoadDataTable()
        {
            Sys_LocalizationList.LoadData();
            Sys_AudioList.LoadData();
            Sys_CodeList.LoadData();
            Sys_EffectList.LoadData();
            Sys_PrefabList.LoadData();
            Sys_SceneList.LoadData();
            Sys_SceneDetailList.LoadData();
            Sys_StorySoundList.LoadData();
            Sys_UIFormList.LoadData();
            ChapterList.LoadData();
        }

        /// <summary>
        /// 表格资源包
        /// </summary>
        private AssetBundle m_DataTableBundle;

        /// <summary>
        /// 加载表格
        /// </summary>
        public void LoadDataAllTable()
        {
#if DISABLE_ASSETBUNDLE
            LoadDataTable();
#else
            GameEntry.Resource.ResourceLoaderManager.LoadAssetBundle(ConstDefine.DataTableAssetBundlePath, onComplete: (AssetBundle bundle) =>
            {
                m_DataTableBundle = bundle;
                LoadDataTable();
            });
#endif
        }

        /// <summary>
        /// 获取表格的字节数组
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public void GetDataTableBuffer(string tableName, BaseAction<byte[]> onComplete)
        {
#if DISABLE_ASSETBUNDLE
            GameEntry.Time.Yield(() =>
            {
                byte[] buffer = IOUtil.GetFileBuffer(string.Format("{0}/download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath, tableName));
                onComplete?.Invoke(ZlibHelper.DeCompressBytes(buffer));
            });
#else
            GameEntry.Resource.ResourceLoaderManager.LoadAsset(GameEntry.Resource.GetLastPathName(tableName), m_DataTableBundle, onComplete: (UnityEngine.Object obj) =>
            {
                TextAsset asset = obj as TextAsset;
                if (onComplete != null)
                {
                    onComplete(ZlibHelper.DeCompressBytes(asset.bytes));
                }
            });
#endif
        }

        public void Dispose()
        {

        }
    }
}