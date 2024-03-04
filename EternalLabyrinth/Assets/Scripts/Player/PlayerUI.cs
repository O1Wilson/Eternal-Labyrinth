using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;

    public void UpdateUI(double baseHealth, float xp, int level)
    {
        healthText.text = "" + baseHealth.ToString();
        xpText.text = "" + xp.ToString();
        levelText.text = "" + level.ToString();
    }
}
