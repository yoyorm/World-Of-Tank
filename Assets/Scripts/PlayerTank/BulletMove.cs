using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class BulletMove : MonoBehaviour
{
    private ObjectPool<GameObject> bulletPool;  //引用对象池
    public float bulletSpeed=120;
    public int bulletDamage=35;
    public void SetPool(ObjectPool<GameObject> pool)=>bulletPool=pool;  //建立方法从外部引用对象池
    private float timer=0;
    private Rigidbody rb;
    private bool released;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        timer = Time.time;  
        released=false;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward* (Time.deltaTime * bulletSpeed), Space.Self);
        //rb.AddForce(transform.forward* (bulletSpeed),ForceMode.Force);
        if (released==false&&Time.time - timer >= 4) //子弹自动释放计时
        {
            bulletPool.Release(this.gameObject);
            released=true;
        }
    }

    void OnCollisionEnter(Collision other)  //子弹碰撞释放
    {
        Tank enemy= other.gameObject.GetComponent<Tank>();
        if (enemy)
        {
            enemy.TakeDamage(bulletDamage);
        }
        if(released==false)
        {
            bulletPool.Release(this.gameObject);
            released = true;
        }
    }
}
