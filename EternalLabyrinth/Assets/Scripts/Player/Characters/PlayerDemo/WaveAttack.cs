using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    public PlayerDemo playerDemo;

    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyParent enemy = hitInfo.gameObject.GetComponent<EnemyParent>();
        if (enemy != null)
        {
            enemy.TakeDamage(playerDemo.playerDamage * playerDemo.playerDamageMultiplier);
        }

        playerDemo.bloodGauge = 0f;
        Destroy(gameObject);
    }
}
