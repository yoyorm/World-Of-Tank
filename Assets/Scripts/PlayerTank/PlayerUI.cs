using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private WeaponControl _weaponControl;
    private Tank _tank;
    public Slider shootInterval;
    public Slider hp;
    void Start()
    {
        _weaponControl = GetComponent<WeaponControl>();
        _tank = GetComponent<Tank>();
    }

    // Update is called once per frame
    void Update()
    {
        shootInterval.value = _weaponControl.timeCount/_weaponControl.shootTime;
        hp.value=_tank.currentHealth/(float)_tank.maxHealth;
    }
}
