using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace YouYou
{
    /// <summary>
    /// YouYouUI管理器
    /// </summary>
    public class YouYouUIManager : ManagerBase, IDisposable
    {
        private Dictionary<byte, UIGroup> m_UIGroupDic;

        /// <summary>
        /// 标准分辨率比值
        /// </summary>
        private float m_StandardScreen = 0;

        /// <summary>
        /// 当前分辨率比值
        /// </summary>
        private float m_CurrScreen = 0;

        private UIManager m_UIManager;

        private UILayer m_UILayer;

        private UIPool m_UIPool;

        /// <summary>
        /// 释放间隔(秒)
        /// </summary>
        public int UIClearInterval
        {
            get;
            private set;
        }

        /// <summary>
        /// UI回池后过期时间
        /// </summary>
        public int UIExpire
        {
            get;
            private set;
        }

        /// <summary>
        /// UI对象池中 最大的数量
        /// </summary>
        public int UIPoolMaxCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 下次运行时间
        /// </summary>
        private float m_NextRunTime = 0f;

        public YouYouUIManager()
        {
            m_UIManager = new UIManager();
            m_UILayer = new UILayer();
            m_UIPool = new UIPool();
            m_UIGroupDic = new Dictionary<byte, UIGroup>();
        }

        public override void Init()
        {
            UIPoolMaxCount = GameEntry.ParamsSettings.GetGradeParamData(ConstDefine.UI_PoolMaxCount, GameEntry.CurrDeviceGrade);
            UIExpire = GameEntry.ParamsSettings.GetGradeParamData(ConstDefine.UI_Expire, GameEntry.CurrDeviceGrade);
            UIClearInterval = GameEntry.ParamsSettings.GetGradeParamData(ConstDefine.UI_ClearInterval, GameEntry.CurrDeviceGrade);

            m_StandardScreen = GameEntry.Instance.StandardWidth / (float)GameEntry.Instance.StandardHeight;
            m_CurrScreen = Screen.width / (float)Screen.height;

            NormalFormCanvasScaler();
            int len = GameEntry.Instance.UIGroups.Length;
            for (int i = 0; i < len; i++)
            {
                UIGroup group = GameEntry.Instance.UIGroups[i];
                m_UIGroupDic[group.Id] = group;
            }

            m_UILayer.Init(GameEntry.Instance.UIGroups);
        }

        #region UI适配
        /// <summary>
        /// LoadingForm适配缩放
        /// </summary>
        public void LoadingFormCanvasScaler()
        {
            if (m_CurrScreen > m_StandardScreen)
            {
                //设置为0
                GameEntry.Instance.UIRootCanvasScaler.matchWidthOrHeight = 0;
            }
            else
            {
                GameEntry.Instance.UIRootCanvasScaler.matchWidthOrHeight = m_StandardScreen - m_CurrScreen;
            }
        }

        /// <summary>
        /// FullForm适配缩放
        /// </summary>
        public void FullFormCanvasScaler()
        {
            GameEntry.Instance.UIRootCanvasScaler.matchWidthOrHeight = 1;
        }

        /// <summary>
        /// NormalForm适配缩放
        /// </summary>
        public void NormalFormCanvasScaler()
        {
            GameEntry.Instance.UIRootCanvasScaler.matchWidthOrHeight = (m_CurrScreen >= m_StandardScreen) ? 1 : 0;
        }
        #endregion

        #region GetUIGroup 根据UI分组编号获取UI分组
        /// <summary>
        /// 根据UI分组编号获取UI分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UIGroup GetUIGroup(byte id)
        {
            UIGroup group = null;
            m_UIGroupDic.TryGetValue(id, out group);
            return group;
        }
        #endregion

        /// <summary>
        /// 打开UI窗体
        /// </summary>
        /// <param name="uiFormId">formId</param>
        /// <param name="userData"></param>
        public void OpenUIForm(int uiFormId, object userData = null, BaseAction<UIFormBase> onOpen = null)
        {
            m_UIManager.OpenUIForm(uiFormId, userData, onOpen);
            m_UIPool.CheckByOpenUI();
        }

        /// <summary>
        /// 根据UIFormId关闭UI
        /// </summary>
        /// <param name="uiformId"></param>
        public void CloseUIForm(int uiformId)
        {
            m_UIManager.CloseUIForm(uiformId);
        }

        public void CloseUIForm(UIFormBase formBase)
        {
            m_UIManager.CloseUIForm(formBase);
        }

        /// <summary>
        /// 显示/激活一个UI
        /// </summary>
        /// <param name="uiFormBase"></param>
        public void ShowUI(UIFormBase uiFormBase)
        {
            if (uiFormBase.SysUIForm.FreezeMode == 0)
            {
                uiFormBase.IsActive = true;
                uiFormBase.CurrCanvas.enabled = true;
                uiFormBase.gameObject.layer = 5;
            }
            else
            {
                uiFormBase.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// 隐藏/冻结一个UI
        /// </summary>
        /// <param name="uiFormBase"></param>
        public void HideUI(UIFormBase uiFormBase)
        {
            if (uiFormBase.SysUIForm.FreezeMode == 0)
            {
                uiFormBase.IsActive = false;
                uiFormBase.CurrCanvas.enabled = false;
                uiFormBase.gameObject.layer = 0;
            }
            else
            {
                uiFormBase.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 设置层级
        /// </summary>
        /// <param name="formBase"></param>
        /// <param name="isAdd"></param>
        public void SetSortingOrder(UIFormBase formBase, bool isAdd)
        {
            m_UILayer.SetSortingOrder(formBase, isAdd);
        }

        /// <summary>
        /// 从UI对象池中获取UI
        /// </summary>
        /// <param name="uiformId"></param>
        /// <returns></returns>
        public UIFormBase Dequeue(int uiformId)
        {
            return m_UIPool.Dequeue(uiformId);
        }

        /// <summary>
        /// UI回池
        /// </summary>
        /// <param name="form"></param>
        public void Enqueue(UIFormBase form)
        {
            m_UIPool.Enqueue(form);
        }

        public void OnUpdate()
        {
            if (Time.time > m_NextRunTime + UIClearInterval)
            {
                m_NextRunTime = Time.time;

                //释放UI对象池
                m_UIPool.CheckClear();
            }
        }

        /// <summary>
        /// 打开提示对话框
        /// </summary>
        /// <param name="sysCode">系统码</param>
        /// <param name="dialogFormType">对话框类型</param>
        /// <param name="onConfirm">确认回调</param>
        /// <param name="onCancel">取消回调</param>
        public void OpenDialogFormBySysCode(int sysCode, DialogFormType dialogFormType = DialogFormType.Normal, BaseAction onConfirm = null, BaseAction onCancel = null)
        {
            OpenDialogForm(dialogFormType, GameEntry.Data.SysDataManager.GetSysCodeContent(sysCode), null, onConfirm, onCancel);
        }


        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="dialogFormType">对话框类型</param>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="onConfirm">确认回调</param>
        /// <param name="onCancel">取消回调</param>
        public void OpenDialogForm(DialogFormType dialogFormType, string content, string title = null, BaseAction onConfirm = null, BaseAction onCancel = null)
        {
            BaseParams baseParams = GameEntry.Pool.DequeueClassObject<BaseParams>();
            baseParams.Reset();

            baseParams.IntParam1 = (int)dialogFormType;
            baseParams.StringParam1 = content;
            baseParams.StringParam2 = title;
            baseParams.ActionParam1 = onConfirm;
            baseParams.ActionParam2 = onCancel;
            OpenUIForm(UIFormId.UI_Dialog, baseParams);
        }

        public void Dispose()
        {
            
        }
    }
}