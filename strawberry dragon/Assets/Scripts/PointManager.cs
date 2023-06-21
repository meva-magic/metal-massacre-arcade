using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI inputScore;

    [SerializeField]
    public TMP_InputField inputName;

    public UnityEvent<string, int> SubmitScoreEvent;

    public TMP_Text finalScoreText;
    public TMP_Text scoreText;

    public int score;
    
    void Start()
    {
        scoreText.text = "" + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "" + score;
    }

    public void SubmitScore()
    {
        SubmitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
        //finalScoreText.text = "" + score;
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
        //highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
