using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Animator animator => GetComponent<Animator>();
    private bool active;

    [SerializeField] private bool canBeReactivated;

    private void Start()
    {
        canBeReactivated = GameManager.Instance.canReactivate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && canBeReactivated == false) return;

        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            ActivateCheckpoint();
        }
    }
    private void ActivateCheckpoint()
    {
        active = true;
        animator.SetTrigger("activate");
        GameManager.Instance.UpdateRespawnPosition(transform);
    }
}
