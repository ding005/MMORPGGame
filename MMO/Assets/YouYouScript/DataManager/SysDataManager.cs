//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// 系统相关数据
/// </summary>
public class SysDataManager
{
    /// <summary>
    /// 当前的服务器时间
    /// </summary>
    public long CurrServerTime
    {
        get
        {
            if (CurrChannelConfig == null)
            {
                return (long)Time.unscaledTime;
            }
            else
            {
                return CurrChannelConfig.ServerTime + (long)Time.unscaledTime;
            }
        }
    }

    /// <summary>
    /// 当前的渠道设置
    /// </summary>
    public ChannelConfigEntity CurrChannelConfig
    {
        get;
        private set;
    }

    public SysDataManager()
    {
        CurrChannelConfig = new ChannelConfigEntity();
    }

    public void Clear()
    {

    }

    public void Dispose()
    {

    }

    /// <summary>
    /// 根据系统码获取提示内容
    /// </summary>
    /// <param name="sysCode"></param>
    /// <returns></returns>
    public string GetSysCodeContent(int sysCode)
    {
        Sys_Code? sys_Code = GameEntry.DataTable.Sys_CodeList.GetEntity(sysCode);
        if (sys_Code != null)
        {
            return GameEntry.Localization.GetString(sys_Code.Value.Name);
        }
        return string.Empty;
    }
}