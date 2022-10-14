using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBase<GameManager>
{
    public int[] roder = { };
    /// <summary>
    /// 游戏状态
    /// </summary>
    public GameState state;
    /// <summary>
    /// 光标
    /// </summary>
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

