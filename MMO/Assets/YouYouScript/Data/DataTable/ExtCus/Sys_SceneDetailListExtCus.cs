using System.Collections.Generic;
using YouYou.DataTable;

public static partial class Sys_SceneDetailListExt
{
    static List<Sys_SceneDetail> ret = new List<Sys_SceneDetail>();
    public static List<Sys_SceneDetail> GetListBySceneId(this Sys_SceneDetailList sys_scenedetailList, int sceneId, int sceneGrade)
    {
        ret.Clear();
        int len = m_List.Count;
        for (int i = 0; i < len; i++)
        {
            Sys_SceneDetail sys_SceneDetail = m_List[i];
            if (sys_SceneDetail.SceneId == sceneId && sys_SceneDetail.SceneGrade == sceneGrade)
            {
                ret.Add(sys_SceneDetail);
            }
        }
        return ret;
    }
}