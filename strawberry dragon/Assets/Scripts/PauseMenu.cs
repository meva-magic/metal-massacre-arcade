using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject Pause;
    public GameObject Title;
    public GameObject Berry;
    public GameObject GameOver;


    void Start()
    {
        Time.timeScale = 0;
        Title.SetActive(true);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Title.SetActive(false);
        Pause.SetActive(true);        
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
        GameOver.SetActive(false);
        Berry.SetActive(true);
        isPaused = false;  
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        Title.SetActive(false);
        Berry.SetActive(true);
        isPaused = false;
    }

    public void GameOvered()
    {
        Time.timeScale = 0;
        Berry.SetActive(false);
        GameOver.SetActive(true);
        isPaused = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
