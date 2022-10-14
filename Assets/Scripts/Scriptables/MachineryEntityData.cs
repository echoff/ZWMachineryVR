using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MachineryEntityData",fileName = "MachineryEntityData")]
public class MachineryEntityData : ScriptableObject
{
    /// <summary>
    /// 机械ID
    /// </summary>
    public int entityID;
    /// <summary>
    /// 机械类别
    /// </summary>
    public int entityType;
    /// <summary>
    /// 装配顺序
    /// </summary>
    public AssmbleAction[] assembleOrder;
    /// <summary>
    /// 拆卸顺序
    /// </summary>
    public AssmbleAction[] disassembleOrder;
    /// <summary>
    /// 装配提示文字
    /// </summary>
    public AssmbleText[] assmbleTips;
    /// <summary>
    /// 拆卸提示文字
    /// </summary>
    public AssmbleText[] disassmbleTips;
    /// <summary>
    /// 装配进度文字
    /// </summary>
    public AssmbleText[] assmbleTexts;
    /// <summary>
    /// 拆卸进度文字
    /// </summary>
    public AssmbleText[] disassmbleTexts;
}
/// <summary>
/// 装配进度文字
/// </summary>
[Serializable]
public class AssmbleText
{
    /// <summary>
    /// 开始显示的步骤
    /// </summary>
    public int beginShowStep;
    /// <summary>
    /// 文字内容
    /// </summary>
    public string content;
}
/// <summary>
/// 装备操作
/// </summary>
[Serializable]
public class AssmbleAction
{
    /// <summary>
    /// 操作的步骤
    /// </summary>
    public int step;
    /// <summary>
    /// 操作类型
    /// </summary>
    public AssmbleActionType type;
    /// <summary>
    /// 操作对象ID
    /// </summary>
    public int partID;
}
/// <summary>
/// 操作类型
/// </summary>
public enum AssmbleActionType
{
    /// <summary>
    /// 拖拽
    /// </summary>
    Drag,
    /// <summary>
    /// 点击
    /// </summary>
    Click
}
