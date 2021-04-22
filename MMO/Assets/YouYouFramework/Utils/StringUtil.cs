//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-11-16 22:26:09
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 
/// </summary>
public static class StringUtil 
{
    #region IsNullOrEmpty 验证值是否为null

    /// <summary>
    /// 判断对象是否为Null、DBNull、Empty或空白字符串
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(string value)
    {
        bool retVal = false;
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            retVal = true;
        }
        return retVal;
    }

    #endregion

    /// <summary>
    /// 把string类型转换成int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int ToInt(string str)
    {
        int temp = 0;
        int.TryParse(str, out temp);
        return temp;
    }

    /// <summary>
    /// 把string类型转换成long
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static long ToLong(string str)
    {
        long temp = 0;
        long.TryParse(str, out temp);
        return temp;
    }

    /// <summary>
    /// 把string类型转换成float
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static float ToFloat(string str)
    {
        float temp = 0;
        float.TryParse(str, out temp);
        return temp;
    }
}