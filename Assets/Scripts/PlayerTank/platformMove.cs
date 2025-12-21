using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    
    public Transform playerCamera;
    private Vector3 _horizontalRot;
    private Vector3 _oldRot;
   

    
    void Update()   //跟随 摄像机方向的水平旋转
    {
        _oldRot = transform.rotation.eulerAngles;
        _horizontalRot = playerCamera.eulerAngles;
        transform.rotation=Quaternion.Euler(_oldRot.x, _horizontalRot.y, _oldRot.z);
    }
}
