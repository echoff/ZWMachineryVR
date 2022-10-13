using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using com.ootii.Messages;
using UnityEngine;

public class MachineryPart : MonoBehaviour
{
    /// <summary>
    /// 零件的编号
    /// </summary>
    public int id;
    /// <summary>
    /// 纹理变化特效组件
    /// </summary>
    private TwoTexTransition twoTexTransition;

    private void Awake()
    {
        twoTexTransition = GetComponent<TwoTexTransition>();
    }

    void Start()
    {
        MessageDispatcher.AddListener("PartSelect",OnPartSelect);
    }
    /// <summary>
    /// 处理零件选择事件
    /// </summary>
    /// <param name="rmessage"></param>
    private void OnPartSelect(IMessage rmessage)
    {
        if ((int)rmessage.Data != id)
        {
            twoTexTransition.CloseFlash();
        }
    }

    private void OnMouseDown()
    {
        twoTexTransition.EnableFlash();
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "PartSelect";
        lMessage.Sender = this;
        lMessage.Data = id;
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}
