using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void PauseGame()
    {

        Time.timeScale = 0;
        
    }

    void ResumeGame()
    {

        Time.timeScale = 1;
        
    }
}
