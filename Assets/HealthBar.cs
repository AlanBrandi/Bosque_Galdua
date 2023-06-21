using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BossScript bossHealth;
    public Image healthBarFill;

    private void Update()
    {
       // float fillAmount = bossHealth.BosscurrentHealth / 100;
       // healthBarFill.fillAmount = fillAmount;
    }
}