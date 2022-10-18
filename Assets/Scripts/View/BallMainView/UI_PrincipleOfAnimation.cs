using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.ootii.Messages;

public class UI_PrincipleOfAnimation : MonoBehaviour
{


    /// <summary>
    /// 按钮父物体
    /// </summary>
    [Header("按钮父物体")]
    public GameObject buttonParent;
    

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
        //设置所有的按键还原
        foreach (var button in buttonParent.GetComponent<UI_PrincipleOfAnimationInitialButton>().buttons)
        {
            Debug.Log(button.name);
            
            if (button.name.Equals("1") || button.name.Equals("3") || button.name.Equals("5") ||
                button.name.Equals("11") || button.name.Equals("13") || button.name.Equals("14"))
            {
                
            }
            else
            {
                button.GetComponent<UI_PrincipleOfAnimationButtonEvent>().isCheckImage.sprite =
                    button.GetComponent<UI_PrincipleOfAnimationButtonEvent>().isCheckSprites[1];

                button.GetComponent<UI_PrincipleOfAnimationButtonEvent>().isHiddenImage.gameObject.SetActive(false);

                button.GetComponent<UI_PrincipleOfAnimationButtonEvent>().isCheck = true;
            }
            
        }
        
          
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_ReduceAnimation";
        lMessage.Sender = this;
        lMessage.Data = true;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
    
}
