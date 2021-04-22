using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// YouYou�������
    /// </summary>
    public abstract class YouYouComponent : MonoBehaviour
    {
        #region InstanceId ���ʵ�����
        /// <summary>
        /// ���ʵ�����
        /// </summary>
        private int m_InstanceId;

        /// <summary>
        /// ���ʵ�����
        /// </summary>
        public int InstanceId
        {
            get { return m_InstanceId; }
        }
        #endregion

        private void Awake()
        {
            m_InstanceId = GetInstanceID();
            
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void OnDestroy()
        {
            BeforOnDestroy();
        }

        protected virtual void OnAwake() { }

        protected virtual void OnStart() { }

        protected virtual void BeforOnDestroy() { }

        /// <summary>
        /// �رշ���
        /// </summary>
        public abstract void Shutdown();
    }
}