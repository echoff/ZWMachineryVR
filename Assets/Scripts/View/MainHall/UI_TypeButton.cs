using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class UI_TypeButton : MonoBehaviour
{
    /// <summary>
    /// 背景
    /// </summary>
    [Header("背景")]
    public Image back;
    /// <summary>
    /// 图标
    /// </summary>
    [Header("图标")]
    public Image ico;
    /// <summary>
    /// 是否使用缩放效果
    /// </summary>
    [Header("缩放效果")]
    public bool scale;
    public void PointEnter()
    {
        back.gameObject.SetActive(true);
        if (scale)
        {
            ico.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
    }

    public void PointExit()
    {
        back.gameObject.SetActive(false);
        ico.transform.localScale = Vector3.one;
    }
}
