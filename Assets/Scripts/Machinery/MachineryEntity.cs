using System;
using System.Collections;
using System.Collections.Generic;
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
    /// 零件和位置(本地坐标)
    /// </summary>
    private Dictionary<MachineryPart, Vector3> partPosition = new Dictionary<MachineryPart, Vector3>();

    private void Awake()
    {
        parts = GetComponentsInChildren<MachineryPart>();
        foreach (MachineryPart lPart in parts)
        {
            partPosition.Add(lPart, lPart.gameObject.transform.localPosition);
        }
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
    /// <param name="p">零件引用</param>
    public void OnPartDragEnd(MachineryPart p)
    {
        switch (GameManager.Instance.state)
        {
            case GameState.Assemble:
            {
                break;
            }
            case GameState.Disassemble:
            {
                var action = GetCurrentDisassembleAction();
                if (action.partID == p.id && action.type == AssmbleActionType.Drag)
                {
                    if (Vector3.SqrMagnitude(p.transform.localPosition - p.beginDragPos) > removeParteDistance)
                    {
                        p.gameObject.SetActive(false);
                    }
                    else
                    {
                        //TODO:发送UI提示请求
                    }
                }
                else
                {
                    p.PartReset();
                }

                break;
            }
        }
    }
}