using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace YouYou
{
    [CustomEditor(typeof(PoolComponent), true)]
    public class PoolComponentInspector : Editor
    {


        //释放类对象池间隔 属性
        private SerializedProperty ReleaseClassObjectInterval = null;

        //释放间隔 属性
        private SerializedProperty m_GameObjectPoolGroups = null;

        //锁定的资源包 属性
        private SerializedProperty LockedAssetBundle = null;

        //释放AssetBundle池间隔 属性
        private SerializedProperty ReleaseAssetBundleInterval = null;

        //释放Asset池间隔 属性
        private SerializedProperty ReleaseAssetInterval = null;

        //显示分类资源池 属性
        private SerializedProperty ShowAssetPool = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            PoolComponent component = base.target as PoolComponent;

            //绘制滑动条 释放类对象池间隔
            int releaseClassObjectInterval = (int)EditorGUILayout.Slider("释放类对象池间隔", ReleaseClassObjectInterval.intValue, 10, 1800);
            if (releaseClassObjectInterval != ReleaseClassObjectInterval.intValue)
            {
                component.ReleaseClassObjectInterval = releaseClassObjectInterval;
            }
            else
            {
                ReleaseClassObjectInterval.intValue = releaseClassObjectInterval;
            }

            //=====================类对象池开始===========================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("类名");
            GUILayout.Label("池中数量", GUILayout.Width(50));
            GUILayout.Label("常驻数量", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (component != null && component.PoolManager != null)
            {
                foreach (var item in component.PoolManager.ClassObjectPool.InspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));

                    int key = item.Key.GetHashCode();
                    byte resideCount = 0;
                    component.PoolManager.ClassObjectPool.ClassObjectCount.TryGetValue(key, out resideCount);

                    GUILayout.Label(resideCount.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            //=====================类对象池结束===========================

            //=====================变量计数开始===========================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("变量");
            GUILayout.Label("计数", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (component != null)
            {
                foreach (var item in component.VarObjectInspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            //=====================变量计数结束===========================

            GUILayout.Space(10);
            EditorGUILayout.PropertyField(m_GameObjectPoolGroups, true);
            GUILayout.Space(10);
            GUILayout.Space(10);
            EditorGUILayout.PropertyField(LockedAssetBundle, true);
            GUILayout.Space(10);
            //绘制滑动条 释放资源池间隔
            int releaseAssetBundleInterval = (int)EditorGUILayout.Slider("释放AssetBundle池间隔", ReleaseAssetBundleInterval.intValue, 10, 1800);
            if (releaseAssetBundleInterval != ReleaseAssetBundleInterval.intValue)
            {
                component.ReleaseAssetBundleInterval = releaseAssetBundleInterval;
            }
            else
            {
                ReleaseAssetBundleInterval.intValue = releaseAssetBundleInterval;
            }
            //=====================资源包统计开始===========================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("资源包");
            GUILayout.Label("计数", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (component != null && component.PoolManager != null)
            {
                foreach (var item in component.PoolManager.AssetBundlePool.InspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            //=====================资源包统计结束===========================

            //=====================资源统计开始===========================
            GUILayout.Space(10);
            GUILayout.Space(10);
            //绘制滑动条 释放资源池间隔
            int releaseAssetInterval = (int)EditorGUILayout.Slider("释放Asset池间隔", ReleaseAssetInterval.intValue, 10, 1800);
            if (releaseAssetInterval != ReleaseAssetBundleInterval.intValue)
            {
                component.ReleaseAssetInterval = releaseAssetInterval;
            }
            else
            {
                ReleaseAssetInterval.intValue = releaseAssetInterval;
            }
            GUILayout.Space(10);
            bool showAssetPool = EditorGUILayout.Toggle("显示分类资源池", ShowAssetPool.boolValue);
            if (showAssetPool != ShowAssetPool.boolValue)
            {
                component.ShowAssetPool = showAssetPool;
            }
            else
            {
                ShowAssetPool.boolValue = showAssetPool;
            }

            if (showAssetPool)
            {
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
                    GUILayout.EndHorizontal();

                    if (component != null && component.PoolManager != null)
                    {
                        foreach (var item in component.PoolManager.AssetPool[assetCategory].InspectorDic)
                        {
                            GUILayout.BeginHorizontal("box");
                            GUILayout.Label(item.Key);
                            GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                            GUILayout.EndHorizontal();
                        }
                    }
                    GUILayout.EndVertical();
                }
            }
            //=====================资源统计结束===========================

            serializedObject.ApplyModifiedProperties();
            //重绘
            Repaint();
        }

        private void OnEnable()
        {
            //建立属性关系
            ReleaseClassObjectInterval = serializedObject.FindProperty("ReleaseClassObjectInterval");
            m_GameObjectPoolGroups = serializedObject.FindProperty("m_GameObjectPoolGroups");

            //锁定的资源包 属性
            LockedAssetBundle = serializedObject.FindProperty("LockedAssetBundle");

            //释放AssetBundle池间隔
            ReleaseAssetBundleInterval = serializedObject.FindProperty("ReleaseAssetBundleInterval");

            //释放Asset池间隔
            ReleaseAssetInterval = serializedObject.FindProperty("ReleaseAssetInterval");

            //显示AssetPool
            ShowAssetPool = serializedObject.FindProperty("ShowAssetPool");

            serializedObject.ApplyModifiedProperties();
        }
    }
}