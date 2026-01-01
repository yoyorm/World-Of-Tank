using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth;
    void Start()
    {
        currentHealth=maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth-=damage;
    }
    void Death()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.layer == 7)
            {
                Score.instance.AddScore(1);
                
            }
            Debug.Log("击败敌人");
            Destroy(this.gameObject);
            
            
        }
    }
    
}
