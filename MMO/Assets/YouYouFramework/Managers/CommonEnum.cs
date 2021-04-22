//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 协议分类
/// </summary>
public enum ProtoCategory
{
    /// <summary>
    /// 客户端->网关服务器
    /// </summary>
    Client2GatewayServer = 0,
    /// <summary>
    /// 网关服务器->客户端
    /// </summary>
    GatewayServer2Client = 1,
    /// <summary>
    /// 客户端->中心服务器
    /// </summary>
    Client2WorldServer = 2,

    /// <summary>
    /// 中心服务器->客户端
    /// </summary>
    WorldServer2Client = 3,

    /// <summary>
    /// 客户端->游戏服务器
    /// </summary>
    Client2GameServer = 4,

    /// <summary>
    /// 游戏服务器->客户端
    /// </summary>
    GameServer2Client = 5,

    /// <summary>
    /// 游戏服务器>中心服务器
    /// </summary>
    GameServer2WorldServer = 6,

    /// <summary>
    /// 中心服务器->游戏服务器
    /// </summary>
    WorldServer2GameServer = 7,

    /// <summary>
    /// 网关服务器>中心服务器
    /// </summary>
    GatewayServer2WorldServer = 8,

    /// <summary>
    /// 中心服务器->网关服务器
    /// </summary>
    WorldServer2GatewayServer = 9,

    /// <summary>
    /// 网关服务器>游戏服务器
    /// </summary>
    GatewayServer2GameServer = 10,

    /// <summary>
    /// 游戏服务器->网关服务器
    /// </summary>
    GameServer2GatewayServer = 11
}

/// <summary>
/// 日志分类
/// </summary>
public enum LogCategory
{
    /// <summary>
    /// 普通日志
    /// </summary>
    Normal,

    /// <summary>
    /// 流程日志
    /// </summary>
    Procedure,

    /// <summary>
    /// 协议日志
    /// </summary>
    Proto,

    /// <summary>
    /// 资源管理
    /// </summary>
    Resource,
}

#region AssetCategory 资源分类
/// <summary>
/// 资源分类
/// </summary>
public enum AssetCategory
{
    /// <summary>
    /// None
    /// </summary>
    None = 0,
    /// <summary>
    /// 日志
    /// </summary>
    Reporter,
    /// <summary>
    /// 声音
    /// </summary>
    Audio,
    /// <summary>
    /// 自定义Shaders
    /// </summary>
    CusShaders,
    /// <summary>
    /// 表格
    /// </summary>
    DataTable,
    /// <summary>
    /// 特效资源
    /// </summary>
    EffectSources,
    /// <summary>
    /// 角色特效预设
    /// </summary>
    RoleEffectPrefab,
    /// <summary>
    /// UI特效预设
    /// </summary>
    UIEffectPrefab,
    /// <summary>
    /// 角色预设
    /// </summary>
    RolePrefab,
    /// <summary>
    /// 角色资源
    /// </summary>
    RoleSources,
    /// <summary>
    /// 场景
    /// </summary>
    Scenes,
    /// <summary>
    /// 字体
    /// </summary>
    UIFont,
    /// <summary>
    /// UI预设
    /// </summary>
    UIPrefab,
    /// <summary>
    /// UI资源
    /// </summary>
    UIRes,
    /// <summary>
    /// lua脚本
    /// </summary>
    xLuaLogic
}
#endregion

/// <summary>
/// Loading类型
/// </summary>
public enum LoadingType
{
    /// <summary>
    /// 检查更新
    /// </summary>
    CheckVersion = 0,

    /// <summary>
    /// 切换场景
    /// </summary>
    ChangeScene = 1
}

/// <summary>
/// 提示窗口类型
/// </summary>
public enum DialogFormType
{
    /// <summary>
    /// 普通提示
    /// </summary>
    Normal = 0,

    /// <summary>
    /// 确认窗口
    /// </summary>
    Confirm = 1
}

/// <summary>
/// UI窗口的显示类型
/// </summary>
public enum UIFormShowMode
{
    /// <summary>
    /// 普通
    /// </summary>
    Normal = 0,

    /// <summary>
    /// 反向
    /// </summary>
    ReverseChange = 1,
}