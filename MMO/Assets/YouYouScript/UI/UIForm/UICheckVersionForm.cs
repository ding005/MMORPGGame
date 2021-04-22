//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

public class UICheckVersionForm : UIFormBase
{
    [SerializeField]
    private Text txtTip;

    [SerializeField]
    private Text txtSize;

    [SerializeField]
    private Text txtResourceVersion;

    [SerializeField]
    private Scrollbar scrollbar;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.CheckVersionBeginDownload, OnCheckVersionBeginDownload);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.CheckVersionDownloadUpdate, OnCheckVersionDownloadUpdate);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.CheckVersionDownloadComplete, OnCheckVersionDownloadComolete);

        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.PreloadBegin, OnPreloadBegin);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.PreloadUpdate, OnPreloadUpdate);
        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.PreloadComplete, OnPreloadComplete);

        GameEntry.Event.CommonEvent.AddEventListener(SysEventId.CloseCheckVersionUI, OnCloseCheckVersionUI);

        txtTip.gameObject.SetActive(false);
        txtSize.gameObject.SetActive(false);
        scrollbar.gameObject.SetActive(false);
    }

    #region 检查更新事件
    private void OnCheckVersionBeginDownload(object userData)
    {
        txtTip.gameObject.SetActive(true);
        txtSize.gameObject.SetActive(true);
        scrollbar.gameObject.SetActive(true);

        txtResourceVersion.text = string.Format("资源版本号 {0}", GameEntry.Resource.ResourceManager.CDNVersion);
    }

    private void OnCheckVersionDownloadUpdate(object userData)
    {
        BaseParams args = userData as BaseParams;

        txtTip.text = string.Format("正在下载{0}/{1}", args.IntParam1, args.IntParam2);
        scrollbar.size = (float)args.IntParam1 / args.IntParam2;

        txtSize.text = string.Format("{0:f2}M/{1:f2}M", (float)args.ULongParam1 / (1024 * 1024), (float)args.ULongParam2 / (1024 * 1024));
    }

    private void OnCheckVersionDownloadComolete(object userData)
    {

    }
    #endregion

    #region 预加载事件

    private void OnPreloadBegin(object userData)
    {
        txtTip.gameObject.SetActive(true);
        scrollbar.gameObject.SetActive(true);
        txtSize.gameObject.SetActive(false);
        txtResourceVersion.text = string.Format("资源版本号 {0}", GameEntry.Resource.ResourceManager.CDNVersion);
    }

    private void OnPreloadUpdate(object userData)
    {
        BaseParams args = userData as BaseParams;

        txtTip.text = string.Format("正在加载资源 {0:f0}%", Mathf.Min(args.FloatParam1, 100));
        scrollbar.size = args.FloatParam1 * 0.01f;
    }

    private void OnPreloadComplete(object userData)
    {

    }

    private void OnCloseCheckVersionUI(object userData)
    {
        Destroy(gameObject);
    }

    #endregion

    protected override void OnBeforDestroy()
    {
        base.OnBeforDestroy();
        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.CheckVersionBeginDownload, OnCheckVersionBeginDownload);
        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.CheckVersionDownloadUpdate, OnCheckVersionDownloadUpdate);
        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.CheckVersionDownloadComplete, OnCheckVersionDownloadComolete);

        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.PreloadBegin, OnPreloadBegin);
        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.PreloadUpdate, OnPreloadUpdate);
        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.PreloadComplete, OnPreloadComplete);

        GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.CloseCheckVersionUI, OnCloseCheckVersionUI);
    }
}