using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    PointManager pointManager;
    BerrySpawn berrySpawn;
    Tail tail;

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
            pointManager.UpdateScore(1);

            Destroy(collision.collider.gameObject);

            tail.AddLength();

            berrySpawn.SpawnBerries();
        }

    }
}
