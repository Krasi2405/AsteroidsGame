using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    [SerializeField]
    private Text currentScoreText;

    [SerializeField]
    private Text highScoreText;

    private string HIGHSCORE_KEY = "highscore";

	void Start () {
        Score score = FindObjectOfType<Score>();


        if (score)
        {
            SetHighscore(score.GetScore());
            currentScoreText.text += score.GetScore().ToString();
        }
        else
        {
            currentScoreText.text += "none";
        }

        highScoreText.text += GetHighscore().ToString();

        Destroy(score.gameObject);
	}

    void SetHighscore(int currentScore)
    {
        int highscore = GetHighscore();
        if(currentScore > highscore)
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, currentScore);
        }
    }

    int GetHighscore()
    {
        if(PlayerPrefs.HasKey(HIGHSCORE_KEY))
        {
            return PlayerPrefs.GetInt(HIGHSCORE_KEY);
        }
        else
        {
            return 0;
        }
    }
}
