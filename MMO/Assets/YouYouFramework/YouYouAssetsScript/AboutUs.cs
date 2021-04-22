using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AboutUs : ScriptableObject
{
    [BoxGroup("AboutUs")]
    [HorizontalGroup("AboutUs/Split", 80)]
    [VerticalGroup("AboutUs/Split/Left")]
    [HideLabel, PreviewField(80, ObjectFieldAlignment.Center)]
    public Texture Icon;

    [HorizontalGroup("AboutUs/Split", LabelWidth = 70)]

    [VerticalGroup("AboutUs/Split/Right")]
    [DisplayAsString]
    [LabelText("框架名称")]
    [GUIColor(2, 6, 6, 1)]
    public string Name = "YouYouFramework";

    [PropertySpace(10)]
    [VerticalGroup("AboutUs/Split/Right")]
    [DisplayAsString]
    [LabelText("版本号")]
    public string Version = "1.1";

    [VerticalGroup("AboutUs/Split/Right")]
    //[DisplayAsString]
    [LabelText("作者")]
    public string Author = "朱明星";

    [VerticalGroup("AboutUs/Split/Right")]
    //[DisplayAsString]
    [LabelText("联系方式")]
    public string Contact = "zhumingxing@cyou-inc.com";

    [BoxGroup("Models")]
    [Title("宏设置", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string MacroSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("参数设置", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string ParamsSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("资源包设置", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string AssetBundleSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("对象池", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string ObjectPool = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("游戏入口", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string GameEntry = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("事件系统", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string EventSystem = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("表格管理", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string TableManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Http管理", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string HttpManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Socket管理", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string SocketManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("UI框架", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string UIManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Lua框架", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string LuaManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("声音管理", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string AudioManager = "";
}