using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class AssetBundleUtil : MonoBehaviour
{
    [MenuItem("我的工具/CreateAssetBundle")]
    public void Bulid()
    {
        string path = Application.dataPath + "/AssetBundle";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
