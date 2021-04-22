using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

/// <summary>
/// Create By 悠游课堂 http://www.u3dol.com zmx000
/// </summary>
public static partial class ChapterListExt
{
    private static Dictionary<int, Chapter?> m_Dic = new Dictionary<int, Chapter?>();
    private static List<Chapter> m_List = new List<Chapter>();

    #region LoadData 加载数据表数据
    /// <summary>
    /// 加载数据表数据
    /// </summary>
    public static void LoadData(this ChapterList chapterList)
    {
        GameEntry.DataTable.TotalTableCount++;

        //1.拿到这个表格的buffer
        GameEntry.DataTable.GetDataTableBuffer(DataTableDefine.ChapterName, (byte[] buffer) =>
        {
            //2.加载数据 并 把数据初始化到字典
            Init(ChapterList.GetRootAsChapterList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    /// <summary>
    /// 初始化到字典
    /// </summary>
    public static void Init(ChapterList chapterList)
    {
        System.Threading.Tasks.Task.Run(() => {
            int len = chapterList.ChaptersLength;
            for (int j = 0; j < len; j++)
            {
                Chapter ? chapter = chapterList.Chapters(j);
                if (chapter != null)
                {
                    m_List.Add(chapter.Value);
                    m_Dic[chapter.Value.Id] = chapter;
                }
            }

            //3.派发单个表加载完毕事件
            GameEntry.DataTable.AddToAlreadyLoadTable(DataTableDefine.ChapterName, DataTableDefine.ChapterVersion);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, DataTableDefine.ChapterName);
        });
    }

    /// <summary>
    /// 获取数据实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Chapter? GetEntity(this ChapterList chapterList, int id)
    {
        Chapter ? chapter;
        m_Dic.TryGetValue(id, out chapter);
        return chapter;
    }

    /// <summary>
    /// 获取数据实体值
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Chapter GetEntityValue(this ChapterList chapterList, int id)
    {
        Chapter ? chapter = chapterList.GetEntity(id);
        if (chapter != null)
        {
            return chapter.Value;
        }
        return default;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <returns></returns>
    public static List<Chapter> GetList(this ChapterList chapterList)
    {
        return m_List;
    }
}