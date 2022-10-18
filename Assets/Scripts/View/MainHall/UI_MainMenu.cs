using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{

    [Header("阀类选择面板")]
    public GameObject ValveTypePanl;
    /// <summary>
    /// 主页
    /// </summary>
    [Header("主页按钮")]
    public GameObject homeBtn;
    
    

    /// <summary>
    /// 进入阀类按钮
    /// </summary>
    public void ValveTypeButton()
    {
        ValveTypePanl.SetActive(true);
        gameObject.SetActive(false);
        homeBtn.SetActive(true);
    }
    /// <summary>
    /// 返回主视图
    /// </summary>
    public void BackToHomeView()
    {
        ValveTypePanl.SetActive(false);
        gameObject.SetActive(true);
        homeBtn.SetActive(false);
    }
}
