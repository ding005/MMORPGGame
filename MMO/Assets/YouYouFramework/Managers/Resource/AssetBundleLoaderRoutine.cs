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
    /// 资源包加载器
    /// </summary>
    public class AssetBundleLoaderRoutine
    {
        /// <summary>
        /// 当前的资源包信息
        /// </summary>
        private AssetBundleInfoEntity m_CurrAssetBundleInfo;

        /// <summary>
        /// 资源包创建请求
        /// </summary>
        private AssetBundleCreateRequest m_CurrAssetBundleCreateRequest;

        /// <summary>
        /// 资源包创建请求更新
        /// </summary>
        public Action<float> OnAssetBundleCreateUpdate;

        /// <summary>
        /// 加载资源包完毕
        /// </summary>
        public Action<AssetBundle> OnLoadAssetBundleComplete;

        #region LoadAssetBundle 加载资源包
        /// <summary>
        /// 加载资源包
        /// </summary>
        /// <param name="assetbundlePath"></param>
        public void LoadAssetBundle(string assetbundlePath)
        {
            m_CurrAssetBundleInfo = GameEntry.Resource.ResourceManager.GetAssetBundleInfo(assetbundlePath);

            //检查文件在可写区是否存在
            bool isExistsInLocal = GameEntry.Resource.ResourceManager.LocalAssetsManager.CheckFileExists(assetbundlePath);

            if (isExistsInLocal && !m_CurrAssetBundleInfo.IsEncrypt)
            {
                //如果资源包存在于可写区 并且没有加密
                m_CurrAssetBundleCreateRequest = AssetBundle.LoadFromFileAsync(string.Format("{0}/{1}", Application.persistentDataPath, assetbundlePath));
            }
            else
            {
                byte[] buffer = GameEntry.Resource.ResourceManager.LocalAssetsManager.GetFileBuffer(assetbundlePath);
                if (buffer == null)
                {
                    //如果可写区没有 那么就从只读区获取
                    GameEntry.Resource.ResourceManager.StreamingAssetsManager.ReadAssetBundle(assetbundlePath, (byte[] buff) =>
                    {
                        if (buff == null)
                        {
                            GameEntry.Download.BeginDownloadSingle(assetbundlePath, onComplete: (string fileUrl) =>
                            {
                                buffer = GameEntry.Resource.ResourceManager.LocalAssetsManager.GetFileBuffer(fileUrl);
                                LoadAssetBundleAsync(buffer);
                            });
                        }
                        else
                        {
                            LoadAssetBundleAsync(buff);
                        }
                    });
                }
                else
                {
                    LoadAssetBundleAsync(buffer);
                }
            }
        }

        /// <summary>
        /// 异步加载资源包
        /// </summary>
        /// <param name="buffer"></param>
        private void LoadAssetBundleAsync(byte[] buffer)
        {
            if (m_CurrAssetBundleInfo.IsEncrypt)
            {
                buffer = SecurityUtil.Xor(buffer);
            }

            m_CurrAssetBundleCreateRequest = AssetBundle.LoadFromMemoryAsync(buffer);
        }
        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            m_CurrAssetBundleCreateRequest = null;
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void OnUpdate()
        {
            UpdateAssetBundleCreateRequest();
        }

        #region UpdateAssetBundleCreateRequest 更新资源包请求
        /// <summary>
        /// 更新资源包请求
        /// </summary>
        private void UpdateAssetBundleCreateRequest()
        {
            if (m_CurrAssetBundleCreateRequest != null)
            {
                if (m_CurrAssetBundleCreateRequest.isDone)
                {
                    AssetBundle assetBundle = m_CurrAssetBundleCreateRequest.assetBundle;
                    if (assetBundle != null)
                    {
                        GameEntry.Log(LogCategory.Resource, "资源包=>{0} 加载完毕", m_CurrAssetBundleInfo.AssetBundleName);
                        Reset(); //一定要早点Reset

                        if (OnLoadAssetBundleComplete != null)
                        {
                            OnLoadAssetBundleComplete(assetBundle);
                        }
                    }
                    else
                    {
                        GameEntry.LogError("资源包=>{0} 加载失败", m_CurrAssetBundleInfo.AssetBundleName);
                        Reset();

                        if (OnLoadAssetBundleComplete != null)
                        {
                            OnLoadAssetBundleComplete(null);
                        }
                    }
                }
                else
                {
                    // 加载进度
                    if (OnAssetBundleCreateUpdate != null)
                    {
                        OnAssetBundleCreateUpdate(m_CurrAssetBundleCreateRequest.progress);
                    }
                }
            }
        }
        #endregion
    }
}