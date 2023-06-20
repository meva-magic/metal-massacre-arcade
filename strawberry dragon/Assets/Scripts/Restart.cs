using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    PauseMenu pause;

    private void Start()
    {
        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();
    }

    public void RestartButton()
    {
        pause.RestartGame();
    }
}
