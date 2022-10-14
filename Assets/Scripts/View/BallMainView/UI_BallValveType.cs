using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_BallValveType : MonoBehaviour
{

    [Header("当前构件组件面板")]
    public GameObject currenthiddenArtifactsPanl;

    [Header("构件组件面板")]
    public GameObject hiddenArtifactsPanl;
    
    [Header("原理动画面板")]
    public GameObject principleOfAnimationPanl;
    
    [Header("手动拆装面板")]
    public GameObject manualDismantlingPanl;
    

    /// <summary>
    /// 构件组件
    /// </summary>
    public void HiddenArtifactsButton()
    {
        hiddenArtifactsPanl.SetActive(true);
        currenthiddenArtifactsPanl.SetActive(false);
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
