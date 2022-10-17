using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InitialButtonName : MonoBehaviour
{
    /// <summary />球阀信息按钮
    public List<GameObject> buttons;

    /// <summary />按钮名字配置
    [Header("按钮名字配置")]
    public ButtonName_OS buttonNameOS;
    
    protected  virtual void OnEnable()
    {
        //获取所有按钮的数量
        int chirds = transform.childCount;

        //获取所有按钮
        for (int i = 0; i < chirds; i++)
        {
            buttons.Add(transform.GetChild(i).gameObject);
        }

        //初始化按钮名字
        for (int i = 0; i < chirds; i++)
        {
            buttons[i].transform.GetChild(0).GetComponent<Text>().text = buttonNameOS.names[i];
            buttons[i].gameObject.name = i.ToString();
        }
        
    }
}
