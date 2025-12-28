using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    private Tank player;
    bool gameOver = false;
    
    public static System.Action  onPlayerDeath;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Tank>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth<=0&&gameOver==false)
        {
            onPlayerDeath.Invoke();
            gameOver = true;
            
        }
    }
}
