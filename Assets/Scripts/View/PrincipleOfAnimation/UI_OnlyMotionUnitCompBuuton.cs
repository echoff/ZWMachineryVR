using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Messages;
using UnityEngine.UI;

public class UI_OnlyMotionUnitCompBuuton : MonoBehaviour
{
    /// <summary>
    /// 是否点击图片
    /// </summary>
    [Header("是否点击图片")]
    public Image isCheckImage;
  

    /// <summary>
    /// 是否点击切换图片
    /// </summary>
    [Header("是否点击切换图片")]
    public Sprite[] isCheckSprites;

    /// <summary>
    /// 是否再次按下
    /// </summary>
    private bool isCheck = true;




    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ButtonOnClick()
    {
        if (isCheck)
        {
            isCheck = false;
            isCheckImage.sprite = isCheckSprites[1];
        }
        else
        {
            isCheck = true;
            isCheckImage.sprite = isCheckSprites[0];
        }
        
        
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "OnlyAnimation";//仅显示远动单元构件
        lMessage.Sender = this;
        lMessage.Data = isCheck;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}
