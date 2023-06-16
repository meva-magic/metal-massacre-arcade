using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodStain;

    PointManager pointManager;
    BerrySpawn berrySpawn;
    PauseMenu pause;

    private Shake shake;

    private void Start()
    {


        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();

        berrySpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BerrySpawn>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            shake.CamShake();
            pause.PauseGame();

            //Time.timeScale = 0;
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();
            pointManager.UpdateScore(1);

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bloodStain, transform.position, Quaternion.identity);

            Destroy(collision.collider.gameObject);

            berrySpawn.SpawnBerries();
        }

    }
}
