using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_BallValveType : MonoBehaviour
{

    /// <summary>
    /// 当前构件组件面板
    /// </summary>
    [Header("当前构件组件面板")]
    public GameObject currenthiddenArtifactsPanl;

    /// <summary>
    /// 构件组件面板
    /// </summary>
    [Header("构件组件面板")]
    public GameObject hiddenArtifactsPanl;
    
    /// <summary>
    /// 原理动画面板
    /// </summary>
    [Header("原理动画面板")]
    public GameObject principleOfAnimationPanl;
    
    /// <summary>
    /// 手动拆装面板
    /// </summary>
    [Header("手动拆装面板")]
    public GameObject manualDismantlingPanl;

    /// <summary>
    /// 按钮切换图片
    /// </summary>
    [Header("按钮切换图片")]
    public Image hiddenArtifactsImage;

    /// <summary>
    /// 按钮切换图片
    /// </summary>
    [Header("按钮切换图片数组")]
    public Sprite[] hiddenArtifactsButtonChange;

    /// <summary>
    /// 是否按下隐藏构件按钮
    /// </summary>
    private bool isCheckHiddenArtifacts;


    private void OnEnable()
    {
        isCheckHiddenArtifacts = true;
    }


    /// <summary>
    /// 构件组件
    /// </summary>
    public void HiddenArtifactsButton()
    {
        if (isCheckHiddenArtifacts)
        {
            isCheckHiddenArtifacts = false;
            hiddenArtifactsImage.sprite = hiddenArtifactsButtonChange[1];
            hiddenArtifactsPanl.SetActive(true);
            currenthiddenArtifactsPanl.SetActive(false);
        }
        else
        {
            isCheckHiddenArtifacts = true;
            hiddenArtifactsImage.sprite = hiddenArtifactsButtonChange[0];
            hiddenArtifactsPanl.SetActive(false);
            currenthiddenArtifactsPanl.SetActive(true);
        }
    }

    /// <summary>
    /// 原理动画
    /// </summary>
    public void PrincipleOfAnimationButton()
    {
        principleOfAnimationPanl.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 手动拆装
    /// </summary>
    public void ManualDismantlingButton()
    {
        manualDismantlingPanl.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 还原
    /// </summary>
    public void ReductionButton()
    {
        //TODO：还原的是通知
    }




    /// <summary />返回按钮
    public void BackHallButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
