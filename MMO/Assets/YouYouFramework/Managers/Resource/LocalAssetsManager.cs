//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

namespace YouYou
{
    /// <summary>
    /// 可写区管理器
    /// </summary>
    public class LocalAssetsManager
    {
        /// <summary>
        /// 本地版本文件路径
        /// </summary>
        public string LocalVersionFilePath
        {
            get
            {
                return string.Format("{0}/{1}", Application.persistentDataPath, ConstDefine.VersionFileName);
            }
        }

        #region GetVersionFileExists 获取可写区版本文件是否存在
        /// <summary>
        /// 获取可写区版本文件是否存在
        /// </summary>
        /// <returns></returns>
        public bool GetVersionFileExists()
        {
            return File.Exists(LocalVersionFilePath);
        }
        #endregion

        #region GetFileBuffer 获取本地文件字节数组
        /// <summary>
        /// 获取本地文件字节数组
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] GetFileBuffer(string path)
        {
            return IOUtil.GetFileBuffer(string.Format("{0}/{1}", Application.persistentDataPath, path));
        }
        #endregion

        #region CheckFileExists 检查文件是否存在
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CheckFileExists(string path)
        {
            return File.Exists(string.Format("{0}/{1}", Application.persistentDataPath, path));
        }
        #endregion

        #region SetResourceVersion 保存资源版本号
        /// <summary>
        /// 保存资源版本号
        /// </summary>
        /// <param name="version"></param>
        public void SetResourceVersion(string version)
        {
            PlayerPrefs.SetString(ConstDefine.ResourceVersion, version);
        }
        #endregion

        #region SaveVersionFile 保存版本文件
        /// <summary>
        /// 保存版本文件
        /// </summary>
        /// <param name="dic"></param>
        public void SaveVersionFile(Dictionary<string, AssetBundleInfoEntity> dic)
        {
            string json = JsonMapper.ToJson(dic);
            IOUtil.CreateTextFile(LocalVersionFilePath, json);
        }
        #endregion

        #region GetAssetBundleVersionList 加载可写区资源包信息
        /// <summary>
        /// 加载可写区资源包信息
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public Dictionary<string, AssetBundleInfoEntity> GetAssetBundleVersionList(ref string version)
        {
            version = PlayerPrefs.GetString(ConstDefine.ResourceVersion);
            string json = IOUtil.GetFileText(LocalVersionFilePath);
            return JsonMapper.ToObject<Dictionary<string, AssetBundleInfoEntity>>(json);
        }
        #endregion
    }
}