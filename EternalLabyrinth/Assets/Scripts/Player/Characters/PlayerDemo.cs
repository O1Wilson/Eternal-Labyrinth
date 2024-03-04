using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : CharacterAblities
{

    void Start()
    {
        baseHealth = 110d;
        baseHealthRegen = 1.5d;
        baseArmor = 0d;
        baseDamage = 12d;
    }

    public override void ModifyBaseStatsBasedOnLevel()
    {
        int level = CalculateLevel();
        baseHealth += level * 33; // Increase baseHealth by 10 for each level
        baseHealthRegen += level * 1.2; // Increase baseHealthRegen by 0.2 for each level
        baseDamage += level * 2;  // Increase baseDamage by 2 for each level
    }

    private void Update()
    {
        UpdatePlayerStats();
        DemoPrimary();
        DemoSecondary();
        DemoSpecial();
        DemoUtility();
    }

    private void DemoPrimary()
    {
        // Shoot rapidly for 60% damage
    }

    private void DemoSecondary()
    {
        // Shoot through enemies for 230% damage, knocking them back
    }

    private void DemoUtility()
    {
        // Roll foward a small distance. You cannot be hit while rolling
    }

    private void DemoSpecial()
    {
        // Fire rapidly, stunning and hitting nearby enemies for 6x60% damnage
    }
}
