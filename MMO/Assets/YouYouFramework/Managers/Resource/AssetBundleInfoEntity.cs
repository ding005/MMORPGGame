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
    /// 资源包信息实体
    /// </summary>
    public class AssetBundleInfoEntity
    {
        /// <summary>
        /// 资源包名称
        /// </summary>
        public string AssetBundleName;

        /// <summary>
        /// MD5
        /// </summary>
        public string MD5;

        /// <summary>
        /// 文件大小（字节）
        /// </summary>
        public ulong Size;

        /// <summary>
        /// 是否初始数据
        /// </summary>
        public bool IsFirstData;

        /// <summary>
        /// 是否已经加密
        /// </summary>
        public bool IsEncrypt;
    }
}