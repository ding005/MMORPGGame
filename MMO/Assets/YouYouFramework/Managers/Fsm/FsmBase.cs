//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 状态机基类
    /// </summary>
    public abstract class FsmBase
    {
        /// <summary>
        /// 状态机编号
        /// </summary>
        public int FsmId { get; private set; }

        /// <summary>
        /// 拥有者
        /// </summary>
        public Type Owner { get; private set; }

        /// <summary>
        /// 当前状态的类型
        /// </summary>
        public sbyte CurrStateType;

        public FsmBase(int fsmId)
        {
            FsmId = fsmId;
        }

        /// <summary>
        /// 关闭状态机
        /// </summary>
        public abstract void ShutDown();
    }
}