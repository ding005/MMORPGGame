using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public class HttpManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 正式账号服务器Url
        /// </summary>
        private string m_WebAccountUrl;

        /// <summary>
        /// 测试账号服务器Url
        /// </summary>
        private string m_TestWebAccountUrl;

        /// <summary>
        /// 是否测试环境
        /// </summary>
        private bool m_IsTest;

        /// <summary>
        /// 真实账号服务器Url
        /// </summary>
        public string RealWebAccountUrl
        {
            get
            {
                return m_IsTest ? m_TestWebAccountUrl : m_WebAccountUrl;
            }
        }

        /// <summary>
        /// 连接失败后重试次数
        /// </summary>
        public int Retry
        {
            get;
            private set;
        }

        /// <summary>
        /// 连接失败后重试间隔（秒）
        /// </summary>
        public int RetryInterval
        {
            get;
            private set;
        }

        public void Dispose()
        {

        }

        public override void Init()
        {
            m_WebAccountUrl = GameEntry.ParamsSettings.WebAccountUrl;
            m_TestWebAccountUrl = GameEntry.ParamsSettings.TestWebAccountUrl;
            m_IsTest = GameEntry.ParamsSettings.IsTest;

            Retry = GameEntry.ParamsSettings.GetGradeParamData(ConstDefine.Http_Retry, GameEntry.CurrDeviceGrade);
            RetryInterval = GameEntry.ParamsSettings.GetGradeParamData(ConstDefine.Http_RetryInterval, GameEntry.CurrDeviceGrade);
        }

        /// <summary>
        /// 发送Http数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="callBack"></param>
        /// <param name="isPost"></param>
        /// <param name="isGetData"></param>
        /// <param name="dic"></param>
        public void SendData(string url, HttpSendDataCallBack callBack, bool isPost = false, bool isGetData = false, Dictionary<string, object> dic = null)
        {
            //Debug.Log("从池中获取Http访问器");

            HttpRoutine http = GameEntry.Pool.DequeueClassObject<HttpRoutine>();
            http.SendData(url, callBack, isPost, isGetData, dic);
        }
    }
}