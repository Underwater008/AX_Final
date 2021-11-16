using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public int enemyDamager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the object is the player
        playerMove playerRef = collision.gameObject.GetComponent<playerMove>();
        if (playerRef != null)
        {
            playerRef.ChangeHealth(enemyDamager);
        }
    }
}
