using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;

    public Slider slider;
    public CharacterAblities characterAblities;

    public void SetMaxHealth(double health)
    {
        slider.maxValue = (float)health; // Sets the max amount of slider
        slider.value = (float)health; // Sets slider to max value on start
    }
    public void SetHealth(double health)
    {
        slider.value = (float)health; // Sets slider to current health
    }

    public void UpdateUI(double currentHealth, double maxHealth, float xp, int level, bool damageImmune)
    {
        if(damageImmune == true)
        {
            healthText.text = "Immune";
        }
        else
        {
            healthText.text = "" + currentHealth.ToString() + " / " + maxHealth.ToString();
        }

        xpText.text = "" + xp.ToString();
        levelText.text = "lvl " + level.ToString();
    }
}