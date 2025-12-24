using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class BulletMove : MonoBehaviour
{
    private ObjectPool<GameObject> bulletPool;
    public float bulletSpeed=100;
    public void SetPool(ObjectPool<GameObject> pool)=>bulletPool=pool;
    

    
    void Update()
    {
        transform.Translate(Vector3.forward* (Time.deltaTime * bulletSpeed), Space.Self);
    }

    void OnCollisionEnter(Collision other)
    {
        bulletPool.Release(this.gameObject);
    }
}
