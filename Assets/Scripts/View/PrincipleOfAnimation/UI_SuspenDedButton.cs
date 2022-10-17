using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Messages;
using UnityEngine.UI;

public class UI_SuspenDedButton : MonoBehaviour
{
    /// <summary>
    /// 播放按钮
    /// </summary>
    [Header("播放按钮")]
    public GameObject isCheckButton;
  



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
            isCheckButton.SetActive(!isCheck);
            gameObject.SetActive(isCheck);
        }
        else
        {
            isCheck = true;
            isCheckButton.SetActive(!isCheck);
            gameObject.SetActive(isCheck);
            
        }
        
        
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_SuspendedAnimation";//仅显示远动单元构件
        lMessage.Sender = this;
        lMessage.Data = isCheck;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}
