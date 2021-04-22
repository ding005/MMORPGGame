using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public class TimeManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// ��ʱ������
        /// </summary>
        private LinkedList<TimeAction> m_TimeActionList;

        public TimeManager()
        {
            m_TimeActionList = new LinkedList<TimeAction>();
        }

        public override void Init()
        {

        }

        /// <summary>
        /// ע�ᶨʱ��
        /// </summary>
        /// <param name="action"></param>
        internal void RegisterTimeAction(TimeAction action)
        {
            m_TimeActionList.AddLast(action);
        }

        /// <summary>
        /// �Ƴ���ʱ��
        /// </summary>
        /// <param name="action"></param>
        internal void RemoveTimeAction(TimeAction action)
        {
            m_TimeActionList.Remove(action);
        }

        /// <summary>
        /// ���ݶ�ʱ��������ɾ����ʱ��
        /// </summary>
        /// <param name="timeName"></param>
        public void RemoveTimeActionByName(string timeName)
        {
            LinkedListNode<TimeAction> curr = m_TimeActionList.First;
            while (curr != null)
            {
                if (curr.Value.TimeName.Equals(timeName, StringComparison.CurrentCultureIgnoreCase))
                {
                    m_TimeActionList.Remove(curr);
                    break;
                }
                curr = curr.Next;
            }
        }

        internal void OnUpdate()
        {
            for (LinkedListNode<TimeAction> curr = m_TimeActionList.First; curr != null; curr = curr.Next)
            {
                if (curr.Value.OnStarAction.Target == null || curr.Value.OnStarAction.Target.ToString() == "null")
                {
                    m_TimeActionList.Remove(curr);
                    continue;
                }
                if (curr.Value.OnUpdateAction.Target == null || curr.Value.OnUpdateAction.Target.ToString() == "null")
                {
                    m_TimeActionList.Remove(curr);
                    continue;
                }
                if (curr.Value.OnCompleteAction.Target == null || curr.Value.OnCompleteAction.Target.ToString() == "null")
                {
                    m_TimeActionList.Remove(curr);
                    continue;
                }
                curr.Value.OnUpdate();
            }
        }

        public void Dispose()
        {
            m_TimeActionList.Clear();
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <returns></returns>
        public TimeAction CreateTimeAction()
        {
            return GameEntry.Pool.DequeueClassObject<TimeAction>();
        }

        #region YieldCoroutine ��һ֡
        /// <summary>
        /// ��һ֡
        /// </summary>
        /// <param name="onComplete"></param>
        public void Yield(BaseAction onComplete)
        {
            GameEntry.Instance.StartCoroutine(YieldCoroutine(onComplete));
        }

        private IEnumerator YieldCoroutine(BaseAction onComplete)
        {
            yield return null;
            if (onComplete != null)
            {
                onComplete();
            }
        }
        #endregion
    }
}