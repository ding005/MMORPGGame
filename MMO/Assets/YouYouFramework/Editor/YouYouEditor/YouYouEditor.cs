using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class YouYouEditor : OdinMenuEditorWindow
{
    [MenuItem("YouYouTools/YouYouEditor")]
    private static void OpenYouYouEditor()
    {
        var window = GetWindow<YouYouEditor>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(1000, 700);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree(true);

        //简介
        tree.AddAssetAtPath("YouYouFramework", "YouYouFramework/YouYouAssets/AboutUs.asset").AddIcon(EditorIcons.Airplane);

        //宏设置
        tree.AddAssetAtPath("MacroSettings", "YouYouFramework/YouYouAssets/MacroSettings.asset").AddIcon(EditorIcons.AlertCircle);

        //参数设置
        tree.AddAssetAtPath("ParamsSettings", "YouYouFramework/YouYouAssets/ParamsSettings.asset").AddIcon(EditorIcons.Letter);

        //共享数据设置
        tree.AddAssetAtPath("ShareDataSettings", "YouYouFramework/YouYouAssets/ShareDataSettings.asset").AddIcon(EditorIcons.Bell);

        //资源包设置
        tree.AddAssetAtPath("AssetBundleSettings", "YouYouFramework/YouYouAssets/AssetBundleSettings.asset").AddIcon(EditorIcons.List);

        //类对象池
        tree.AddAssetAtPath("PoolAnalyze/ClassObjectPool", "YouYouFramework/YouYouAssets/PoolAnalyze_ClassObjectPool.asset").AddIcon(EditorIcons.CharGraph);

        //资源包池分析
        tree.AddAssetAtPath("PoolAnalyze/AssetBundlePool", "YouYouFramework/YouYouAssets/PoolAnalyze_AssetBundlePool.asset").AddIcon(EditorIcons.Link);

        //资源池分析
        tree.AddAssetAtPath("PoolAnalyze/AssetPool", "YouYouFramework/YouYouAssets/PoolAnalyze_AssetPool.asset").AddIcon(EditorIcons.FileCabinet);
        return tree;
    }
}