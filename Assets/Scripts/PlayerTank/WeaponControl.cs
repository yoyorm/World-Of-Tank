using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WeaponControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private ObjectPool<GameObject> bulletPool;
    public Transform fireDirection;
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(createFunc,actionOnGet,actionOnRelease,null,true,5,5);
    }

    GameObject createFunc()
    {
        GameObject bullet=GameObject.Instantiate(bulletPrefab);
        bullet.AddComponent<BulletMove>().SetPool(bulletPool);
        bullet.transform.position= fireDirection.position;
        bullet.transform.rotation=fireDirection.rotation;
        return bullet;
    }

    void actionOnGet(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    void actionOnRelease(GameObject bullet)
    {
        bullet.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet=bulletPool.Get();
        }
    }

   
}
