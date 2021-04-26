using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/****************************************************
 * Author:			Mr.ding
 * CreateTime:		2021-04-26 10:21:49
 * Version:			1.0.1
*****************************************************/


public class DeleateSelectGameObj
{
    [MenuItem("MyTools/删除资产")]
    public static void Delect()
    {
        Object go = Selection.activeObject;
        string str = AssetDatabase.GetAssetPath(go);
        Debug.Log("go = " + go.name);
        Debug.Log("str = " + str);
        AssetDatabase.DeleteAsset(str);
    }
}
