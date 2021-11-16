using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    //float timer = 5.0f;
   // bool isLaunched;

    void Awake()
    {

        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        
        if(transform.position.magnitude> 300.0f)
        {
            Destroy(gameObject);
        }

        

    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);




    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);




    }
}

