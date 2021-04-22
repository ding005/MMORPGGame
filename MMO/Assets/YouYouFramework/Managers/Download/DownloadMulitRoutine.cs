using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ���ļ�������
    /// </summary>
    public class DownloadMulitRoutine : IDisposable
    {
        public DownloadMulitRoutine()
        {
            m_DownloadRoutineList = new LinkedList<DownloadRoutine>();
            m_NeedDownloadList = new LinkedList<string>();
            m_DownloadMulitCurrSizeDic = new Dictionary<string, ulong>();
        }

        public void Dispose()
        {
            m_DownloadRoutineList.Clear();
            m_NeedDownloadList.Clear();
            m_DownloadMulitCurrSizeDic.Clear();
        }

        /// <summary>
        /// ����
        /// </summary>
        public void OnUpdate()
        {
            var curr = m_DownloadRoutineList.First;
            while (curr != null)
            {
                curr.Value.OnUpdate();
                curr = curr.Next;
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        private LinkedList<DownloadRoutine> m_DownloadRoutineList;

        /// <summary>
        /// ��Ҫ���ص��ļ�����
        /// </summary>
        private LinkedList<string> m_NeedDownloadList;

        #region ���ض���ļ�
        /// <summary>
        /// ����ļ�������ί��
        /// </summary>
        private BaseAction<int, int, ulong, ulong> m_OnDownloadMulitUpdate;

        /// <summary>
        /// ����ļ��������ί��
        /// </summary>
        private BaseAction<DownloadMulitRoutine> m_OnDownloadMulitComplete;

        /// <summary>
        /// ����ļ�������Ҫ���ص�����
        /// </summary>
        private int m_DownloadMulitNeedCount = 0;

        /// <summary>
        /// ����ļ����ص�ǰ���ص�����
        /// </summary>
        private int m_DownloadMulitCurrCount = 0;

        /// <summary>
        /// ����ļ������ܴ�С(�ֽ�)
        /// </summary>
        private ulong m_DownloadMulitTotalSize = 0;

        /// <summary>
        /// ����ļ����ص�ǰ��С(�ֽ�)
        /// </summary>
        private ulong m_DownloadMulitCurrSize = 0;

        /// <summary>
        /// ����ļ����ص�ǰ��С
        /// </summary>
        private Dictionary<string, ulong> m_DownloadMulitCurrSizeDic;

        /// <summary>
        /// ���ض���ļ�
        /// </summary>
        /// <param name="lstUrl"></param>
        /// <param name="onDownloadMulitUpdate"></param>
        /// <param name="onDownloadMulitComplete"></param>
        public void BeginDownloadMulit(LinkedList<string> lstUrl, BaseAction<int, int, ulong, ulong> onDownloadMulitUpdate = null, BaseAction<DownloadMulitRoutine> onDownloadMulitComplete = null)
        {
            m_OnDownloadMulitUpdate = onDownloadMulitUpdate;
            m_OnDownloadMulitComplete = onDownloadMulitComplete;

            m_NeedDownloadList.Clear();
            m_DownloadMulitCurrSizeDic.Clear();

            m_DownloadMulitNeedCount = 0;
            m_DownloadMulitCurrCount = 0;

            m_DownloadMulitTotalSize = 0;
            m_DownloadMulitCurrSize = 0;

            //1.����Ҫ���صļ������ض���
            for (LinkedListNode<string> item = lstUrl.First; item != null; item = item.Next)
            {
                string url = item.Value;
                AssetBundleInfoEntity entity = GameEntry.Resource.ResourceManager.GetAssetBundleInfo(url);
                if (entity != null)
                {
                    m_DownloadMulitTotalSize += entity.Size;
                    m_DownloadMulitNeedCount++;
                    m_NeedDownloadList.AddLast(url);
                    m_DownloadMulitCurrSizeDic[url] = 0;
                }
                else
                {
                    GameEntry.LogError("��Ч��Դ��=>" + url);
                }
            }

            //���������� ���5��
            int routineCount = Mathf.Min(GameEntry.Download.DownloadRoutineCount, m_NeedDownloadList.Count);

            for (int i = 0; i < routineCount; i++)
            {
                DownloadRoutine routine = GameEntry.Pool.DequeueClassObject<DownloadRoutine>();

                string url = m_NeedDownloadList.First.Value;
                m_NeedDownloadList.RemoveFirst();

                AssetBundleInfoEntity entity = GameEntry.Resource.ResourceManager.GetAssetBundleInfo(url);
                routine.BeginDownload(url, entity, OnDownloadMulitUpdate, OnDownloadMulitComplete);
                m_DownloadRoutineList.AddLast(routine);
            }
        }

        /// <summary>
        /// ���ļ������лص�
        /// </summary>
        /// <param name="url"></param>
        /// <param name="currDownloadedSize"></param>
        /// <param name="progress"></param>
        private void OnDownloadMulitUpdate(string url, ulong currDownloadedSize, float progress)
        {
            m_DownloadMulitCurrSizeDic[url] = currDownloadedSize;

            ulong currSize = 0;
            var enumerator = m_DownloadMulitCurrSizeDic.GetEnumerator();
            while (enumerator.MoveNext())
            {
                currSize += enumerator.Current.Value;
            }

            m_DownloadMulitCurrSize = currSize;

            if (m_DownloadMulitCurrSize > m_DownloadMulitTotalSize)
            {
                m_DownloadMulitCurrSize = m_DownloadMulitTotalSize;
            }

            m_OnDownloadMulitUpdate?.Invoke(m_DownloadMulitCurrCount, m_DownloadMulitNeedCount, m_DownloadMulitCurrSize, m_DownloadMulitTotalSize);
        }

        /// <summary>
        /// ���ļ�������ϻص�
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="routine"></param>
        private void OnDownloadMulitComplete(string fileUrl, DownloadRoutine routine)
        {
            //���������Ƿ���Ҫ���ص�����
            if (m_NeedDownloadList.Count > 0)
            {
                //����������������
                string url = m_NeedDownloadList.First.Value;
                m_NeedDownloadList.RemoveFirst();
                //Debug.LogError("���������������� ����="+ url);

                AssetBundleInfoEntity entity = GameEntry.Resource.ResourceManager.GetAssetBundleInfo(url);
                routine.BeginDownload(url, entity, OnDownloadMulitUpdate, OnDownloadMulitComplete);
            }
            else
            {
                m_DownloadRoutineList.Remove(routine);
                GameEntry.Pool.EnqueueClassObject(routine);
            }

            m_DownloadMulitCurrCount++;

            m_OnDownloadMulitUpdate?.Invoke(m_DownloadMulitCurrCount, m_DownloadMulitNeedCount, m_DownloadMulitCurrSize, m_DownloadMulitTotalSize);

            if (m_DownloadMulitCurrCount == m_DownloadMulitNeedCount)
            {
                //������ʱ�� ֱ�Ӱѵ�ǰ���صĴ�С����Ϊ�ܴ�С
                m_DownloadMulitCurrSize = m_DownloadMulitTotalSize;
                m_OnDownloadMulitUpdate?.Invoke(m_DownloadMulitCurrCount, m_DownloadMulitNeedCount, m_DownloadMulitCurrSize, m_DownloadMulitTotalSize);

                m_OnDownloadMulitComplete?.Invoke(this);
            }
        }
        #endregion
    }
}