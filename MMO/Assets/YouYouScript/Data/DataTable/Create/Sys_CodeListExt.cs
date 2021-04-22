using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com zmx000
/// </summary>
public static partial class Sys_CodeListExt
{
    private static Dictionary<int, Sys_Code?> m_Dic = new Dictionary<int, Sys_Code?>();
    private static List<Sys_Code> m_List = new List<Sys_Code>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this Sys_CodeList sys_codeList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.Sys_CodeName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(Sys_CodeList.GetRootAsSys_CodeList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(Sys_CodeList sys_codeList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = sys_codeList.SysCodesLength;
            for (int j = 0; j < len; j++)
            {
                Sys_Code ? sys_code = sys_codeList.SysCodes(j);
                if (sys_code != null)
                {
                    m_List.Add(sys_code.Value);
                    m_Dic[sys_code.Value.Id] = sys_code;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.Sys_CodeName, DataTableDefine.Sys_CodeVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.Sys_CodeName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_Code? GetEntity(this Sys_CodeList sys_codeList, int id)
    {
        Sys_Code ? sys_code;
        m_Dic.TryGetValue(id, out sys_code);
        return sys_code;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_Code GetEntityValue(this Sys_CodeList sys_codeList, int id)
    {
        Sys_Code ? sys_code = sys_codeList.GetEntity(id);
        if (sys_code != null)
        {
            return sys_code.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<Sys_Code> GetList(this Sys_CodeList sys_codeList)
    {
        return m_List;
    }
}