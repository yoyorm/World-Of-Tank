
using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private int bestScore;
    public int BestScore{get=>bestScore;private set=>bestScore=value;}
    public static DataManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
        GameState.onPlayerDeath+=SaveBestScore;
        
        LoadBestScore();
    }
    
    public void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", BestScore);
    }

    private void LoadBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SetBestScore(int val)
    {
        BestScore = val;
    }

    private void OnDestroy()
    {
        GameState.onPlayerDeath-=SaveBestScore;
    }

    public void DeleteBestScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
        BestScore = 0;
        
        Debug.Log("删除得分");
        //Debug.LogError($"[DELETE] InstanceID={GetInstanceID()}, bestScore={bestScore}, 场景={gameObject.scene.name}");
    }
}
