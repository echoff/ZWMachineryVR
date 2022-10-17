using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.ootii.Messages;

public class UI_PrincipleOfAnimationButtonEvent : MonoBehaviour
{
    /// <summary>
    /// 是否点击图片
    /// </summary>
    [Header("是否点击图片")]
    public Image isCheckImage;
    
    /// <summary>
    /// 是否隐藏图片
    /// </summary>
    [Header("是否隐藏图片")]
    public Image isHiddenImage;

    /// <summary>
    /// 是否点击切换图片
    /// </summary>
    [Header("是否点击切换图片")]
    public Sprite[] isCheckSprites;

    /// <summary>
    /// 是否再次按下
    /// </summary>
    private bool isCheck;

    private void OnEnable()
    {
        isCheck = true;

        if (gameObject.name.Equals("1") || gameObject.name.Equals("3") || gameObject.name.Equals("5") ||
            gameObject.name.Equals("11") || gameObject.name.Equals("13") || gameObject.name.Equals("14"))
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
    }

    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ButtonOnClick()
    {
        if (isCheck)
        {
            isCheck = false;
            isCheckImage.sprite = isCheckSprites[0];
            isHiddenImage.gameObject.SetActive(true);
        }
        else
        {
            isCheck = true;
            isCheckImage.sprite = isCheckSprites[1];
            isHiddenImage.gameObject.SetActive(false);
        }
        
        
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "Animation";
        lMessage.Sender = this;
        lMessage.Data = int.Parse(gameObject.name);//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}
