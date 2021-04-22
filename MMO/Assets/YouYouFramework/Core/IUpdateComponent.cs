using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 更新组件接口
    /// </summary>
    public interface IUpdateComponent
    {
        /// <summary>
        /// 更新方法
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// 实例编号
        /// </summary>
        int InstanceId { get; }
    }
}