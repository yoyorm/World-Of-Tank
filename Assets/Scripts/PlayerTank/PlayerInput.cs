using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject tankDirection;
    public float speed;
    public float rotspeed;
    private Rigidbody rb;
    private float  _rotx=0;
    private float _roty=0;
    private float _horizontalRot=0;
    public static event System.Action OnFire;   //创建静态事件
    
    void Start()
    {
        Cursor.visible = false; //隐藏和锁定鼠标
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        ViewMovement();
        Movement();
        Fire();
    }

    void ViewMovement() //视野移动
    {
        _rotx+=Input.GetAxis("Mouse X");
        _roty-=Input.GetAxis("Mouse Y");
        _rotx=Mathf.Clamp(_rotx,-180,180);  //锁定角度
        _roty=Mathf.Clamp(_roty,-15,30);
        playerCamera.transform.localRotation = Quaternion.Euler(_roty,_rotx,0);
    }

    void Movement() //移动 分为前后和转向
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(tankDirection.transform.forward * (1000*speed),ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-tankDirection.transform.forward * (1000*speed),ForceMode.Force);
        }

        _horizontalRot += Input.GetAxis("Horizontal")*rotspeed;
        transform.rotation = Quaternion.Euler(transform.rotation.x,_horizontalRot,transform.rotation.z);
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnFire?.Invoke();
        }
    }
}
