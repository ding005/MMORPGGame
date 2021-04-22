using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com zmx000
/// </summary>
public static partial class Sys_AudioListExt
{
    private static Dictionary<int, Sys_Audio?> m_Dic = new Dictionary<int, Sys_Audio?>();
    private static List<Sys_Audio> m_List = new List<Sys_Audio>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this Sys_AudioList sys_audioList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.Sys_AudioName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(Sys_AudioList.GetRootAsSys_AudioList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(Sys_AudioList sys_audioList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = sys_audioList.SysAudiosLength;
            for (int j = 0; j < len; j++)
            {
                Sys_Audio ? sys_audio = sys_audioList.SysAudios(j);
                if (sys_audio != null)
                {
                    m_List.Add(sys_audio.Value);
                    m_Dic[sys_audio.Value.Id] = sys_audio;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.Sys_AudioName, DataTableDefine.Sys_AudioVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.Sys_AudioName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_Audio? GetEntity(this Sys_AudioList sys_audioList, int id)
    {
        Sys_Audio ? sys_audio;
        m_Dic.TryGetValue(id, out sys_audio);
        return sys_audio;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Sys_Audio GetEntityValue(this Sys_AudioList sys_audioList, int id)
    {
        Sys_Audio ? sys_audio = sys_audioList.GetEntity(id);
        if (sys_audio != null)
        {
            return sys_audio.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<Sys_Audio> GetList(this Sys_AudioList sys_audioList)
    {
        return m_List;
    }
}