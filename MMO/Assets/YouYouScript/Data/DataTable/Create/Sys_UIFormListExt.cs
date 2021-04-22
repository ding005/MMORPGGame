using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com zmx000
/// </summary>
public static partial class Sys_UIFormListExt
{
    private static Dictionary<int, Sys_UIForm?> m_Dic = new Dictionary<int, Sys_UIForm?>();
    private static List<Sys_UIForm> m_List = new List<Sys_UIForm>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this Sys_UIFormList sys_uiformList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.Sys_UIFormName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(Sys_UIFormList.GetRootAsSys_UIFormList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(Sys_UIFormList sys_uiformList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = sys_uiformList.SysUIFormsLength;
            for (int j = 0; j < len; j++)
            {
                Sys_UIForm ? sys_uiform = sys_uiformList.SysUIForms(j);
                if (sys_uiform != null)
                {
                    m_List.Add(sys_uiform.Value);
                    m_Dic[sys_uiform.Value.Id] = sys_uiform;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.Sys_UIFormName, DataTableDefine.Sys_UIFormVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.Sys_UIFormName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_UIForm? GetEntity(this Sys_UIFormList sys_uiformList, int id)
    {
        Sys_UIForm ? sys_uiform;
        m_Dic.TryGetValue(id, out sys_uiform);
        return sys_uiform;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_UIForm GetEntityValue(this Sys_UIFormList sys_uiformList, int id)
    {
        Sys_UIForm ? sys_uiform = sys_uiformList.GetEntity(id);
        if (sys_uiform != null)
        {
            return sys_uiform.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<Sys_UIForm> GetList(this Sys_UIFormList sys_uiformList)
    {
        return m_List;
    }
}