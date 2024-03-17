using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : EnemyParent
{
    void Start()
    {
        heldXP = 15f;
        bloodStored = 15f;
        maxHealth = 110d;
        maxArmor = 0d;
        enemyDamage = 12d;
        attackRange = 0.38f;
        currentHealth = maxHealth;
    }

    public override void TakeDamage(double damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("isHurt");

        if (currentHealth <= 0)
        {
            EnemyKilled();
        }
    }

    public override void EnemyKilled()
    {
        if (FindObjectOfType<PlayerDemo>() != null)
        {
            FindObjectOfType<PlayerDemo>().GetComponent<PlayerDemo>().BloodOrbs(bloodStored);
        }

        anim.SetBool("isDead", true);
        FindObjectOfType<CharacterAblities>().GetComponent<CharacterAblities>().UpdateXP(heldXP);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
