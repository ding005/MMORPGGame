//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;

namespace YouYou
{
    /// <summary>
    /// Http请求的回调数据
    /// </summary>
    public class HttpCallBackArgs : EventArgs
    {
        /// <summary>
        /// 是否有错
        /// </summary>
        public bool HasError;

        /// <summary>
        /// 返回值
        /// </summary>
        public string Value;

        /// <summary>
        /// 字节数据
        /// </summary>
        public byte[] Data;
    }
}