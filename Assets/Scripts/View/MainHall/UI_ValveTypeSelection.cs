using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ValveTypeSelection : MonoBehaviour
{
    /// <summary>
    /// 主视图
    /// </summary>
    [Header("主视图")]
    public GameObject mainView;
    
    public void BallValveButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMainView()
    {
        gameObject.SetActive(false);
        mainView.SetActive(true);
    }
}
