using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 事件管理器
    /// </summary>
    public class EventManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// Socket事件
        /// </summary>
        public SocketEvent SocketEvent
        {
            private set;
            get;
        }

        /// <summary>
        /// 通用事件
        /// </summary>
        public CommonEvent CommonEvent
        {
            private set;
            get;
        }

        public EventManager()
        {
            SocketEvent = new SocketEvent();
            CommonEvent = new CommonEvent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {

        }

        public void Dispose()
        {
            SocketEvent.Dispose();
            CommonEvent.Dispose();
        }
    }
}