using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ���ݹ�����
    /// </summary>
    public class DataManager : ManagerBase
    {
        /// <summary>
        /// ��ʱ��������
        /// </summary>
        public CacheDataManager CacheDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// ϵͳ�������
        /// </summary>
        public SysDataManager SysDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// �û��������
        /// </summary>
        public UserDataManager UserDataManager
        {
            get;
            private set;
        }

        /// <summary>
        /// �ؿ���ͼ����
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