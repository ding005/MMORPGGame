using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Web服务器返回值
    /// </summary>
    public class RetValue
    {
        /// <summary>
        /// 是否有错
        /// </summary>
        public bool HasError;

        /// <summary>
        /// 错误码
        /// </summary>
        public short ErrorCode;

        /// <summary>
        /// 返回值
        /// </summary>
        public object Value;
    }
}