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
    /// 基础参数
    /// </summary>
    public class BaseParams
    {
        public int IntParam1;
        public int IntParam2;
        public int IntParam3;
        public int IntParam4;
        public int IntParam5;

        public ulong ULongParam1;
        public ulong ULongParam2;
        public ulong ULongParam3;
        public ulong ULongParam4;
        public ulong ULongParam5;

        public float FloatParam1;
        public float FloatParam2;
        public float FloatParam3;
        public float FloatParam4;
        public float FloatParam5;

        public string StringParam1;
        public string StringParam2;
        public string StringParam3;
        public string StringParam4;
        public string StringParam5;

        public BaseAction ActionParam1;
        public BaseAction ActionParam2;
        public BaseAction ActionParam3;
        public BaseAction ActionParam4;
        public BaseAction ActionParam5;

        /// <summary>
        /// 重置
        /// </summary>
        public void Reset()
        {
            IntParam1 = IntParam2 = IntParam3 = IntParam4 = IntParam5 = 0;
            ULongParam1 = ULongParam2 = ULongParam3 = ULongParam4 = ULongParam5 = 0;
            FloatParam1 = FloatParam2 = FloatParam3 = FloatParam4 = FloatParam5 = 0;
            StringParam1 = StringParam2 = StringParam3 = StringParam4 = StringParam5 = null;
            ActionParam1 = ActionParam2 = ActionParam3 = ActionParam4 = ActionParam5 = null;
        }
    }
}