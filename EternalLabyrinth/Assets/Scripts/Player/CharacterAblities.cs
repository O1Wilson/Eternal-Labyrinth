using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAblities : MonoBehaviour
{
    public PlayerUI playerUI; // Reference to PlayerUI script

    //Character Stats
    public float xp;
    public int level;
    public float money;

    public double baseHealth;
    public double baseHealthRegen;
    public double baseArmor;
    public double baseDamage;

    public double CalculateHealth()
    {
        return baseHealth;
    }

    public float UpdateXP()
    {
        return xp;
    }

    public int CalculateLevel()
    {
        return Mathf.FloorToInt(Mathf.Pow(xp, 0.1f)); // Exponential scaling logic to calculate level based on XP
    }

    public virtual void ModifyBaseStatsBasedOnLevel()
    {

    }

    public void UpdatePlayerStats()
    {
        baseHealth = CalculateHealth();
        xp = UpdateXP();
        level = CalculateLevel();
        playerUI.UpdateUI(baseHealth, xp, level); // Update UI through the PlayerUI script
    }
}
