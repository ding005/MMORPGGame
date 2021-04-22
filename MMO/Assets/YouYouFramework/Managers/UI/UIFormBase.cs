//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using UnityEngine;
using YouYou.DataTable;

namespace YouYou
{
    public class UIFormBase : MonoBehaviour
    {
        /// <summary>
        /// 是否活跃
        /// </summary>
        protected internal bool IsActive;

        /// <summary>
        /// UI窗体编号
        /// </summary>
        public int UIFormId
        {
            get;
            private set;
        }

        public Sys_UIForm SysUIForm
        {
            get;
            private set;
        }

        /// <summary>
        /// 分组编号
        /// </summary>
        public byte GroupId
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前画布
        /// </summary>
        public Canvas CurrCanvas
        {
            get;
            private set;
        }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public float CloseTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 禁用层级管理
        /// </summary>
        public bool DisableUILayer
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        private BaseAction m_InitComplate;

        private void Awake()
        {
            CurrCanvas = GetComponent<Canvas>();
        }

        internal void Init(int uiFormId, Sys_UIForm sysUIForm, byte groupId, bool disableUILayer, bool isLock, object userData, BaseAction initComplate)
        {
            UIFormId = uiFormId;
            SysUIForm = sysUIForm;
            GroupId = groupId;
            DisableUILayer = disableUILayer;
            IsLock = isLock;
            UserData = userData;
            m_InitComplate = initComplate;
        }

        private void Start()
        {
            OnInit(UserData);
            m_InitComplate?.Invoke();
            Open(UserData, true);
        }

        internal void Open(object userData, bool isFromInit = false)
        {
            GameEntry.Audio.PlayAudio(ConstDefine.Aduio_ButtonClick);
            if (!isFromInit)
            {
                UserData = userData;
            }

            if (!DisableUILayer)
            {
                //进行层级管理 增加层级
                GameEntry.UI.SetSortingOrder(this, true);
            }

            OnOpen(UserData);
        }

        public void Close()
        {
            GameEntry.UI.CloseUIForm(this);
        }


        public void ToClose()
        {
            GameEntry.Audio.PlayAudio(ConstDefine.Aduio_UIClose);
            if (!DisableUILayer)
            {
                //进行层级管理 减少层级
                GameEntry.UI.SetSortingOrder(this, false);
            }

            OnClose();

            CloseTime = Time.time;
            GameEntry.UI.Enqueue(this);
        }

        private void OnDestroy()
        {
            OnBeforDestroy();
        }

        protected virtual void OnInit(object userData) { }
        protected virtual void OnOpen(object userData) { }
        protected virtual void OnClose() { }
        protected virtual void OnBeforDestroy() { }
    }
}