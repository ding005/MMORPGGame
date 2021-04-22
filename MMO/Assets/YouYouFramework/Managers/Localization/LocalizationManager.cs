using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public enum YouYouLanguage
    {
        /// <summary>
        /// 中文
        /// </summary>
        Chinese = 0,
        /// <summary>
        /// 英文
        /// </summary>
        English = 1
    }

    public class LocalizationManager : ManagerBase, IDisposable
    {

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
#if !UNITY_EDITOR
            switch (Application.systemLanguage)
            {
                default:
                case SystemLanguage.ChineseSimplified:
                case SystemLanguage.ChineseTraditional:
                case SystemLanguage.Chinese:
                    GameEntry.CurrLanguage = YouYouLanguage.Chinese;
                    break;
                case SystemLanguage.English:
                    GameEntry.CurrLanguage = YouYouLanguage.English;
                    break;
            }
#endif
        }

        /// <summary>
        /// 获取本地化文本内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string GetString(string key, params object[] args)
        {
            string value = GameEntry.DataTable.Sys_LocalizationList.GetValue(key);
            if (value != null)
            {
                return string.Format(value, args);
            }
            return value;
        }

        public void Dispose()
        {

        }
    }
}