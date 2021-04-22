using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ��Ѱַ��Դ������
    /// </summary>
    public class AddressableManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// �����ļ�·��
        /// </summary>
        public string LocalFilePath;

        /// <summary>
        /// ��Դ������
        /// </summary>
        public ResourceManager ResourceManager
        {
            get;
            private set;
        }

        /// <summary>
        /// ��Դ���ع�����
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

        #region InitStreamingAssetsBundleInfo ��ʼ��ֻ������Դ����Ϣ
        /// <summary>
        /// ��ʼ��ֻ������Դ����Ϣ
        /// </summary>
        public void InitStreamingAssetsBundleInfo()
        {
            ResourceManager.InitStreamingAssetsBundleInfo();
        }
        #endregion

        #region InitAssetInfo ��ʼ����Դ��Ϣ
        /// <summary>
        /// ��ʼ����Դ��Ϣ
        /// </summary>
        public void InitAssetInfo(BaseAction initAssetInfoComplete)
        {
            ResourceLoaderManager.InitAssetInfo(initAssetInfoComplete);
        }
        #endregion

        /// <summary>
        /// ��ȡ·�����������
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
        /// ��ȡ��������Դ��·��
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        public string GetSceneAssetBundlePath(string sceneName)
        {
            return string.Format("download/scenes/{0}.assetbundle", sceneName.ToLower());
        }
    }
}