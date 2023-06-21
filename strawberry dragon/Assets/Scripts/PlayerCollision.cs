using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject[] bloodStains;

    PointManager pointManager;
    BerrySpawn berrySpawn;
    PauseMenu pause;

    private Shake shake;

    private void Start()
    {

        pointManager = GameObject.FindGameObjectWithTag("Point").GetComponent<PointManager>();

        berrySpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<BerrySpawn>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        pause = GameObject.FindGameObjectWithTag("Finish").GetComponent<PauseMenu>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            shake.CamShake();
            pause.GameOvered();
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            pointManager.UpdateScore(1);
            berrySpawn.SpawnBerries();

            Destroy(collision.collider.gameObject);

            for ( int i = 0; i < 10000000; i++)
            {    
                var spawn = Random.Range(0, 2);
                Instantiate(bloodStains[i], transform.position, Quaternion.identity);
            }


        }

        if(collision.collider.gameObject.tag == "BigBerry")
        {   
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            pointManager.UpdateScore(5);
            berrySpawn.SpawnBerries();

            Destroy(collision.collider.gameObject);

            for ( int i = 0; i < 10000000; i++)
            {    
                var spawn = Random.Range(0, 2);
                Instantiate(bloodStains[i], transform.position, Quaternion.identity);
            }

        }

/*
        void DestroyObjects(string tag)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
        }
*/
    }
}
