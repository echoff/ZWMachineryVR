using System.Collections;
using System.Collections.Generic;
using com.ootii.Messages;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public bool moveWithMouse;
    public float ins = 0.5f;
    void Start()
    {
        MessageDispatcher.AddListener("MouseEnterExit",OnMouseEnterExit);
    }

    private void OnMouseEnterExit(IMessage rmessage)
    {
        bool value = (bool)rmessage.Data;
        if (value)
        {
            moveWithMouse = true;
        }
    }

    void Update()
    {
        if (moveWithMouse && Input.GetMouseButton(0))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            transform.Translate(new Vector3(-x,-y,0)*ins);
        }
    }
}
