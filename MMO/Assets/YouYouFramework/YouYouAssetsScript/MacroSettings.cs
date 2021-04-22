using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

[CreateAssetMenu]
public class MacroSettings : ScriptableObject
{
    private string m_Macor;

    [BoxGroup("MacroSettings")]
    [TableList(ShowIndexLabels = true, AlwaysExpanded = true)]
    [HideLabel]
    public MacroData[] Settings;

    //ButtonSizes.Medium 这个属性表示按钮的高度
    //ResponsiveButtonGroup("DefaultButtonSize") 有这句话 按钮会排序
    //ResponsiveButtonGroup 表示按钮的分组 如果分组名字一样 横着排序 如果不一样 竖着排序
    //PropertyOrder 表示当前绘制的所有组件的顺序

    [Button(ButtonSizes.Medium), ResponsiveButtonGroup("DefaultButtonSize"), PropertyOrder(1)]
    public void SavaMacro()
    {
#if UNITY_EDITOR
        m_Macor = string.Empty;
        foreach (var item in Settings)
        {
            if (item.Enabled)
            {
                m_Macor += string.Format("{0};", item.Macro);
            }

            if (item.Macro.Equals("DISABLE_ASSETBUNDLE", System.StringComparison.CurrentCultureIgnoreCase))
            {
                EditorBuildSettingsScene[] arrScene = EditorBuildSettings.scenes;
                for (int i = 0; i < arrScene.Length; i++)
                {
                    if (arrScene[i].path.IndexOf("download", System.StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        arrScene[i].enabled = item.Enabled;
                    }
                }

                EditorBuildSettings.scenes = arrScene;
            }
        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, m_Macor);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, m_Macor);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, m_Macor);
        Debug.Log("Sava Macro Success");
#endif
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        m_Macor = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

        for (int i = 0; i < Settings.Length; i++)
        {
            if (!string.IsNullOrEmpty(m_Macor) && m_Macor.IndexOf(Settings[i].Macro) != -1)
            {
                Settings[i].Enabled = true;
            }
            else
            {
                Settings[i].Enabled = false;
            }
        }
#endif
    }

    //必须加上可序列化标记
    [Serializable]
    public class MacroData
    {
        [TableColumnWidth(80, Resizable = false)]
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled;

        /// <summary>
        /// 宏名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 宏
        /// </summary>
        public string Macro;
    }
}