using System.Collections;
using System.Collections.Generic;
using com.ootii.Messages;
using UnityEngine;






public class UI_MainButton : MonoBehaviour
{
    
   
    
    // Start is called before the first frame update
    /*void Start()
    {
        //MessageDispatcher.AddListener("PartSelect",OnPartSelect);
    }*/

    /*private void OnPartSelect(IMessage rmessage)
    {
        
    }*/





    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ButtonOnClick()
    {
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_PartSelect";
        lMessage.Sender = this;
        lMessage.Data = int.Parse(gameObject.name);
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}
