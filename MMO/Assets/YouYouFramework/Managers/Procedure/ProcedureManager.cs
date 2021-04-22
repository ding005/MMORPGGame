using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public enum ProcedureState
    {
        Launch = 0,
        CheckVersion = 1,
        Preload = 2,
        ChangeScene = 3,
        LogOn = 4,
        SelectRole = 5,
        EnterGame = 6,
        WorldMap = 7,
        GameLevel = 8
    }

    /// <summary>
    /// ���̹�����
    /// </summary>
    public class ProcedureManager : ManagerBase, System.IDisposable
    {
        /// <summary>
        /// ����״̬��
        /// </summary>
        private Fsm<ProcedureManager> m_CurrFsm;

        /// <summary>
        /// ��ǰ����״̬��
        /// </summary>
        public Fsm<ProcedureManager> CurrFsm
        {
            get
            {
                return m_CurrFsm;
            }
        }

        /// <summary>
        /// ��ǰ������״̬
        /// </summary>
        public ProcedureState CurrProcedureState
        {
            get
            {
                if (m_CurrFsm == null)
                {
                    return ProcedureState.Launch;
                }
                return (ProcedureState)m_CurrFsm.CurrStateType;
            }
        }

        /// <summary>
        /// ��ǰ������
        /// </summary>
        public FsmState<ProcedureManager> CurrProcedure
        {
            get
            {
                return m_CurrFsm.GetState(m_CurrFsm.CurrStateType);
            }
        }

        public ProcedureManager()
        {

        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        public override void Init()
        {
            FsmState<ProcedureManager>[] states = new FsmState<ProcedureManager>[9];
            states[0] = new ProcedureLaunch();
            states[1] = new ProcedureCheckVersion();
            states[2] = new ProcedurePreload();
            states[3] = new ProcedureChangeScene();
            states[4] = new ProcedureLogOn();
            states[5] = new ProcedureSelectRole();
            states[6] = new ProcedureEnterGame();
            states[7] = new ProcedureWorldMap();
            states[8] = new ProcedureGameLevel();

            m_CurrFsm = GameEntry.Fsm.Create(this, states);
        }

        /// <summary>
        /// �л�״̬
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureState state)
        {
            m_CurrFsm.ChangeState((sbyte)state);
        }

        public void OnUpdate()
        {
            m_CurrFsm.OnUpate();
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// ���ò���ֵ
        /// </summary>
        /// <typeparam name="TData">��������</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key, TData value)
        {
            CurrFsm.SetData<TData>(key, value);
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            return CurrFsm.GetData<TData>(key);
        }
    }
}