using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 数据管理器
    /// </summary>
    public class DataManager : ManagerBase
    {
        /// <summary>
        /// 临时缓存数据
        /// </summary>
        public CacheDataManager CacheDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// 系统相关数据
        /// </summary>
        public SysDataManager SysDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户相关数据
        /// </summary>
        public UserDataManager UserDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// 关卡地图数据
        /// </summary>
        public PVEMapDataManager PVEMapDataManager
        {
            get;
            private set;
        }

        public DataManager()
        {
            CacheDataManager = new CacheDataManager();
            SysDataManager = new SysDataManager();
            UserDataManager = new UserDataManager();
            PVEMapDataManager = new PVEMapDataManager();
        }

        public override void Init()
        {
            
        }

        public void Dispose()
        {
            CacheDataManager.Dispose();
            SysDataManager.Dispose();
            UserDataManager.Dispose();
            PVEMapDataManager.Dispose();
        }
    }
}