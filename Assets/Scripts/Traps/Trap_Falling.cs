using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Falling : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float speed = 2f;
    private bool activate;
    private Animator animator;
   
    private Vector3 initPosition;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        initPosition = transform.position;
    }

    private void Update()
    {
        MovePosition();
        Animator();
    }

    private void MovePosition()
    {
        if (activate == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, initPosition, speed * Time.deltaTime);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, finalPosition, speed * Time.deltaTime);
    }

    private void Animator()
    {
        if(transform.position == initPosition)
        {
            animator.SetBool("activate", false);
        }
        else
        {
            animator.SetBool("activate", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            activate = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            activate = false;
        }
    }
}
