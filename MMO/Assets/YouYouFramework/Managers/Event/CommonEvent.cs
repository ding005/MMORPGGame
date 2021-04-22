using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace YouYou
{
    /// <summary>
    /// 通用事件
    /// </summary>
    public class CommonEvent: IDisposable
    {
        [LuaCallCSharp]
        [CSharpCallLua]
        public delegate void OnActionHandler(object userData);
        public Dictionary<ushort, LinkedList<OnActionHandler>> dic = new Dictionary<ushort, LinkedList<OnActionHandler>>();

        #region AddEventListener 添加监听
        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void AddEventListener(ushort key, OnActionHandler handler)
        {
            LinkedList<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);
            if (lstHandler == null)
            {
                lstHandler = new LinkedList<OnActionHandler>();
                dic[key] = lstHandler;
            }

            lstHandler.AddLast(handler);
        }
        #endregion

        #region RemoveEventListener 移除监听
        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(ushort key, OnActionHandler handler)
        {
            LinkedList<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);

            if (lstHandler != null)
            {
                lstHandler.Remove(handler);
                if (lstHandler.Count == 0)
                {
                    dic.Remove(key);
                }
            }
        }
        #endregion

        #region Dispatch 派发
        /// <summary>
        /// 派发
        /// </summary>
        /// <param name="key"></param>
        /// <param name="p"></param>
        public void Dispatch(ushort key, object userData = null)
        {
            LinkedList<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);

            if (lstHandler != null)
            {
                for (LinkedListNode<OnActionHandler> curr = lstHandler.First; curr != null; curr = curr.Next)
                {
                    OnActionHandler handler = curr.Value;
                    if (handler != null)
                    {
                        handler(userData);
                    }
                }
            }
        }
        #endregion

        public void Dispose()
        {
            dic.Clear();
        }
    }
}