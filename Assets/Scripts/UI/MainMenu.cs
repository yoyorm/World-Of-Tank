using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    Button DeleteBestScore;
    
    void Start()
    {
        DeleteBestScore = GameObject.Find("DeleteScore").GetComponent<Button>();
        DeleteBestScore.onClick.AddListener(() => DataManager.instance.DeleteBestScore());
    }
    

    public void OnTestClick()
    {
        
        SceneManager.LoadScene("Test");
    }

    
    public void OnBattleClick()
    {
        Debug.Log("开始游戏");
        SceneManager.LoadScene("Battle1");
    }
    void Update()
    {
        
        bestScoreText.text = "Best Score:\n" + DataManager.instance.BestScore.ToString();
        //Debug.LogWarning($"[UI] InstanceID={DataManager.instance?.GetInstanceID()}");
    }
    

}