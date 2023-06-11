using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodStain;

    PointManager pointManager;
    BerrySpawn berrySpawn;
    Tail tail;
    PauseMenu pauseMenu;

    private Shake shake;

    private void Start()
    {


        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();

        berrySpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BerrySpawn>();

        tail = GameObject.FindGameObjectWithTag("Tail").GetComponent<Tail>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            shake.CamShake();
            Time.timeScale = 0;
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();
            pointManager.UpdateScore(1);

            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bloodStain, transform.position, Quaternion.identity);

            Destroy(collision.collider.gameObject);

            tail.AddLength();

            berrySpawn.SpawnBerries();
        }

    }
}
