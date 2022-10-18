using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBase<GameManager>
{
    /// <summary>
    /// 游戏状态
    /// </summary>
    [Header("游戏状态")]
    public GameState state;
    /// <summary>
    /// 鼠标指针
    /// </summary>
    [Header("鼠标指针")]
    public Image cursorImage;

}

public enum GameState
{
    /// <summary>
    /// 展示状态
    /// </summary>
    View,
    /// <summary>
    /// 动画状态
    /// </summary>
    Anim,
    /// <summary>
    /// 装配状态
    /// </summary>
    Assemble,
    /// <summary>
    /// 拆卸状态
    /// </summary>
    Disassemble
}

