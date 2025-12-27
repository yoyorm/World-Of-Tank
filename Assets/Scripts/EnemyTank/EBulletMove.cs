using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class EBulletMove : MonoBehaviour
{
    private ObjectPool<GameObject> bulletPool;  //引用对象池
    public float bulletSpeed=80;
    public int bulletDamage=20;
    public void SetPool(ObjectPool<GameObject> pool)=>bulletPool=pool;  //建立方法从外部引用对象池
    private float timer=0;

    void OnEnable()
    {
        timer = Time.time;  
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward* (Time.deltaTime * bulletSpeed), Space.Self);
        if (Time.time - timer >= 3) //子弹自动释放计时
        {
            bulletPool.Release(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)  //子弹碰撞释放
    {
        Tank enemy= other.gameObject.GetComponent<Tank>();
        if (enemy)
        {
            enemy.TakeDamage(bulletDamage);
        }
        bulletPool.Release(this.gameObject);
    }
}
