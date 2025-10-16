using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishpoint : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            animator.SetTrigger("activate");
            Debug.Log("Winner");
            UIManager.Instance.CompleteLevel();
        }
    }
}
