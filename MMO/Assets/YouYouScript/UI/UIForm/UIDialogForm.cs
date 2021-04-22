using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UIDialogForm : UIFormBase
{
    /// <summary>
    /// ����
    /// </summary>
    [SerializeField]
    private Text txtTitle;

    /// <summary>
    /// ����
    /// </summary>
    [SerializeField]
    private Text txtContent;

    /// <summary>
    /// ȷ�ϰ�ť
    /// </summary>
    [SerializeField]
    private Button btnConfirm;

    /// <summary>
    /// ȡ����ť
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

        //����
        txtContent.text = baseParams.StringParam1;

        //����
        if (!string.IsNullOrEmpty(baseParams.StringParam2))
        {
            txtTitle.text = baseParams.StringParam2;
        }

        //ȷ�ϰ�ť
        btnConfirm.onClick.RemoveAllListeners();
        btnConfirm.onClick.AddListener(() =>
        {
            baseParams.ActionParam1?.Invoke();
            Close();
        });

        //ȡ����ť
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