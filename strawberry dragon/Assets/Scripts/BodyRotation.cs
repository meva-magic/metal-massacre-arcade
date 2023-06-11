using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{

    public float speed;

    private Vector2 direction;
    public Transform target;

    //bool facingRigth = true;


    void Update()
    {

        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    }

   /* 
        if (!facingRigth && direction.x > 0)
        {
            Flip();
        }

   void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.y *= -1;
        gameObject.transform.localScale = currentScale;

        facingRigth = !facingRigth;
    }
    */
}
