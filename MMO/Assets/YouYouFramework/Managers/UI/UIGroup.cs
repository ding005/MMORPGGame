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
    /// <summary>
    /// UI分组
    /// </summary>
    [System.Serializable]
    public class UIGroup
    {
        /// <summary>
        /// 分组编号
        /// </summary>
        public byte Id;

        /// <summary>
        /// 基础排序
        /// </summary>
        public ushort BaseOrder;

        public Transform Group;
    }
}