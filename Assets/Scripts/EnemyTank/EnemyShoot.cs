using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

//该组件在于实现子弹的对象池和开火

public class EnemeyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public  ObjectPool<GameObject> EbulletPool;
    public Transform fireDirection;
    GameObject tank ;
    Rigidbody tankRigidbody;
    
    private Enemy _enemy;
    // public AudioSource fireSound;
    // public float soundSize = 0.3f;
    // private float soundCount=0;
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        EbulletPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,5,5);
        _enemy.FireEvent += Fire;             //注册开火函数给事件
        tank = fireDirection.parent.gameObject;
        tankRigidbody = tank.GetComponent<Rigidbody>();
        
        
        //soundCount=soundSize;
    }
    
    GameObject createFunc()
    {
        GameObject bullet=GameObject.Instantiate(bulletPrefab); //子弹实例化
        bullet.AddComponent<EBulletMove>().SetPool(EbulletPool);  //为子弹添加子弹组件的同时设置自己所处的对象池！！！
        bullet.transform.position= fireDirection.position;      //改变子弹位置和方向
        bullet.transform.rotation=fireDirection.rotation;
        return bullet;
    }

    void actionOnGet(GameObject bullet)
    {
        bullet.SetActive(true);
        bullet.transform.position= fireDirection.position;  //每次重新get都需要重置发射位置
        bullet.transform.rotation=fireDirection.rotation;
    }

    void actionOnRelease(GameObject bullet)
    {
        bullet.SetActive(false);                        //释放失活即可
    }

    void actionOnDestroy(GameObject bullet)
    {
        GameObject.Destroy(bullet);                     //对象池超额自动销毁
    }
    
    private void Fire()
    {
        
            // soundCount = soundSize;
            // fireSound.Play();
            GameObject bullet = EbulletPool.Get();
            tankRigidbody.AddForce(-fireDirection.forward * 80, ForceMode.Impulse); //增加开火后坐力
        
    }

    
    private void OnDestroy()
    {
        _enemy.FireEvent -= Fire;
    }
}
