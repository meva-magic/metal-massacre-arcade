using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    public int score;


    public TMP_Text scoreText;
    
    void Start()
    {
        scoreText.text = "" + score;
    }


    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "" + score;
    }

}
