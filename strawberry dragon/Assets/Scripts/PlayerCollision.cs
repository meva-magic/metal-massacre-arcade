using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodStain;
    public GameObject bigBloodStain;
    
    public LeaderBoard leaderBoard;
    public GameObject Title;
    public GameObject Berry;

    PointManager pointManager;
    BerrySpawn berrySpawn;
    PauseMenu pause;
    HealthBar healthbar;

    private Shake shake;

    private void Start()
    {
        leaderBoard = GameObject.FindGameObjectWithTag("Leader").GetComponent<LeaderBoard>();

        pointManager = GameObject.FindGameObjectWithTag("Point").GetComponent<PointManager>();

        berrySpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BerrySpawn>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();

        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            shake.CamShake();
            GameOvered();
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(1);
            Destroy(collision.collider.gameObject);

            berrySpawn.SpawnBerries();
            healthbar.DropTimer();

        }

        if(collision.collider.gameObject.tag == "BigBerry")
        {   
            shake.CamShake();
            //healthbar.DropTimer();

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bigBloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(5);
            Destroy(collision.collider.gameObject);
            
            berrySpawn.SpawnBerries();
        }
    }

    public void GameOvered()
    {
        Time.timeScale = 0;
        Berry.SetActive(false);
        Title.SetActive(true);
        StartCoroutine(DieRoutine());
        SceneManager.LoadScene("SampleScene");
    }

    public IEnumerator DieRoutine()
    {
        yield return leaderBoard.SubmitScoreRoutine(pointManager.score);
    }
}
