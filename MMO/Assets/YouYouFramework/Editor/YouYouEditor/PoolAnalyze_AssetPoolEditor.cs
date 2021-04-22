using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YouYou;

[CustomEditor(typeof(PoolAnalyze_AssetPool))]
public class PoolAnalyze_AssetPoolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //=====================资源统计开始===========================
        GUILayout.Space(10);

        GUIStyle titleStyle = new GUIStyle();
        titleStyle.normal.textColor = new Color(102 / 255f, 232 / 255f, 255 / 255f, 1);

        if (GameEntry.Pool != null)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("下次释放剩余时间：" + Mathf.Abs(Time.time - (GameEntry.Pool.ReleaseAssetNextRunTime + GameEntry.Pool.ReleaseAssetInterval)), titleStyle);
            GUILayout.EndHorizontal();
        }
        GUILayout.Space(10);
        var enumerator = Enum.GetValues(typeof(AssetCategory)).GetEnumerator();
        while (enumerator.MoveNext())
        {
            AssetCategory assetCategory = (AssetCategory)enumerator.Current;
            if (assetCategory == AssetCategory.None)
            {
                continue;
            }

            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("资源分类-" + assetCategory.ToString());
            GUILayout.Label("计数", GUILayout.Width(50));
            GUILayout.Label("剩余时间", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (GameEntry.Pool != null)
            {
                foreach (var item in GameEntry.Pool.AssetPool[assetCategory].InspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key);

                    titleStyle.fixedWidth = 50;
                    titleStyle.normal.textColor = new Color(102 / 255f, 232 / 255f, 255 / 255f, 1);
                    GUILayout.Label(item.Value.ReferenceCount.ToString(), titleStyle);

                    float remain = Mathf.Max(0, GameEntry.Pool.ReleaseAssetInterval - (Time.time - item.Value.LastUseTime));
                    GUILayout.Label(remain.ToString(), titleStyle);
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
        }
        //=====================资源统计结束===========================

        serializedObject.ApplyModifiedProperties();
        //重绘
        Repaint();
    }
}