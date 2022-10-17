using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 鼠标指针切换
/// </summary>
public class MouseCursorChange : MonoBehaviour
{
    private void OnMouseEnter()
    {
        Cursor.visible = false;
        GameManager.Instance.cursorImage.color = Color.white;
    }

    private void OnMouseExit()
    {
        Cursor.visible = true;
        GameManager.Instance.cursorImage.color = new Color(0, 0, 0, 0);
    }

    private void OnMouseOver()
    {
        GameManager.Instance.cursorImage.transform.position = Input.mousePosition;
    }

    private void OnDisable()
    {
        Cursor.visible = true;
        GameManager.Instance.cursorImage.color = new Color(0, 0, 0, 0);
    }
}
