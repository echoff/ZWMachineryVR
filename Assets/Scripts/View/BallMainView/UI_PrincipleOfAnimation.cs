using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PrincipleOfAnimation : MonoBehaviour
{


    /// <summary>
    /// 球阀页面
    /// </summary>
    [Header("球阀页面")]
    public GameObject ballValveTypePanl;


    /// <summary>
    /// 返回球阀页面
    /// </summary>
    public void BackBallValve()
    {
        ballValveTypePanl.SetActive(true);
        gameObject.SetActive(false);
    }
}
