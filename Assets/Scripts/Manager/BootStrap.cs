using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrap : MonoBehaviour
{
    
    void Start()
    {
        LoadMainMenu();
    }


    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
