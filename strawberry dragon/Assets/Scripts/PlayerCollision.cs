using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject effect;
    public GameObject bloodStain;
    public GameObject bigBloodStain;

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
            Instantiate(bloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(1);
            Destroy(collision.collider.gameObject);

            berrySpawn.SpawnBerries();

        }

        if(collision.collider.gameObject.tag == "BigBerry")
        {   
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bigBloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(5);
            Destroy(collision.collider.gameObject);
            
            berrySpawn.SpawnBerries();
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
