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
    
    
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,actionOnDestroy,true,5,5);
        PlayerInput.OnFire += Fire;             //注册开火函数给事件
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
            GameObject bullet=bulletPool.Get();         
    }

    private void OnDestroy()
    {
        PlayerInput.OnFire -= Fire;
    }
}
