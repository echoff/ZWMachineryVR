using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using com.ootii.Messages;
using UnityEngine;

/// <summary>
/// 机械物体
/// </summary>
public class MachineryEntity : MonoBehaviour
{
    /// <summary>
    /// 此机械物体的配置
    /// </summary>
    [Header("此机械物体的配置")]
    public MachineryEntityData data;

    /// <summary>
    /// 当前装配进度
    /// </summary>
    [HideInInspector]
    public int currentAssembleStep;

    /// <summary>
    /// 当前拆卸进度
    /// </summary>
    [HideInInspector]
    public int currentDisAssembleStep;
    /// <summary>
    /// 移除零件的时候应该拖拽的最小距离
    /// </summary>
    [Header("移除零件的时候应该拖拽的最小距离")]
    public float removeParteDistance = 0.1f;
    /// <summary>
    /// 所有的零件
    /// </summary>
    private MachineryPart[] parts;

    /// <summary>
    /// 当前的步数
    /// </summary>
    [HideInInspector] public int currentStep;

    /// <summary>
    /// 动画系统
    /// </summary>
    private Animator animator;

    /// <summary>
    /// 零件和位置(本地坐标)
    /// </summary>
    private Dictionary<MachineryPart, Vector3> partPosition = new Dictionary<MachineryPart, Vector3>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        parts = GetComponentsInChildren<MachineryPart>();
        foreach (MachineryPart lPart in parts)
        {
            partPosition.Add(lPart, lPart.gameObject.transform.localPosition);
        }
        
    }

    private void Start()
    {
        MessageDispatcher.AddListener("MachineryPartEndDrag",OnPartDragEnd);
    }
    

    /// <summary>
    /// 获取当前应该组装的操作
    /// </summary>
    /// <returns></returns>
    public AssmbleAction GetCurrentAssembleAction()
    {
        return data.assembleOrder[currentStep];
    }

    /// <summary>
    /// 获取当前应该拆卸的操作
    /// </summary>
    /// <returns></returns>
    public AssmbleAction GetCurrentDisassembleAction()
    {
        return data.disassembleOrder[currentStep];
    }
    /// <summary>
    /// 显示或隐藏某个零件
    /// </summary>
    /// <param name="msg">消息</param>
    private void OnPartHideOrShow(IMessage msg)
    {
        object[] data = (object[])msg.Data;
        int typeID = (int) data[0];
        bool hide = (bool) data[1];

        List<GameObject> part = FindPartWithTypeID(typeID);
        foreach (var lGameObject in part)
        {
            lGameObject.SetActive(!hide);
        }
    }
    /// <summary>
    /// 通过类型ID找到零件
    /// </summary>
    /// <param name="typeID">类型ID</param>
    /// <returns>零件</returns>
    private List<GameObject> FindPartWithTypeID(int typeID)
    {
        List<GameObject> res = new List<GameObject>();
        foreach (var item in parts)
        {
            if (item.typeID == typeID)
            {
                res.Add(item.gameObject);
            }
        }

        return res;
    }
    /// <summary>
    /// 暂停播放动画
    /// </summary>
    private void PauseAnmin()
    {
        animator.speed = animator.speed == 1 ? 0 : 1;
    }

    /// <summary>
    /// 某一个零件被点击
    /// </summary>
    /// <param name="p">零件引用</param>
    public void OnPartClick(MachineryPart p)
    {
        switch (GameManager.Instance.state)
        {
            case GameState.Assemble:
            {
                break;
            }
            case GameState.Disassemble:
            {
                break;
            }
        }
    }

    /// <summary>
    /// 某一个零件被鼠标拖拽
    /// </summary>
    /// <param name="msg">消息</param>
    public void OnPartDragEnd(IMessage msg)
    {
        switch (GameManager.Instance.state)
        {
            case GameState.Assemble:
            {
                break;
            }
            case GameState.Disassemble:
            {
                print($"current Step:{currentStep}");
                MachineryPart p = (MachineryPart) msg.Data;               
                var action = GetCurrentDisassembleAction();
                //验证拆卸时候拖拽距离
                if (Vector3.SqrMagnitude(p.transform.localPosition - p.beginDragPos) > removeParteDistance)
                {
                    if (action.partID == p.id && action.type == AssmbleActionType.Drag)
                    {
                        currentStep++;
                        p.gameObject.SetActive(false);
                    }
                    else
                    {
                        //零件错误
                        //TODO:发送UI提示请求
                        p.PartReset();
                    }
                }
                else
                {
                    //拖拽距离不足
                    //TODO:发送UI提示请求
                    p.PartReset();
                }
                break;
            }
        }
    }
}