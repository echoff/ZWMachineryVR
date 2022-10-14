using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ManualDismantling : MonoBehaviour
{
    /// <summary>
    /// 球阀页面
    /// </summary>
    [Header("球阀页面")]
    public GameObject ballValveTypePanl;


    /// <summary>
    /// 返回球阀页面
    /// </summary>
    public void BackBallValvePanl()
    {
        ballValveTypePanl.SetActive(true);
        gameObject.SetActive(false);
    }
}
