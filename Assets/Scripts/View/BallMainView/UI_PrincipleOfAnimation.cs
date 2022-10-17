using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.ootii.Messages;

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

    /// <summary>
    /// 还原按钮事件
    /// </summary>
    public void ReduceButton()
    {
        
          
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_ReduceAnimation";
        lMessage.Sender = this;
        lMessage.Data = true;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
    
}
