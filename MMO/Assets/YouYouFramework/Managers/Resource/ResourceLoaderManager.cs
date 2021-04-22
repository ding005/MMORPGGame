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
    /// 资源加载管理器
    /// </summary>
    public class ResourceLoaderManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 资源信息字典
        /// </summary>
        private Dictionary<AssetCategory, Dictionary<string, AssetEntity>> m_AssetInfoDic;

        /// <summary>
        /// 资源包加载器链表
        /// </summary>
        private LinkedList<AssetBundleLoaderRoutine> m_AssetBundleLoaderList;

        /// <summary>
        /// 资源加载器链表
        /// </summary>
        private LinkedList<AssetLoaderRoutine> m_AssetLoaderList;

        public ResourceLoaderManager()
        {
            m_AssetInfoDic = new Dictionary<AssetCategory, Dictionary<string, AssetEntity>>();
            m_AssetBundleLoaderList = new LinkedList<AssetBundleLoaderRoutine>();
            m_AssetLoaderList = new LinkedList<AssetLoaderRoutine>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            //确保游戏刚开始运行的时候 分类字典已经初始化好了
            var enumerator = Enum.GetValues(typeof(AssetCategory)).GetEnumerator();
            while (enumerator.MoveNext())
            {
                AssetCategory assetCategory = (AssetCategory)enumerator.Current;
                m_AssetInfoDic[assetCategory] = new Dictionary<string, AssetEntity>();
            }
        }

        #region 初始化资源信息

        #region InitAssetInfo 初始化资源信息

        /// <summary>
        /// 初始化资源信息完毕
        /// </summary>
        private BaseAction m_InitAssetInfoComplete;
        /// <summary>
        /// 初始化资源信息
        /// </summary>
        public void InitAssetInfo(BaseAction initAssetInfoComplete)
        {
            m_InitAssetInfoComplete = initAssetInfoComplete;

            byte[] buffer = GameEntry.Resource.ResourceManager.LocalAssetsManager.GetFileBuffer(ConstDefine.AssetInfoName);
            if (buffer == null)
            {
                //如果可写区没有 那么就从只读区获取
                GameEntry.Resource.ResourceManager.StreamingAssetsManager.ReadAssetBundle(ConstDefine.AssetInfoName, (byte[] buff) =>
                {
                    if (buff == null)
                    {
                        //如果只读区也没有，从CDN读取
                        string url = string.Format("{0}{1}", GameEntry.Data.SysDataManager.CurrChannelConfig.RealSourceUrl, ConstDefine.AssetInfoName);
                        GameEntry.Http.SendData(url, OnLoadAssetInfoFromCDN, isGetData: true);
                    }
                    else
                    {
                        InitAssetInfo(buff);
                    }
                });
            }
            else
            {
                InitAssetInfo(buffer);
            }
        }
        #endregion

        #region OnLoadAssetInfoFromCDN 从CDN加载资源信息
        /// <summary>
        /// 从CDN加载资源信息
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadAssetInfoFromCDN(HttpCallBackArgs args)
        {
            if (!args.HasError)
            {
                InitAssetInfo(args.Data);
            }
            else
            {
                GameEntry.Log(LogCategory.Resource, args.Value);
            }
        }
        #endregion

        #region InitAssetInfo 初始化资源信息
        /// <summary>
        /// 初始化资源信息
        /// </summary>
        /// <param name="buffer"></param>
        private void InitAssetInfo(byte[] buffer)
        {
            buffer = ZlibHelper.DeCompressBytes(buffer);

            MMO_MemoryStream ms = new MMO_MemoryStream(buffer);
            int len = ms.ReadInt();
            int depLen = 0;
            for (int i = 0; i < len; i++)
            {
                AssetEntity entity = new AssetEntity();
                entity.Category = (AssetCategory)ms.ReadByte();
                entity.AssetFullName = ms.ReadUTF8String();
                entity.AssetBundleName = ms.ReadUTF8String();
                depLen = ms.ReadInt();
                if (depLen > 0)
                {
                    entity.DependsAssetList = new List<AssetDependsEntity>(depLen);
                    for (int j = 0; j < depLen; j++)
                    {
                        AssetDependsEntity assetDepends = new AssetDependsEntity();
                        assetDepends.Category = (AssetCategory)ms.ReadByte();
                        assetDepends.AssetFullName = ms.ReadUTF8String();
                        entity.DependsAssetList.Add(assetDepends);
                    }
                }
                m_AssetInfoDic[entity.Category][entity.AssetFullName] = entity;
            }

            m_InitAssetInfoComplete?.Invoke();
        }


        #endregion

        #region GetAssetEntity 根据资源分类和资源路径获取资源信息
        /// <summary>
        /// 根据资源分类和资源路径获取资源信息
        /// </summary>
        /// <param name="assetCategory">资源分类</param>
        /// <param name="assetFullName">资源路径</param>
        /// <returns>资源信息</returns>
        public AssetEntity GetAssetEntity(AssetCategory assetCategory, string assetFullName)
        {
            Dictionary<string, AssetEntity> dicCategory = null;
            if (m_AssetInfoDic.TryGetValue(assetCategory, out dicCategory))
            {
                AssetEntity entity = null;
                if (dicCategory.TryGetValue(assetFullName, out entity))
                {
                    return entity;
                }
            }
            GameEntry.LogError("assetFullName=>{0}不存在", assetFullName);
            return null;
        }
        #endregion

        #endregion

        #region LoadAssetBundle 加载资源包

        /// <summary>
        /// 加载中的资源包
        /// </summary>
        private Dictionary<string, LinkedList<Action<AssetBundle>>> m_LoadingAssetBundle = new Dictionary<string, LinkedList<Action<AssetBundle>>>();

        /// <summary>
        /// 加载资源包
        /// </summary>
        /// <param name="assetbundlePath"></param>
        /// <param name="onUpdate"></param>
        /// <param name="onComplete"></param>
        public void LoadAssetBundle(string assetbundlePath, Action<float> onUpdate = null, Action<AssetBundle> onComplete = null)
        {
            //1.判断资源包是否存在于AssetBundlePool
            ResourceEntity assetBundleEntity = GameEntry.Pool.AssetBundlePool.Spawn(assetbundlePath);
            if (assetBundleEntity != null)
            {
                //说明资源在资源包池中存在
                AssetBundle assetbundle = assetBundleEntity.Target as AssetBundle;
                onComplete?.Invoke(assetbundle);
                return;
            }

            LinkedList<Action<AssetBundle>> lst = null;
            if (m_LoadingAssetBundle.TryGetValue(assetbundlePath, out lst))
            {
                //如果存在加载中的bundle 把委托加入对应的链表 然后直接返回
                lst.AddLast(onComplete);
                return;
            }
            else
            {
                lst = GameEntry.Pool.DequeueClassObject<LinkedList<Action<AssetBundle>>>();
                lst.AddLast(onComplete);
                m_LoadingAssetBundle[assetbundlePath] = lst;
            }

            AssetBundleLoaderRoutine routine = GameEntry.Pool.DequeueClassObject<AssetBundleLoaderRoutine>();
            if (routine == null)
            {
                routine = new AssetBundleLoaderRoutine();
            }

            //加入链表开始循环
            m_AssetBundleLoaderList.AddLast(routine);

            routine.LoadAssetBundle(assetbundlePath);
            routine.OnAssetBundleCreateUpdate = (float progress) =>
            {
                onUpdate?.Invoke(progress);
            };
            routine.OnLoadAssetBundleComplete = (AssetBundle assetbundle) =>
            {
                //把资源包注册到资源池
                assetBundleEntity = GameEntry.Pool.DequeueClassObject<ResourceEntity>();
                assetBundleEntity.ResourceName = assetbundlePath;
                assetBundleEntity.IsAssetBundle = true;
                assetBundleEntity.Target = assetbundle;
                GameEntry.Pool.AssetBundlePool.Register(assetBundleEntity);

                for (LinkedListNode<Action<AssetBundle>> curr = lst.First; curr != null; curr = curr.Next)
                {
                    curr.Value?.Invoke(assetbundle);
                }

                lst.Clear(); //一定要清空
                GameEntry.Pool.EnqueueClassObject(lst);
                m_LoadingAssetBundle.Remove(assetbundlePath); //资源包加载完毕 从加载中字典移除

                //结束循环 回池
                m_AssetBundleLoaderList.Remove(routine);
                GameEntry.Pool.EnqueueClassObject(routine);
            };
        }
        #endregion

        #region LoadAsset 从资源包中加载资源

        /// <summary>
        /// 加载中的资源
        /// </summary>
        private Dictionary<string, LinkedList<Action<UnityEngine.Object>>> m_LoadingAsset = new Dictionary<string, LinkedList<Action<UnityEngine.Object>>>();

        /// <summary>
        /// 从资源包中加载资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="assetBundle"></param>
        /// <param name="onUpdate"></param>
        /// <param name="onComplete"></param>
        public void LoadAsset(string assetName, AssetBundle assetBundle, Action<float> onUpdate = null, Action<UnityEngine.Object> onComplete = null)
        {
            LinkedList<Action<UnityEngine.Object>> lst = null;
            if (m_LoadingAsset.TryGetValue(assetName, out lst))
            {
                //如果存在加载中的asset 把委托加入对应的链表 然后直接返回
                lst.AddLast(onComplete);
                return;
            }
            else
            {
                lst = GameEntry.Pool.DequeueClassObject<LinkedList<Action<UnityEngine.Object>>>();
                lst.AddLast(onComplete);
                m_LoadingAsset[assetName] = lst;
            }

            AssetLoaderRoutine routine = GameEntry.Pool.DequeueClassObject<AssetLoaderRoutine>();
            if (routine == null)
            {
                routine = new AssetLoaderRoutine();
            }

            //加入链表开始循环
            m_AssetLoaderList.AddLast(routine);

            routine.LoadAsset(assetName, assetBundle);
            routine.OnAssetUpdate = (float progress) =>
            {
                onUpdate?.Invoke(progress);
            };
            routine.OnLoadAssetComplete = (UnityEngine.Object obj) =>
            {
                for (LinkedListNode<Action<UnityEngine.Object>> curr = lst.First; curr != null; curr = curr.Next)
                {
                    curr.Value?.Invoke(obj);
                }

                lst.Clear(); //一定要清空
                GameEntry.Pool.EnqueueClassObject(lst);
                m_LoadingAsset.Remove(assetName); //资源包加载完毕 从加载中字典移除

                //结束循环 回池
                m_AssetLoaderList.Remove(routine);
                GameEntry.Pool.EnqueueClassObject(routine);
            };
        }
        #endregion

        /// <summary>
        /// 加载主资源
        /// </summary>
        /// <param name="assetCategory">资源分类</param>
        /// <param name="assetFullName">资源路径</param>
        /// <param name="onComplete"></param>
        public void LoadMainAsset(AssetCategory assetCategory, string assetFullName, BaseAction<ResourceEntity> onComplete = null)
        {
            MainAssetLoaderRoutine routine = GameEntry.Pool.DequeueClassObject<MainAssetLoaderRoutine>();
            routine.Load(assetCategory, assetFullName, (ResourceEntity resEntity) =>
            {
                onComplete?.Invoke(resEntity);
            });
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="gameObject"></param>
        public void UnLoadGameObject(GameObject gameObject)
        {
            GameEntry.Pool.ReleaseInstanceResource(gameObject.GetInstanceID());
        }

        /// <summary>
        /// 更新
        /// </summary>
        public void OnUpdate()
        {
            for (LinkedListNode<AssetBundleLoaderRoutine> curr = m_AssetBundleLoaderList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate();
            }

            for (LinkedListNode<AssetLoaderRoutine> curr = m_AssetLoaderList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate();
            }
        }

        public void Dispose()
        {
            m_AssetInfoDic.Clear();
            m_AssetBundleLoaderList.Clear();
        }
    }
}