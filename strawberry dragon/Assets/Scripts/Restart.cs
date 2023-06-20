using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    PauseMenu pause;

    private void Start()
    {
        Time.timeScale = 1;

        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();
    }

    public void StartButton()
    {
        Title.SetActive(false);
        pause.ResumeGame();
        Berry.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
        pause.ResumeGame();
    }

    public void ExitButton()
    {
        Title.SetActive(true);
        pause.PauseGame();
    }
}
