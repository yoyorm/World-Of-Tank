using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void OnStartClick() 
    {
        Debug.Log("开始游戏");
        
        SceneManager.LoadScene("Test");
    }
}
