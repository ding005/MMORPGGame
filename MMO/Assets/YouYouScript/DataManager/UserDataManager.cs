//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections.Generic;

/// <summary>
/// 用户数据
/// </summary>
public class UserDataManager : IDisposable
{
    /// <summary>
    /// 共享的用户数据
    /// </summary>
    public ShareUserData ShareUserData;

    /// <summary>
    /// 服务器返回的任务列表
    /// </summary>
    public List<ServerTaskEntity> ServerTaskList
    {
        get;
        private set;
    }


    public UserDataManager()
    {
        ShareUserData = new ShareUserData();
        ServerTaskList = new List<ServerTaskEntity>();
    }

    public void Clear()
    {
        ShareUserData.Dispose();
        ServerTaskList.Clear();
    }

    public void Dispose()
    {
        ServerTaskList.Clear();
    }
}