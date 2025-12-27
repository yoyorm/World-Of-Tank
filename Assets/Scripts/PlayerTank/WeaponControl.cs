using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


//该组件在于实现子弹的对象池和开火

public class WeaponControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private ObjectPool<GameObject> bulletPool;
    public Transform fireDirection;
    GameObject tank ;
    Rigidbody tankRigidbody;
    public float shootTime = 3;
    public float timeCount;
    public AudioSource fireSound;
    public float soundSize = 0.3f;
    private float soundCount=0;
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,5,5);
        PlayerInput.OnFire += Fire;             //注册开火函数给事件
        tank = fireDirection.parent.gameObject;
        tankRigidbody = tank.GetComponent<Rigidbody>();
        timeCount=shootTime;
        soundCount=soundSize;
    }
    
    GameObject createFunc()
    {
        GameObject bullet=GameObject.Instantiate(bulletPrefab); //子弹实例化
        bullet.AddComponent<BulletMove>().SetPool(bulletPool);  //为子弹添加子弹组件的同时设置自己所处的对象池！！！
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
        if (timeCount<=0)
        {
            soundCount = soundSize;
            fireSound.Play();
            GameObject bullet = bulletPool.Get();
            timeCount = shootTime;
            tankRigidbody.AddForce(-fireDirection.forward * 800, ForceMode.Impulse); //增加开火后坐力
        }
    }

    void Update()
    {
        if(timeCount>0)
            timeCount -= Time.deltaTime;
        else
        {
            timeCount = 0;
            
        }
        if(soundCount>0)
            soundCount -= Time.deltaTime/1.5f;
        else
        {
            soundCount = 0;
            
        }
        fireSound.volume = soundCount;
    }
    
    private void OnDestroy()
    {
        PlayerInput.OnFire -= Fire;
    }
}
