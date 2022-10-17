using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using com.ootii.Messages;
using UnityEngine;

public class MachineryPart : MonoBehaviour
{
    /// <summary>
    /// 零件的类型
    /// </summary>
    [Header("零件类型")]
    public int typeID;

    /// <summary>
    /// 零件的编号
    /// </summary>
    [Header("零件编号")]
    public int id;

    /// <summary>
    /// 纹理变化特效组件
    /// </summary>
    private PartColorTransition partColorTransition;

    /// <summary>
    /// 自己所属的机械实例
    /// </summary>
    private MachineryEntity entity;

    /// <summary>
    /// 点击位置与物体坐标偏移值
    /// </summary>
    private Vector3 offset;

    /// <summary>
    /// 点击位置
    /// </summary>
    private Vector3 hitPoint;

    /// <summary>
    /// 屏幕坐标Z轴值
    /// </summary>
    private float camZ;

    /// <summary>
    /// 是否拖拽
    /// </summary>
    private bool isDrag;

    /// <summary>
    /// 开始拖拽前的位置
    /// </summary>
    [HideInInspector]
    public Vector3 beginDragPos;

    /// <summary>
    /// 当前是否选中
    /// </summary>
    private bool isSelected;

    private void Awake()
    {
        partColorTransition = GetComponent<PartColorTransition>();
        entity = GetComponentInParent<MachineryEntity>();
        //typeID = int.TryParse(gameObject.name,out typeID);
    }

    void Start()
    {
        MessageDispatcher.AddListener("PartSelect", OnPartSelect);
    }

    private void Update()
    {
        if (isDrag)
        {
            Vector3 point =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZ));
            transform.position = point + offset;
        }
    }

    /// <summary>
    /// 处理零件选择事件
    /// </summary>
    /// <param name="rmessage"></param>
    private void OnPartSelect(IMessage rmessage)
    {
        if ((int) rmessage.Data != typeID)
        {
            if (partColorTransition)
            {
                isSelected = false;
                partColorTransition.CloseFlash();
            }
        }
        else
        {
            if (partColorTransition)
            {
                partColorTransition.EnableFlash();
                isSelected = true;
            }
        }
    }
    /// <summary>
    /// 重置零件位置
    /// </summary>
    public void PartReset()
    {
        transform.localPosition = beginDragPos;
    }
    /// <summary>
    /// 移动套鼠标位置并设置为拖拽
    /// </summary>
    private void MoveToMouseAndDrag()
    {
        offset = Vector3.zero;
        isDrag = true;
    }

    private void OnMouseDown()
    {
        if (partColorTransition)
        {
            partColorTransition.EnableFlash();
        }

        //发送消息选中零件
        Message lMessage = new Message();
        lMessage.Type = "PartSelect";
        lMessage.Sender = this;
        lMessage.Data = typeID;//零件的编号
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);
        //拆解状态
        if (GameManager.Instance.state == GameState.Disassemble)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info))
            {
                isDrag = true;
                beginDragPos = transform.localPosition;
                offset = transform.position - info.point;
                hitPoint = info.point;
                camZ = Camera.main.WorldToScreenPoint(hitPoint).z;
            }
        }
    }

    private void OnMouseUp()
    {
        if (isDrag)
        {
            isDrag = false;
            Message lMessage = new Message();
            lMessage.Type = "MachineryPartEndDrag";
            lMessage.Sender = this;
            lMessage.Data = this;
            lMessage.Delay = EnumMessageDelay.IMMEDIATE;
            MessageDispatcher.SendMessage(lMessage);
        }
    }

    private void OnMouseEnter()
    {
        if (partColorTransition)
        {
            partColorTransition.EnableFlash();
        }
        /*Message lMessage = new Message();
        lMessage.Type = "MouseEnterExit";
        lMessage.Sender = this;
        lMessage.Data = true;
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);*/
    }

    private void OnMouseExit()
    {
        if (partColorTransition && !isSelected)
        {
            partColorTransition.CloseFlash();
        }
        /*Message lMessage = new Message();
        lMessage.Type = "MouseEnterExit";
        lMessage.Sender = this;
        lMessage.Data = false;
        lMessage.Delay = EnumMessageDelay.IMMEDIATE;
        MessageDispatcher.SendMessage(lMessage);*/
    }
    
    
}