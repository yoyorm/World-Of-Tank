using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    GameObject player;
    public Transform cameraTransform;
    public Vector3 Direction;
    public float AimRange=25;
    public float FireRange = 20;
    public float FireInterval = 3f;
    [SerializeField] private float timer;
    [SerializeField]
    private float distance;
    public System.Action FireEvent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = FireInterval;
    }

    
    void Update()
    {
        CalculateDirection();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (distance < AimRange)
        {
            Aim();
            if (distance < FireRange&&timer<=0) //进入射程距离且无射击冷却
            {
                Fire(); //开火
                timer = FireInterval;
            }
        }
    }
    
    void CalculateDirection()   //计算玩家方向和距离
    {
        Direction = transform.position - player.transform.position;
        distance = Direction.magnitude;
        Direction.Normalize();
    }
    void Aim()      //炮台瞄准
    {
        cameraTransform.rotation = Quaternion.LookRotation(-Direction, Vector3.up);
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x+20, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
    }

    void Fire()
    {
        FireEvent?.Invoke();
    }
}
