using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using com.ootii.Messages;

public class UI_InitoalHiddenArtifacets : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// 是否按下当前按钮
    /// </summary>
    public bool bIsCheck;
    
    /// <summary>
    /// 名字文本
    /// </summary>
    [Header("名字文本")] public Text nameText;

    /// <summary>
    /// 名字文本
    /// </summary>
    [Header("名字文本")] public Image isCheck;

    /// <summary>
    /// 按钮勾选图片
    /// </summary>
    [Header("按钮勾选图片")] public Sprite[] isCheckSprites;

    /// <summary>
    /// 当前按钮图片
    /// </summary>
    private Image selfButton;


    private void OnEnable()
    {
        selfButton = GetComponent<Image>();
        bIsCheck = true;
        isCheck.sprite = isCheckSprites[0];
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (bIsCheck)
        {
            bIsCheck = false;
            isCheck.sprite = isCheckSprites[1];
            
            //selfButton.color = Color.red;

            selfButton.color = new Color(255, 255, 255, 100);
        }
        else
        {
            bIsCheck = true;
            isCheck.sprite = isCheckSprites[0];
            
            //selfButton.color = Color.white;
            selfButton.color = new Color(255, 255, 255, 255);
        }
    }


    /// <summary>
    /// 按钮事件
    /// </summary>
    public void ButtonOnClick()
    {
        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "UI_PartHidden";
        lMessage.Sender = this;
        lMessage.Data = new object[]{int.Parse(gameObject.name),bIsCheck};
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
    }
}

    
