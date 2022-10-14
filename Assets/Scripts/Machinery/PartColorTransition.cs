using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 两个纹理渐变
/// </summary>
public class PartColorTransition : MonoBehaviour
{
    private Renderer render;

    /// <summary>
    /// 目标值
    /// </summary>
    private float targetValue;

    /// <summary>
    /// 动画实例
    /// </summary>
    private Tween matTween;

    /// <summary>
    /// 材质属性块
    /// </summary>
    private MaterialPropertyBlock prop;
    /// <summary>
    /// 是否开始闪烁
    /// </summary>
    private bool isFlash;
    
    private void Awake()
    {
        render = GetComponent<Renderer>();
        prop = new MaterialPropertyBlock();
        render.GetPropertyBlock(prop);
    }

    /*private void OnMouseEnter()
    {
        if (!isFlash)
        {
            targetValue = 1;
            prop.SetFloat("value_blend", targetValue);
            render.SetPropertyBlock(prop);
        }
    }

    private void OnMouseExit()
    {
        if (!isFlash)
        {
            targetValue = 0;
            prop.SetFloat("value_blend", targetValue);
            render.SetPropertyBlock(prop);
        }
    }*/
    
    /// <summary>
    /// 动画运行更新
    /// </summary>
    private void TweenUpdate()
    {
        prop.SetFloat("value_blend", targetValue);
        render.SetPropertyBlock(prop);
    }
    /// <summary>
    /// 开启闪烁
    /// </summary>
    public void EnableFlash()
    {
        isFlash = true;
        targetValue = 0;
        matTween.Kill();
        matTween = DOTween.To(() => targetValue, x => targetValue = x, 1, 1f).SetLoops(-1, LoopType.Yoyo);
        matTween.onUpdate += TweenUpdate;
    }
    /// <summary>
    /// 关闭闪烁
    /// </summary>
    public void CloseFlash()
    {
        isFlash = false;
        matTween.Kill();
        matTween = DOTween.To(() => targetValue, x => targetValue = x, 0, 1f);
        matTween.onUpdate += TweenUpdate;
    }
}