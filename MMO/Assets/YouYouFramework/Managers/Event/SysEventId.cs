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
    /// 系统事件编号(系统事件编号 采用4位 1001(10表示模块 01表示编号))
    /// </summary>
    public class SysEventId
    {
        /// <summary>
        /// 加载表格完毕
        /// </summary>
        public const ushort LoadDataTableComplete = 1001;

        /// <summary>
        /// 加载单一表格完毕
        /// </summary>
        public const ushort LoadOneDataTableComplete = 1002;

        /// <summary>
        /// 加载Lua表格完毕
        /// </summary>
        public const ushort LoadLuaDataTableComplete = 1003;

        /// <summary>
        /// 加载进度条更新
        /// </summary>
        public const ushort LoadingProgressChange = 1101;

        /// <summary>
        /// 检查版本更新开始下载
        /// </summary>
        public const ushort CheckVersionBeginDownload = 1201;

        /// <summary>
        /// 检查版本更新下载资源中
        /// </summary>
        public const ushort CheckVersionDownloadUpdate = 1202;

        /// <summary>
        /// 检查版本更新下载完毕
        /// </summary>
        public const ushort CheckVersionDownloadComplete = 1203;

        /// <summary>
        /// 预加载开始
        /// </summary>
        public const ushort PreloadBegin = 1204;

        /// <summary>
        /// 预加载中
        /// </summary>
        public const ushort PreloadUpdate = 1205;

        /// <summary>
        /// 预加载完毕
        /// </summary>
        public const ushort PreloadComplete = 1206;

        /// <summary>
        /// 关闭检查版本更新UI
        /// </summary>
        public const ushort CloseCheckVersionUI = 1207;

        /// <summary>
        /// Lua内存释放
        /// </summary>
        public const ushort LuaFullGc = 1208;
    }
}