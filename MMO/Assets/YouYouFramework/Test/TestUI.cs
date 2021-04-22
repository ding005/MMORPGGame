//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;
using YouYou.DataTable;

public class TestUI : MonoBehaviour
{
    //SafeInteger money = 0; //必须先赋值

    void Start()
    {
        //string str = Application.systemLanguage.ToString();

        //Debug.LogError("str=" + str);

        //int a = 100;


        //money++;

        //money += 20;

        //Debug.LogError("money=" + money);

        //ChapterEntity chapterEntity = GameEntry.DataTable.ChapterDBModel.Get(1);


        //Chapter chapter1 = chapter.Value;
        //int a = chapter1.Id;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            GameEntry.UI.OpenUIForm(UIFormId.UI_Login);

        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            GameEntry.UI.OpenUIForm(UIFormId.UI_Reg);
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            Chapter chapter = GameEntry.DataTable.ChapterList.GetEntityValue(1);
            string chapterName = chapter.ChapterName;
            Debug.LogError("ChapterName==" + chapterName);
            int len = chapter.BranchLevelIdLength;
            for (int i = 0; i < len; i++)
            {
                Debug.LogError("BranchLevelId==" + chapter.BranchLevelId(i));
            }

            len = chapter.BranchLevelNameLength;
            for (int i = 0; i < len; i++)
            {
                Debug.LogError("BranchLevelId==" + chapter.BranchLevelName(i));
            }

            //Sys_Prefab prefab = GameEntry.DataTable.Sys_PrefabList.GetEntityValue(1);
            //string aa = prefab.AssetPath;
            //Debug.LogError("AssetPath==" + aa);
        }

    }
}