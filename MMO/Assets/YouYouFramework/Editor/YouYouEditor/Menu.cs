//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2016-03-14 22:50:55
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using YouYou;
using System.Text;
using System;
using UnityEngine.UI;

public class Menu
{
    #region Settings 宏设置
    [MenuItem("悠游工具/宏设置(Settings)")]
    public static void Settings()
    {
        SettingsWindow win = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
        win.titleContent = new GUIContent("宏设置");
        win.Show();
    }
    #endregion

    #region AssetBundleMgr 资源管理
    [MenuItem("悠游工具/资源管理/资源包管理(AssetBundleMgr)")]
    public static void AssetBundleMgr()
    {
        AssetBundleWindow win = (AssetBundleWindow)EditorWindow.GetWindow(typeof(AssetBundleWindow));
        win.titleContent = new GUIContent("资源包管理");
        win.Show();
    }
    #endregion

    #region AssetBundleCopyToStreamingAsstes 初始资源拷贝到StreamingAsstes
    [MenuItem("悠游工具/资源管理/初始资源拷贝到StreamingAsstes")]
    public static void AssetBundleCopyToStreamingAsstes()
    {
        string toPath = Application.streamingAssetsPath + "/AssetBundles/";

        if (Directory.Exists(toPath))
        {
            Directory.Delete(toPath, true);
        }
        Directory.CreateDirectory(toPath);

        IOUtil.CopyDirectory(Application.persistentDataPath, toPath);

        //重新生成版本文件
        //1.先读取persistentDataPath里边的版本文件 这个版本文件里 存放了所有的资源包信息

        byte[] buffer = IOUtil.GetFileBuffer(Application.persistentDataPath + "/VersionFile.bytes");
        string version = "";
        Dictionary<string, AssetBundleInfoEntity> dic = ResourceManager.GetAssetBundleVersionList(buffer, ref version);
        Dictionary<string, AssetBundleInfoEntity> newDic = new Dictionary<string, AssetBundleInfoEntity>();

        DirectoryInfo directory = new DirectoryInfo(toPath);

        //拿到文件夹下所有文件
        FileInfo[] arrFiles = directory.GetFiles("*", SearchOption.AllDirectories);

        for (int i = 0; i < arrFiles.Length; i++)
        {
            FileInfo file = arrFiles[i];
            string fullName = file.FullName.Replace("\\", "/"); //全名 包含路径扩展名
            string name = fullName.Replace(toPath, "").Replace(".assetbundle", "").Replace(".unity3d", "");

            if (name.Equals("AssetInfo.json", StringComparison.CurrentCultureIgnoreCase)
                || name.Equals("Windows", StringComparison.CurrentCultureIgnoreCase)
                || name.Equals("Windows.manifest", StringComparison.CurrentCultureIgnoreCase)

                || name.Equals("Android", StringComparison.CurrentCultureIgnoreCase)
                || name.Equals("Android.manifest", StringComparison.CurrentCultureIgnoreCase)

                || name.Equals("iOS", StringComparison.CurrentCultureIgnoreCase)
                || name.Equals("iOS.manifest", StringComparison.CurrentCultureIgnoreCase)
                )
            {
                File.Delete(file.FullName);
                continue;
            }

            AssetBundleInfoEntity entity = null;
            dic.TryGetValue(name, out entity);


            if (entity != null)
            {
                newDic[name] = entity;
            }
        }

        StringBuilder sbContent = new StringBuilder();
        sbContent.AppendLine(version);

        foreach (var item in newDic)
        {
            AssetBundleInfoEntity entity = item.Value;
            string strLine = string.Format("{0}|{1}|{2}|{3}|{4}", entity.AssetBundleName, entity.MD5, entity.Size, entity.IsFirstData ? 1 : 0, entity.IsEncrypt ? 1 : 0);
            sbContent.AppendLine(strLine);
        }

        IOUtil.CreateTextFile(toPath + "VersionFile.txt", sbContent.ToString());

        //=======================
        MMO_MemoryStream ms = new MMO_MemoryStream();
        string str = sbContent.ToString().Trim();
        string[] arr = str.Split('\n');
        int len = arr.Length;
        ms.WriteInt(len);
        for (int i = 0; i < len; i++)
        {
            if (i == 0)
            {
                ms.WriteUTF8String(arr[i]);
            }
            else
            {
                string[] arrInner = arr[i].Split('|');
                ms.WriteUTF8String(arrInner[0]);
                ms.WriteUTF8String(arrInner[1]);
                ms.WriteInt(int.Parse(arrInner[2]));
                ms.WriteByte(byte.Parse(arrInner[3]));
                ms.WriteByte(byte.Parse(arrInner[4]));
            }
        }

        string filePath = toPath + "/VersionFile.bytes"; //版本文件路径
        buffer = ms.ToArray();
        buffer = ZlibHelper.CompressBytes(buffer);
        FileStream fs = new FileStream(filePath, FileMode.Create);
        fs.Write(buffer, 0, buffer.Length);
        fs.Close();

        AssetDatabase.Refresh();
        Debug.Log("初始资源拷贝到StreamingAsstes完毕");
    }
    #endregion

    #region AssetBundleOpenPersistentDataPath 打开persistentDataPath
    [MenuItem("悠游工具/资源管理/打开persistentDataPath")]
    public static void AssetBundleOpenPersistentDataPath()
    {
        string output = Application.persistentDataPath;
        if (!Directory.Exists(output))
        {
            Directory.CreateDirectory(output);
        }
        output = output.Replace("/", "\\");
        System.Diagnostics.Process.Start("explorer.exe", output);
    }
    #endregion

    [MenuItem("GameObject/UI/YouYouText", false, 2500)]
    private static void MakeYouYouText(MenuCommand menuCommand)
    {
        if (menuCommand.context == null)
        {
            AttachToCanvas(MakeYouYouPrefab("YouYouText", menuCommand));
        }
        else
        {
            MakeYouYouPrefab("YouYouText", menuCommand);
        }
    }

    #region ChangeToYouYouText
    [MenuItem("CONTEXT/Text/ChangeToYouYouText")]
    private static void ChangeToYouYouText(MenuCommand menuCommand)
    {
        Text currText = menuCommand.context as Text;
        GameObject obj = currText.gameObject;

        string text = currText.text;
        Color color = currText.color;
        Font font = currText.font;
        int fontSize = currText.fontSize;
        FontStyle fontStyle = currText.fontStyle;
        TextAnchor textAnchor = currText.alignment;
        bool richText = currText.supportRichText;
        bool raycastTarget = currText.raycastTarget;

        UnityEngine.Object.DestroyImmediate(currText);

        YouYouText youYouText = obj.AddComponent<YouYouText>();

        youYouText.text = text;
        youYouText.color = color;
        youYouText.font = font;
        youYouText.fontSize = fontSize;
        youYouText.fontStyle = fontStyle;
        youYouText.alignment = textAnchor;
        youYouText.supportRichText = richText;
        youYouText.raycastTarget = raycastTarget;
    }
    #endregion

    [MenuItem("GameObject/UI/YouYouImage", false, 2501)]
    private static void MakeYouYouImage(MenuCommand menuCommand)
    {
        if (menuCommand.context == null)
        {
            AttachToCanvas(MakeYouYouPrefab("YouYouImage", menuCommand));
        }
        else
        {
            MakeYouYouPrefab("YouYouImage", menuCommand);
        }
    }

    #region ChangeToYouYouImage
    [MenuItem("CONTEXT/Image/ChangeToYouYouImage")]
    private static void ChangeToYouYouImage(MenuCommand menuCommand)
    {
        Image image = menuCommand.context as Image;
        GameObject gameObject = image.gameObject;

        UnityEngine.Sprite sprite = image.sprite;
        Color color = image.color;
        UnityEngine.Material material = image.material;
        bool raycastTarget = image.raycastTarget;

        Image.Type type = image.type;
        float fillAmount = image.fillAmount;
        bool fillCenter = image.fillCenter;
        bool fillClockwise = image.fillClockwise;
        Image.FillMethod fillMethod = image.fillMethod;
        int fillOrigin = image.fillOrigin;
        bool preserveAspect = image.preserveAspect;

        UnityEngine.Object.DestroyImmediate(image);

        YouYouImage youyouImage = gameObject.AddComponent<YouYouImage>();
        youyouImage.sprite = sprite;
        youyouImage.color = color;
        youyouImage.material = material;
        youyouImage.raycastTarget = raycastTarget;

        youyouImage.type = type;
        youyouImage.fillAmount = fillAmount;
        youyouImage.fillCenter = fillCenter;
        youyouImage.fillClockwise = fillClockwise;
        youyouImage.fillMethod = fillMethod;
        youyouImage.fillOrigin = fillOrigin;
        youyouImage.preserveAspect = preserveAspect;
    }
    #endregion

    #region MakeYouYouPrefab 创建YouYou预设
    /// <summary>
    /// 创建YouYou预设
    /// </summary>
    /// <param name="prefabName"></param>
    /// <param name="menuCommand"></param>
    /// <returns></returns>
    private static GameObject MakeYouYouPrefab(string prefabName, MenuCommand menuCommand)
    {
        GameObject gameObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/YouYouFramework/Editor/YouYouPrefabs/" + prefabName + ".prefab");
        GameObject newObj = UnityEngine.Object.Instantiate(gameObject);

        newObj.name = gameObject.name;
        GameObjectUtility.SetParentAndAlign(newObj, menuCommand.context as GameObject);
        Selection.activeObject = newObj;

        return newObj;
    }
    #endregion

    #region AttachToCanvas 附加到画布
    /// <summary>
    /// 附加到画布
    /// </summary>
    /// <param name="gameObject"></param>
    private static void AttachToCanvas(GameObject gameObject)
    {
        Canvas canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject obj = new GameObject();
            canvas = obj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.gameObject.AddComponent<CanvasScaler>();
            canvas.gameObject.AddComponent<GraphicRaycaster>();
        }
        gameObject.transform.SetParent(canvas.transform);
    }
    #endregion
}