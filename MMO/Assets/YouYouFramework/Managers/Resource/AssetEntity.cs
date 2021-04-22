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
    /// 资源信息实体(对应的是资源信息)
    /// </summary>
    public class AssetEntity
    {
        /// <summary>
        /// 资源分类
        /// </summary>
        public AssetCategory Category;

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 资源完整名称
        /// </summary>
        public string AssetFullName;

        /// <summary>
        /// 所属资源包(这个资源在哪个AssetBundle里)
        /// </summary>
        public string AssetBundleName;

        /// <summary>
        /// 依赖资源
        /// </summary>
        public List<AssetDependsEntity> DependsAssetList;
    }
}