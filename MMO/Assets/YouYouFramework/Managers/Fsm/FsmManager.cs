using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 状态机管理器
    /// </summary>
    public class FsmManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// 状态机字典
        /// </summary>
        private Dictionary<int, FsmBase> m_FsmDic;

        public FsmManager()
        {
            m_FsmDic = new Dictionary<int, FsmBase>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {

        }

        /// <summary>
        /// 状态机的临时编号
        /// </summary>
        private int m_TemFsmId = 0;

        #region Create 创建状态机
        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者类型</typeparam>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        /// <returns></returns>
        public Fsm<T> Create<T>(T owner, FsmState<T>[] states) where T : class
        {
            return Create<T>(m_TemFsmId++, owner, states);
        }
        #endregion

        #region Create 创建状态机
        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者类型</typeparam>
        /// <param name="fsmId">状态机编号</param>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        /// <returns></returns>
        public Fsm<T> Create<T>(int fsmId, T owner, FsmState<T>[] states) where T : class
        {
            Fsm<T> fsm = new Fsm<T>(fsmId, owner, states);
            m_FsmDic[fsmId] = fsm;
            return fsm;
        }
        #endregion

        #region DestroyFsm 销毁状态机
        /// <summary>
        /// 销毁状态机
        /// </summary>
        /// <param name="fsmId"></param>
        public void DestroyFsm(int fsmId)
        {
            FsmBase fsm = null;
            if (m_FsmDic.TryGetValue(fsmId, out fsm))
            {
                fsm.ShutDown();
                m_FsmDic.Remove(fsmId);
            }
        }
        #endregion

        public void Dispose()
        {
            var enumerator = m_FsmDic.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.ShutDown();
            }
            m_FsmDic.Clear();
        }
    }
}