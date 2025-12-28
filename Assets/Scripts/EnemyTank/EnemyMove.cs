using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float MoveTime = 3;
    public float RandomRange = 1f;
    private float timer = 0;
    int direction = 1;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = MoveTime;
    }

    void Update()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = MoveTime+UnityEngine.Random.Range(-RandomRange, RandomRange);
            direction = -direction;
        }
    }
    
    void FixedUpdate()
    {
        OnMove();
    }

    private void OnMove()
    {
       rb.AddForce(transform.forward * (5*MoveSpeed * direction*1.5f),ForceMode.Acceleration);
    }
}
