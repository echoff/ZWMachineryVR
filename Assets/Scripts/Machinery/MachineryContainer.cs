using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

/// <summary>
/// 零件整体的移动旋转
/// </summary>
public class MachineryContainer : MonoBehaviour
{
    /// <summary>
    /// 鼠标滚轮灵敏度
    /// </summary>
    [Header("鼠标滚轮灵敏度")]
    public float scrollWheelSensitivity=0.1f;
    /// <summary>
    /// 鼠标旋转灵敏度
    /// </summary>
    [Header("鼠标旋转灵敏度")]
    public float roteSensitivity = 2;
    /// <summary>
    /// 机械模型的根节
    /// </summary>
    [Header("机械模型的根节")]
    public GameObject root;
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

    private void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            transform.transform.position +=Vector3.back * scrollWheel*scrollWheelSensitivity;
        }

        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            root.transform.Rotate(Vector3.up,-x*roteSensitivity,Space.Self);
            float y = Input.GetAxis("Mouse Y");
            transform.Rotate(Vector3.right,y*roteSensitivity,Space.Self);
        }

        if (Input.GetMouseButtonDown(0)&&GameManager.Instance.state == GameState.View)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if (Physics.Raycast(ray, out info))
            {
                isDrag = true;
                offset = transform.position - info.point;
                hitPoint = info.point;
                camZ = Camera.main.WorldToScreenPoint(hitPoint).z;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }

        if (isDrag)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camZ));
            transform.position = point + offset;
        }
    }
    

}