//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public class UIPool
    {
        /// <summary>
        /// 对象池中的列表
        /// </summary>
        private LinkedList<UIFormBase> m_UIFormList;

        public UIPool()
        {
            m_UIFormList = new LinkedList<UIFormBase>();
        }

        /// <summary>
        /// 从UI对象池中获取UI
        /// </summary>
        /// <param name="uiformId"></param>
        /// <returns></returns>
        internal UIFormBase Dequeue(int uiformId)
        {
            for (LinkedListNode<UIFormBase> curr = m_UIFormList.First; curr != null; curr = curr.Next)
            {
                if (curr.Value.UIFormId == uiformId)
                {
                    m_UIFormList.Remove(curr.Value);
                    return curr.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// UI回池
        /// </summary>
        /// <param name="form"></param>
        internal void Enqueue(UIFormBase form)
        {
            GameEntry.UI.HideUI(form);
            m_UIFormList.AddLast(form);
        }

        /// <summary>
        /// 检查是否可以释放
        /// </summary>
        internal void CheckClear()
        {
            for (LinkedListNode<UIFormBase> curr = m_UIFormList.First; curr != null;)
            {
                if (!curr.Value.IsLock && Time.time > (curr.Value.CloseTime + GameEntry.UI.UIExpire))
                {
                    //销毁UI
                    Object.Destroy(curr.Value.gameObject);
                    GameEntry.Pool.ReleaseInstanceResource(curr.Value.gameObject.GetInstanceID());

                    LinkedListNode<UIFormBase> next = curr.Next;
                    m_UIFormList.Remove(curr.Value);
                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }

        /// <summary>
        /// 打开UI时候检查队列
        /// </summary>
        internal void CheckByOpenUI()
        {
            if (m_UIFormList.Count <= GameEntry.UI.UIPoolMaxCount) return;

            for (LinkedListNode<UIFormBase> curr = m_UIFormList.First; curr != null;)
            {
                if (m_UIFormList.Count == GameEntry.UI.UIPoolMaxCount + 1)
                {
                    //如果池中的数量  在指定数量以内 则不再继续销毁
                    break;
                }

                if (!curr.Value.IsLock)
                {
                    LinkedListNode<UIFormBase> next = curr.Next;
                    m_UIFormList.Remove(curr.Value);

                    //销毁UI
                    Object.Destroy(curr.Value.gameObject);
                    GameEntry.Pool.ReleaseInstanceResource(curr.Value.gameObject.GetInstanceID());

                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }
    }
}