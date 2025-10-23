using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject VFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null) player.Knockback(transform.position.x);
        Destroy(gameObject);
        Instantiate(VFX,transform.position,Quaternion.identity);
    }
}
