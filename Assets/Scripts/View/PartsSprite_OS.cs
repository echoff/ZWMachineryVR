using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewData", menuName = "PartsSprite")]
public class PartsSprite_OS : ScriptableObject
{
    /// <summary>
    /// 球阀零件图
    /// </summary>
    [Header("球阀零件图")] 
    public Sprite[] ballValvePartsSprites;
}
