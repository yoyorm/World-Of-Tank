using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score: MonoBehaviour
{
    public static Score instance;
    [SerializeField]
    private int _score;
    public int score { get=>_score;set=>_score=value; }

    
    void Awake()
    {
        if (instance == null)
        {
            instance =this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        score = 0;
    }

    public void AddScore(int val)
    {
        Debug.Log("分数加"+val);
        score += val;
        if (score >= PlayerPrefs.GetInt("BestScore"))
        {
            DataManager.instance.SetBestScore(score);
        }
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log("重置分数");
    }
}
