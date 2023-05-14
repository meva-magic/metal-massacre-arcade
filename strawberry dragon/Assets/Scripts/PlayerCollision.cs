using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private Shake shake;

    private void Start()
    {

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.collider.gameObject.tag == "Wall")
        {
            shake.CamShake();

            Destroy(gameObject);
        }

        if(collision.collider.gameObject.tag == "Berry")
        {   
            Destroy(collision.collider.gameObject);
        }

    }
}
