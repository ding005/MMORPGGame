using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UIDialogForm : UIFormBase
{
    /// <summary>
    /// 标题
    /// </summary>
    [SerializeField]
    private Text txtTitle;

    /// <summary>
    /// 内容
    /// </summary>
    [SerializeField]
    private Text txtContent;

    /// <summary>
    /// 确认按钮
    /// </summary>
    [SerializeField]
    private Button btnConfirm;

    /// <summary>
    /// 取消按钮
    /// </summary>
    [SerializeField]
    private Button btnCancel;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);

        BaseParams baseParams = userData as BaseParams;

        DialogFormType dialogFormType = (DialogFormType)baseParams.IntParam1;
        if (dialogFormType == DialogFormType.Normal)
        {
            btnCancel.gameObject.SetActive(false);
        }
        else
        {
            btnCancel.gameObject.SetActive(true);
        }

        //内容
        txtContent.text = baseParams.StringParam1;

        //标题
        if (!string.IsNullOrEmpty(baseParams.StringParam2))
        {
            txtTitle.text = baseParams.StringParam2;
        }

        //确认按钮
        btnConfirm.onClick.RemoveAllListeners();
        btnConfirm.onClick.AddListener(() =>
        {
            baseParams.ActionParam1?.Invoke();
            Close();
        });

        //取消按钮
        btnCancel.onClick.RemoveAllListeners();
        btnCancel.onClick.AddListener(() =>
        {
            baseParams.ActionParam2?.Invoke();
            Close();
        });
    }

    protected override void OnClose()
    {
        base.OnClose();
    }

    protected override void OnBeforDestroy()
    {
        base.OnBeforDestroy();

        txtTitle = null;
        txtContent = null;
        btnConfirm = null;
        btnCancel = null;
    }
}