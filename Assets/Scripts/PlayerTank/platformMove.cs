using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    
    public Transform playerCamera;
    public Transform connon;
    public Transform FireDirection;
    private Vector3 _horizontalRot;
    private Vector3 _oldRot;
   

    
    void Update()   //跟随 摄像机方向的水平旋转
    {
        _oldRot = transform.rotation.eulerAngles;
        _horizontalRot = playerCamera.eulerAngles;
        transform.rotation=Quaternion.Euler(_oldRot.x, _horizontalRot.y, _oldRot.z);    //炮台旋转
        connon.rotation = Quaternion.Euler(_horizontalRot.x-20, _oldRot.y, _oldRot.z);  //炮管旋转
        FireDirection.transform.rotation = Quaternion.Euler(_horizontalRot.x - 20, _horizontalRot.y, _oldRot.z);//开火方向旋转
    }
}
