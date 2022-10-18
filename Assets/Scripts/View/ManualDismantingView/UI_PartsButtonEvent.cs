using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using com.ootii.Messages;

public class UI_PartsButtonEvent : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    /// <summary>
    /// 零件数量
    /// </summary>
    public int partNumber;


    /// <summary>
    /// 按钮响应事件
    /// </summary>
    public void ButtonOnClick()
    {
        Message lMessage = new Message();
        lMessage.Type = "UI_PartInfo";
        lMessage.Sender = this;
        lMessage.Data = int.Parse(transform.GetChild(0).name);
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_ManualDismantling.Instance.ShowPartName(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_ManualDismantling.Instance.HidePartName();
    }
}
