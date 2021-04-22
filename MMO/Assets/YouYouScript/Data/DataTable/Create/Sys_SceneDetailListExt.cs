using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com zmx000
/// </summary>
public static partial class Sys_SceneDetailListExt
{
    private static Dictionary<int, Sys_SceneDetail?> m_Dic = new Dictionary<int, Sys_SceneDetail?>();
    private static List<Sys_SceneDetail> m_List = new List<Sys_SceneDetail>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this Sys_SceneDetailList sys_scenedetailList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.Sys_SceneDetailName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(Sys_SceneDetailList.GetRootAsSys_SceneDetailList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(Sys_SceneDetailList sys_scenedetailList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = sys_scenedetailList.SysSceneDetailsLength;
            for (int j = 0; j < len; j++)
            {
                Sys_SceneDetail ? sys_scenedetail = sys_scenedetailList.SysSceneDetails(j);
                if (sys_scenedetail != null)
                {
                    m_List.Add(sys_scenedetail.Value);
                    m_Dic[sys_scenedetail.Value.Id] = sys_scenedetail;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.Sys_SceneDetailName, DataTableDefine.Sys_SceneDetailVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.Sys_SceneDetailName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_SceneDetail? GetEntity(this Sys_SceneDetailList sys_scenedetailList, int id)
    {
        Sys_SceneDetail ? sys_scenedetail;
        m_Dic.TryGetValue(id, out sys_scenedetail);
        return sys_scenedetail;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_SceneDetail GetEntityValue(this Sys_SceneDetailList sys_scenedetailList, int id)
    {
        Sys_SceneDetail ? sys_scenedetail = sys_scenedetailList.GetEntity(id);
        if (sys_scenedetail != null)
        {
            return sys_scenedetail.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<Sys_SceneDetail> GetList(this Sys_SceneDetailList sys_scenedetailList)
    {
        return m_List;
    }
}