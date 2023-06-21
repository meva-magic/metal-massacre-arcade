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

    public void StartGame()
    {
        Time.timeScale = 1;
        Title.SetActive(false);
        Berry.SetActive(true);
    }

    public void GameOvered()
    {
        Time.timeScale = 0;
        Berry.SetActive(false);
        Title.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

}
