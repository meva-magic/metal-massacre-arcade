using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject Pause;

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
        Pause.SetActive(true);
        isPaused = true;
        
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        Pause.SetActive(false);
        isPaused = false;
        
    }
}
