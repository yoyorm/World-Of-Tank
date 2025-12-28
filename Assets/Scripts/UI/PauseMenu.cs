using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseMenu;
    public GameObject deathText;
    public Camera deathCamera;
    public bool pause = false;
    public bool death = false;
    void Start()
    {
        instance = this;
        
        GameState.onPlayerDeath += OnPlayerDeath;
    }

    private void Awake()
    {
        pauseMenu.SetActive(false);
        deathText.SetActive(false);
    }

    void OnDestroy()
    {
        GameState.onPlayerDeath -= OnPlayerDeath;
    }

    public void OnPause()
    {
        Debug.Log("游戏暂停");
        pause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OffPause()
    {
        Debug.Log("游戏继续");
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void OnPlayerDeath()
    {
        pause = true;
        death = true;
        pauseMenu.SetActive(true);
        deathText.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Instantiate(deathCamera);
    }
}
