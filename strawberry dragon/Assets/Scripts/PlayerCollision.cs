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
            pause.GameOvered();
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            //Instantiate(bloodStain, transform.position, Quaternion.identity);
            for ( int i = 0; i < 10000000; i++)
            {    
                var spawn = Random.Range(0, bloodStains.Count);
                Instantiate(bloodStains[i], transform.position, Quaternion.identity);
            }

            pointManager.UpdateScore(1);
            DestroyObjects("Berry");
            berrySpawn.SpawnBerries();
        }

        if(collision.collider.gameObject.tag == "BigBerry")
        {   
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(bloodStain, transform.position, Quaternion.identity);

            pointManager.UpdateScore(5);
            DestroyObjects("BigBerry");
            berrySpawn.SpawnBerries();
        }

        void DestroyObjects(string tag)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
        }
    }
}
