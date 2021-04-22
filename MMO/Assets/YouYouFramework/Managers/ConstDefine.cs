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
    public class ConstDefine
    {
        /// <summary>
        /// 版本文件名称
        /// </summary>
        public const string VersionFileName = "VersionFile.bytes";

        /// <summary>
        /// 资源版本号
        /// </summary>
        public const string ResourceVersion = "ResourceVersion";

        /// <summary>
        /// 资源信息文件名称
        /// </summary>
        public const string AssetInfoName = "AssetInfo.bytes";

        /// <summary>
        /// 表格资源包路径
        /// </summary>
        public const string DataTableAssetBundlePath = "download/datatable.assetbundle";

        /// <summary>
        /// lua脚本资源包路径
        /// </summary>
        public const string XLuaAssetBundlePath = "download/xlualogic.assetbundle";

        /// <summary>
        /// 自定义Shader资源包路径
        /// </summary>
        public const string CusShadersAssetBundlePath = "download/cusshaders.assetbundle";

        /// <summary>
        /// 声音资源包路径
        /// </summary>
        public const string AudioAssetBundlePath = "download/audio.assetbundle";

        /// <summary>
        /// 日志预设路径
        /// </summary>
        public const string ReporterPath = "Assets/Download/Reporter/report.prefab";

        /// <summary>
        /// 点击按钮声音
        /// </summary>
        public const int Aduio_ButtonClick = 201;

        /// <summary>
        /// UI关闭声音
        /// </summary>
        public const int Aduio_UIClose = 202;

        /// <summary>
        /// 帧率
        /// </summary>
        public const string targetFrameRate = "targetFrameRate";

        /// <summary>
        /// Http重试次数
        /// </summary>
        public const string Http_Retry = "Http_Retry";

        /// <summary>
        /// Http重试间隔
        /// </summary>
        public const string Http_RetryInterval = "Http_RetryInterval";

        /// <summary>
        /// Download重试次数
        /// </summary>
        public const string Download_Retry = "Download_Retry";

        /// <summary>
        /// Download重试间隔
        /// </summary>
        public const string Download_RetryInterval = "Download_RetryInterval";

        /// <summary>
        /// 多文件下载器中的下载器数量
        /// </summary>
        public const string Download_RoutineCount = "Download_RoutineCount";

        /// <summary>
        /// 写入磁盘的缓存大小(字节)
        /// </summary>
        public const string Download_FlushSize = "Download_FlushSize";

        /// <summary>
        /// 类对象池释放间隔
        /// </summary>
        public const string Pool_ReleaseClassObjectInterval = "Pool_ReleaseClassObjectInterval";

        /// <summary>
        /// 释放AssetBundle池间隔
        /// </summary>
        public const string Pool_ReleaseAssetBundleInterval = "Pool_ReleaseAssetBundleInterval";

        /// <summary>
        /// 释放Asset池间隔
        /// </summary>
        public const string Pool_ReleaseAssetInterval = "Pool_ReleaseAssetInterval";

        /// <summary>
        /// UI对象池中 最大的数量
        /// </summary>
        public const string UI_PoolMaxCount = "UI_PoolMaxCount";

        /// <summary>
        /// UI回池后过期时间
        /// </summary>
        public const string UI_Expire = "UI_Expire";

        /// <summary>
        /// 释放间隔(秒)
        /// </summary>
        public const string UI_ClearInterval = "UI_ClearInterval";

        /// <summary>
        /// Lua中可释放表数据的生命周期
        /// </summary>
        public const string Lua_DataTableLife = "Lua_DataTableLife";

        /// <summary>
        /// Audio释放间隔
        /// </summary>
        public const string Audio_ReleaseInterval = "Audio_ReleaseInterval";
    }
}