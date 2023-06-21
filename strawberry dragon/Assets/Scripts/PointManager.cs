using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public TMP_Text scoreText;

    public int score;
    
    void Start()
    {
        scoreText.text = "" + score;
        //finalScoreText.text = "" + score;
        //highScoreText.text = "" + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "" + score;
    }

    public void highScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }

        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        finalScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

}
