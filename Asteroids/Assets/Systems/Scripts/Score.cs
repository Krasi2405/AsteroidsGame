using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {


    [SerializeField] // Only for debug
    private int currentScore = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public int GetScore()
    {
        return currentScore;
    }
}
