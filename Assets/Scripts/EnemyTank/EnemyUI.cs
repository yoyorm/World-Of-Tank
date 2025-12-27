using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    private Enemy _enemy;
    private Tank _tank;
    public Transform UITransform;
    public Slider hp;
    void Start()
    {
        _tank = GetComponent<Tank>();
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = _tank.currentHealth/(float)_tank.maxHealth;
        UITransform.rotation = Quaternion.LookRotation(-_enemy.Direction);
        
    }
}
