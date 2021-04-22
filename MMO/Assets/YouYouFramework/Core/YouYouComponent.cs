using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// YouYou组件基类
    /// </summary>
    public abstract class YouYouComponent : MonoBehaviour
    {
        #region InstanceId 组件实例编号
        /// <summary>
        /// 组件实例编号
        /// </summary>
        private int m_InstanceId;

        /// <summary>
        /// 组件实例编号
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
        /// 关闭方法
        /// </summary>
        public abstract void Shutdown();
    }
}