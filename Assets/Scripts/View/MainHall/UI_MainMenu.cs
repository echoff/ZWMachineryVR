using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{

    [Header("阀类选择面板")]
    public GameObject ValveTypePanl;
    
    
    

    /// <summary />阀类按钮
    public void ValveTypeButton()
    {
        ValveTypePanl.SetActive(true);
        gameObject.SetActive(false);
    }
}
