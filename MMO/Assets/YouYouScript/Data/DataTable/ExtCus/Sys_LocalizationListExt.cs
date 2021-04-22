using FlatBuffers;
using System.Collections.Generic;
using YouYou;
using YouYou.DataTable;

public static class Sys_LocalizationListExt
{
    private static Dictionary<string, string> m_Dic = new Dictionary<string, string>();


    #region LoadData

    public static void LoadData(this Sys_LocalizationList sys_LocalizationList)
    {
        GameEntry.DataTable.TotalTableCount++;

        GameEntry.DataTable.GetDataTableBuffer("Localization/" + GameEntry.CurrLanguage.ToString(), (byte[] buffer) =>
        {
            Init(Sys_LocalizationList.GetRootAsSys_LocalizationList(new ByteBuffer(buffer)));
        });
    }
    #endregion

    public static void Init(Sys_LocalizationList sys_LocalizationList)
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            int len = sys_LocalizationList.SysLocalizationsLength;
            for (int j = 0; j < len; j++)
            {
                Sys_Localization? sys_Localization = sys_LocalizationList.SysLocalizations(j);
                if (sys_Localization != null)
                {
                    m_Dic[sys_Localization.Value.Key] = sys_Localization.Value.Value;
                }
            }

            GameEntry.DataTable.AddToAlreadyLoadTable("Sys_Localization", 2);
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete, "Sys_Localization");
        });
    }

    public static string GetValue(this Sys_LocalizationList sys_LocalizationList, string key)
    {
        string value = null;
        m_Dic.TryGetValue(key, out value);
        return value;
    }
}