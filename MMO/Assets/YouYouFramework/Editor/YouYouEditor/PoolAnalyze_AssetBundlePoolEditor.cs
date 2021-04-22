using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YouYou;

[CustomEditor(typeof(PoolAnalyze_AssetBundlePool))]
public class PoolAnalyze_AssetBundlePoolEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //=====================资源包统计开始===========================
        GUILayout.Space(10);

        GUIStyle titleStyle = new GUIStyle();
        titleStyle.normal.textColor = new Color(102 / 255f, 232 / 255f, 255 / 255f, 1);

        if (GameEntry.Pool != null)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("下次释放剩余时间：" + Mathf.Abs(Time.time - (GameEntry.Pool.ReleaseAssetBundleNextRunTime + GameEntry.Pool.ReleaseAssetBundleInterval)), titleStyle);
            GUILayout.EndHorizontal();
        }
        GUILayout.Space(10);
        GUILayout.BeginVertical("box");
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("资源包");
        GUILayout.Label("剩余时间", GUILayout.Width(50));
        GUILayout.EndHorizontal();

        if (GameEntry.Pool != null)
        {
            foreach (var item in GameEntry.Pool.AssetBundlePool.InspectorDic)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(item.Key);

                float remain = Mathf.Max(0, GameEntry.Pool.ReleaseAssetBundleInterval - (Time.time - item.Value.LastUseTime));

                titleStyle.fixedWidth = 50;
                GUILayout.Label(remain.ToString(), titleStyle);
                GUILayout.EndHorizontal();
            }
        }
        GUILayout.EndVertical();
        //=====================资源包统计结束===========================

        serializedObject.ApplyModifiedProperties();
        //重绘
        Repaint();
    }
}