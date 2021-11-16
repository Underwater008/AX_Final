using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidDoor : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Open", true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("Open", false);
        }

    }





}
