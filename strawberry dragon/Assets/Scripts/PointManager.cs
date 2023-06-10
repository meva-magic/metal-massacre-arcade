using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{

    public int score;
    public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "" + score;
    }

}
