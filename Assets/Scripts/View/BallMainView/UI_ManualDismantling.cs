using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.ootii.Messages;

public class UI_ManualDismantling : SingletonMonoBase<UI_ManualDismantling>
{

    /// <summary>
    /// 名称显示文本
    /// </summary>
    [Header("名称显示文本")]
    public Text partNameText;
    
    
    /// <summary>
    /// 提示文本
    /// </summary>
    [Header("提示文本")]
    public Text paomptText;

    /// <summary>
    /// 是否成功安装
    /// </summary>
    public bool isInstallation;
    
    
    /// <summary>
    /// 球阀页面
    /// </summary>
    [Header("球阀页面")]
    public GameObject ballValveTypePanl;


    private void Start()
    {
        MessageDispatcher.AddListener("PartSelect",OnPartSelect);
        partNameText.gameObject.SetActive(false);
        paomptText.gameObject.SetActive(false);
    }

    

    private void OnPartSelect(IMessage rmessage)
    {
        
    }
    

    /// <summary>
    /// 返回球阀页面
    /// </summary>
    public void BackBallValvePanl()
    {
        ballValveTypePanl.SetActive(true);
        gameObject.SetActive(false);
    }



    /// <summary>
    /// 显示按钮名字
    /// </summary>
    /// <param name="name">按钮名字</param>
    public void ShowPartName(string name)
    {
        partNameText.gameObject.SetActive(true);
        partNameText.text = name;
    }
    
    /// <summary>
    /// 隐藏按钮名字
    /// </summary>
    public void HidePartName()
    {
        partNameText.gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 显示提示信息
    /// </summary>
    /// <param name="name">提示信息内容</param>
    public void ShowPompt(string content)
    {
        paomptText.gameObject.SetActive(true);
        paomptText.text = content;
    }
    
    /// <summary>
    /// 隐藏提示信息
    /// </summary>
    public void HidePompt()
    {
        paomptText.gameObject.SetActive(false);
    }
}
