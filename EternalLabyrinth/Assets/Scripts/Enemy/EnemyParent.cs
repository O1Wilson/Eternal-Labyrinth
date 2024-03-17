using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    public Animator anim;

    // Stats to be Overridden
    public double maxHealth;
    public double maxArmor;
    public double enemyDamage;
    public float attackRange;
    public float heldXP;
    public float bloodStored;

    // Stats that fluxuate
    public double currentHealth;
    public double currentArmor;

    public virtual void TakeDamage(double damage)
    {
        // Apply damage
        // Play Animation
        // Determine if EnemyKilled
    }

    public virtual void EnemyKilled()
    {
        // Die animation
        // Disable the enemy
    }
}
