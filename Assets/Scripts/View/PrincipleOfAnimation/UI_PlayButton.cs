using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Messages;

public class UI_PlayButton : MonoBehaviour
{
    /// <summary>
    /// 暂停按钮
    /// </summary>
    [Header("暂停按钮")]
    public GameObject suspendedButton;
    
    /// <summary>
    /// 是否再次按下
    /// </summary>
    private bool isCheck = true;


    public void ButtonOnClick()
    {
        
        if (isCheck)
        {
            isCheck = false;
            suspendedButton.SetActive(!isCheck);
            gameObject.SetActive(isCheck);
        }
        else
        {
            isCheck = true;
            suspendedButton.SetActive(!isCheck);
            gameObject.SetActive(isCheck);
            
        }
        
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_PlayAnimation";//仅显示远动单元构件
        lMessage.Sender = this;
        lMessage.Data = isCheck;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
    
}
