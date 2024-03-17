using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : CharacterAblities
{
    [Header("PlayerDemo")]
    public float bloodGauge;
    private float bloodCapacity;
    public float playerDamageMultiplier;

    public GameObject bulletPrefab;

    private bool isDrainingBlood = false;

    void Start()
    {
        maxHealth = 110d;
        healthRegen = 1.5d;
        maxArmor = 0d;
        playerDamage = 12d;
        attackRange = 0.38f;
        attackRate = 4.5d;
        cooldownReduction = 1d;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        bloodCapacity = 100f;
    }

    public override void ModifyBaseStatsBasedOnLevel() // Overides the method in parent class
    {
        int level = CalculateLevel();
        if (level > priorLevel)
        {
            maxHealth += level * 33; // Increase baseHealth by X for each level
            currentHealth += level * 33; // Adjusts the currentHealth for level up
            healthRegen += level * 1.2; // Increase baseHealthRegen by X for each level
            healthBar.SetMaxHealth(maxHealth); // Adjusts Healthbar

            priorLevel = level; // Ensures the function doesnt run infinitely
        }
    }

    private void Update()
    {
        ModifyBaseStatsBasedOnLevel();
        UpdatePlayerStats();

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DemoPrimary();
            }
        }
        
        if (Time.time >= secondaryCooldown)
        {
            if (Input.GetMouseButtonDown(1))
            {
                playerDamageMultiplier = Mathf.Lerp(1f, 10f, bloodGauge / bloodCapacity); // Sets dmg mult right before attack is triggered
                DemoSecondary();
            }
        }

        if (Time.time >= utilityCooldown)
        {
            if (bloodGauge > 0f)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (isDrainingBlood)
                    {
                        StopCoroutine(DrainBlood());
                        damageImmune = false;
                        isDrainingBlood = false;
                        utilityCooldown = Time.time + 6d / cooldownReduction;
                    }
                    else
                    {
                        StartCoroutine(DrainBlood());
                    }
                }
            }     
        }

        if(Time.time >= specialCooldown)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                DemoSpecial();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // TESTING FEATURE REMOVE SOON
        {
            TakeDamage(20d);
        }
    }

    private void DemoPrimary()
    {
        anim.SetTrigger("isAttacking");

        // Detects enemies inside range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<EnemyParent>().TakeDamage(playerDamage * 1.25f); // Applies damage to enemies
        }
            
        nextAttackTime = Time.time + 1d / attackRate; // adds a 1 second cooldown to attack which is reduced by attack speed
    }

    private void DemoSecondary()
    {
        //anim.SetTrigger("secondary");

        float minScaleFactor = 0.5f; // Minimum scale for the Wave Projectile
        float maxScaleFactor = 2.0f; // Maximum scale for the Wave Projectile

        float scaledFactor = Mathf.Lerp(minScaleFactor, maxScaleFactor, (playerDamageMultiplier - 1) / 9f);

        GameObject Obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Instantiates the Wave Attack
            Transform bulletTransform = Obj.transform;
            Vector3 scale = Vector3.one * scaledFactor * 0.6f; // Multiplies the Scale by the scaledFactor
            bulletTransform.localScale = scale; // Applies the scaling

        Obj.GetComponent<WaveAttack>().playerDemo = this; // Sets Obj from Wave Attack Script

        secondaryCooldown = Time.time + 3d / cooldownReduction; // Adds a three second cooldown which can be reduced by cooldown reduction
    }

    private IEnumerator DrainBlood()
    {
        isDrainingBlood = true; // Sets bool to determine if coroutine is running
        damageImmune = true; // Makes player immune to damage

        // Continuously drain blood while gauge is greater than 0
        while (bloodGauge > 0f && isDrainingBlood)
        {
            // Drain the bloodGauge by x units per second
            bloodGauge -= 16.67f * Time.deltaTime;
            yield return null;
        }

        // Ensures bloodGauage doesn't go below 0
        bloodGauge = Mathf.Max(0f, bloodGauge);

        // Set damageImmune back to false when bloodGauge is depleted
        damageImmune = false;
        isDrainingBlood = false;

        utilityCooldown = Time.time + 6d / cooldownReduction; // adds a three second cooldown which can be reduced by cooldown reduction
    }

    private void DemoSpecial()
    {

    }

    public void BloodOrbs(float blood)
    {
        if (bloodGauge < bloodCapacity)
        {
            bloodGauge += blood;

            playerDamageMultiplier = Mathf.Lerp(1f, 10f, bloodGauge / bloodCapacity); // Linear scaling dmg mult based on bloodGauge fill%

            if (bloodGauge > bloodCapacity) // Logic to cap bloodGauge
            {
                bloodGauge = bloodCapacity; // Ensures bloodGauge does not exceed capacity
            }
        }
    }
}
