using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InitialPartsLibrary : MonoBehaviour
{

    /// <summary>
    /// 球阀零件按钮
    /// </summary>
    public List<GameObject> partsButton;

    /// <summary>
    /// 按钮的个数
    /// </summary>
    public int buttonChirld;

    /// <summary>
    /// 零件图片
    /// </summary>
    [Header("零件图片")]
    public PartsSprite_OS partsSpriteOS;
    
    /// <summary>
    /// 零件名称
    /// </summary>
    [Header("零件名称")]
    public ButtonName_OS buttonNameOS;

    void Start()
    {
        buttonChirld = transform.childCount;

        //获取所有按钮
        for (int i = 0; i < buttonChirld; i++)
        {
            partsButton.Add(transform.GetChild(i).gameObject);
        }
        
        //初始化按钮名字
        for (int i = 0; i < buttonChirld; i++)
        {
            partsButton[i].transform.GetChild(0).GetComponent<Image>().sprite =
                partsSpriteOS.ballValvePartsSprites[i];

            partsButton[i].gameObject.name = buttonNameOS.names[i];
            
            partsButton[i].transform.GetChild(0).name = i.ToString();

            if (i == 0)
            {
                partsButton[i].transform.GetChild(0).GetComponent<UI_PartsButtonEvent>().partNumber = 0;
            }
        }

    }
}
