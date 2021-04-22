//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池实体
/// </summary>
[System.Serializable]
public class GameObjectPoolEntity 
{
    /// <summary>
    /// 对象池编号
    /// </summary>
    public byte PoolId;

    /// <summary>
    /// 对象池名字
    /// </summary>
    public string PoolName;

    /// <summary>
    /// 是否开启缓存池自动清理模式
    /// </summary>
    public bool CullDespawned = true;

    /// <summary>
    /// 缓存池自动清理 但是始终保留几个对象不清理
    /// </summary>
    public int CullAbove = 5;

    /// <summary>
    /// 多长时间清理一次 单位是秒
    /// </summary>
    public int CullDelay = 2;

    /// <summary>
    /// 每次清理几个
    /// </summary>
    public int CullMaxPerPass = 2;

    /// <summary>
    /// 对应的游戏物体对象池
    /// </summary>
    public SpawnPool Pool;
}