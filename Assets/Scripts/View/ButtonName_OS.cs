using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewData", menuName = "ButtonName")]
public class ButtonName_OS : ScriptableObject
{
    /// <summary>
    /// 按钮名字
    /// </summary>
    [Header("按钮的名字")]
    public string[] names;
}
