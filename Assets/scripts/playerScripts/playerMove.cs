using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public int maxHealth;
    int currentHealth;

    //Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;
    public float force;

    void Start()
    {
        //animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;


        rigidbody2d.MovePosition(position);




    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        projectile proj = projectileObject.GetComponent<projectile>();
        proj.Launch(lookDirection, force);


       // animator.SetTrigger("Launch");



    }

   

    public void ChangeHealth(int healthChange)
    {
        currentHealth -= healthChange;
    }
}
