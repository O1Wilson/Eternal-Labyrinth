using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAblities : MonoBehaviour
{
    public PlayerUI playerUI, healthBar; // Reference to PlayerUI script
    public Animator anim;

    public Transform attackPoint;
    public Transform firePoint;
    public LayerMask enemyLayers;

    [Header("Cooldowns")]
    public double secondaryCooldown;
    public double utilityCooldown;
    public double specialCooldown;
    public double cooldownReduction;
    public double nextAttackTime;
    public double attackRate;

    [Header("Experience")]
    public float xp;
    public int level;
    public int priorLevel;
    public float money;

    [Header("Player Stats")]
    public double maxHealth;
    public double healthRegen;
    public double maxArmor;
    public double playerDamage;
    public float attackRange;

    [Header("Current Stats")]
    public bool damageImmune = false;
    public double currentHealth;
    public double currentArmor;

    public virtual void ModifyBaseStatsBasedOnLevel()
    {
        // Create Player Scaling inside Player Class
    }

    public void UpdateXP(float droppedXP)
    {
        xp += droppedXP;
    }

    public void TakeDamage(double damage)
    {
        if (!damageImmune)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }
    }

    public int CalculateLevel()
    {
        return Mathf.FloorToInt(Mathf.Pow(xp, 0.1f)); // Exponential scaling logic to calculate level based on XP
    }

    public void UpdatePlayerStats()
    {
        level = CalculateLevel();
        playerUI.UpdateUI(currentHealth, maxHealth, xp, level, damageImmune); // Update UI through the PlayerUI script
    }

    void OnDrawGizmosSelected() // TESTING FEATURE REMOVE
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
