using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeExplode : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider _collider;
    public float ExplodeForce=30;
    private GameObject[] _child;
    private Rigidbody _rb;
    void Start()
    {
        meshRenderer=GetComponent<MeshRenderer>();
        _collider=GetComponent<BoxCollider>();
        _child = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            _child[i]=transform.GetChild(i).gameObject;
        }
        
    }

    private void OnCollisionEnter(Collision other)  //墙体破坏效果
    {
        Debug.Log("方块破碎");
        if (other.gameObject.CompareTag("bullet"))  //识别子弹
        {
            meshRenderer.enabled = false;
            _collider.enabled = false;
            for(int i = 0; i < transform.childCount; i++)
            {
                _child[i].SetActive(true);          //激活碎片
                _child[i].transform.localScale=new Vector3(UnityEngine.Random.Range(_child[i].transform.localScale.x/10f,_child[i].transform.localScale.x),UnityEngine.Random.Range(_child[i].transform.localScale.y/10f,_child[i].transform.localScale.y),UnityEngine.Random.Range(_child[i].transform.localScale.z/10f,_child[i].transform.localScale.z));
                _rb=_child[i].GetComponent<Rigidbody>();
                _rb.AddExplosionForce(ExplodeForce,transform.position,5f);     //应用爆炸力
            }

        }
    }
}
