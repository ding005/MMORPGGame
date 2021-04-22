using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 可寻址资源管理器
    /// </summary>
    public class AddressableManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 本地文件路径
        /// </summary>
        public string LocalFilePath;

        /// <summary>
        /// 资源管理器
        /// </summary>
        public ResourceManager ResourceManager
        {
            get;
            private set;
        }

        /// <summary>
        /// 资源加载管理器
        /// </summary>
        public ResourceLoaderManager ResourceLoaderManager
        {
            get;
            private set;
        }

        public AddressableManager()
        {
            ResourceManager = new ResourceManager();
            ResourceLoaderManager = new ResourceLoaderManager();
        }

        public override void Init()
        {
#if DISABLE_ASSETBUNDLE
            LocalFilePath = Application.dataPath;
#else
            LocalFilePath = Application.persistentDataPath;
#endif
            ResourceManager.Init();
            ResourceLoaderManager.Init();

            Application.backgroundLoadingPriority = ThreadPriority.High;
        }

        #region InitStreamingAssetsBundleInfo 初始化只读区资源包信息
        /// <summary>
        /// 初始化只读区资源包信息
        /// </summary>
        public void InitStreamingAssetsBundleInfo()
        {
            ResourceManager.InitStreamingAssetsBundleInfo();
        }
        #endregion

        #region InitAssetInfo 初始化资源信息
        /// <summary>
        /// 初始化资源信息
        /// </summary>
        public void InitAssetInfo(BaseAction initAssetInfoComplete)
        {
            ResourceLoaderManager.InitAssetInfo(initAssetInfoComplete);
        }
        #endregion

        /// <summary>
        /// 获取路径的最后名称
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetLastPathName(string path)
        {
            if (path.IndexOf('/') == -1)
            {
                return path;
            }
            return path.Substring(path.LastIndexOf('/') + 1);
        }

        public void Dispose()
        {
            ResourceManager.Dispose();
            ResourceLoaderManager.Dispose();
        }

        public void OnUpdate()
        {
            ResourceLoaderManager.OnUpdate();
        }

        /// <summary>
        /// 获取场景的资源包路径
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        public string GetSceneAssetBundlePath(string sceneName)
        {
            return string.Format("download/scenes/{0}.assetbundle", sceneName.ToLower());
        }
    }
}