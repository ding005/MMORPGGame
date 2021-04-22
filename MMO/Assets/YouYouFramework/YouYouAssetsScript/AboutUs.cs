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
    [LabelText("�������")]
    [GUIColor(2, 6, 6, 1)]
    public string Name = "YouYouFramework";

    [PropertySpace(10)]
    [VerticalGroup("AboutUs/Split/Right")]
    [DisplayAsString]
    [LabelText("�汾��")]
    public string Version = "1.1";

    [VerticalGroup("AboutUs/Split/Right")]
    //[DisplayAsString]
    [LabelText("����")]
    public string Author = "������";

    [VerticalGroup("AboutUs/Split/Right")]
    //[DisplayAsString]
    [LabelText("��ϵ��ʽ")]
    public string Contact = "zhumingxing@cyou-inc.com";

    [BoxGroup("Models")]
    [Title("������", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string MacroSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("��������", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string ParamsSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("��Դ������", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string AssetBundleSettings = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("�����", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string ObjectPool = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("��Ϸ���", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string GameEntry = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("�¼�ϵͳ", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string EventSystem = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("������", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string TableManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Http����", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string HttpManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Socket����", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string SocketManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("UI���", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string UIManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("Lua���", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string LuaManager = "";

    [PropertySpace(10)]
    [BoxGroup("Models")]
    [Title("��������", bold: false)]
    [HideLabel]
    [MultiLineProperty]
    public string AudioManager = "";
}