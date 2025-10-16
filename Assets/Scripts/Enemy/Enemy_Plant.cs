using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Plant : Enemy
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;   
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCooldown = 2f;
    private float shootTimer;

    protected override void Start()
    {
        base.Start();
        shootTimer = 0;
    }
    protected override void Update()
    {
        base.Update();
        if (isDead) return; 

        shootTimer -= Time.deltaTime;

        if (isPlayerDetected && shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("attack");
        if (bulletPrefab != null && shootPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            if (rbBullet != null)
            {
                rbBullet.velocity = new Vector2(facingDir * 5f, 0);
            }
            Destroy(bullet, 8f);
        }

    }
    protected override void HandleAnimator()
    {
        
    }
}
