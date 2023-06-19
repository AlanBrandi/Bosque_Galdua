using UnityEngine;

public class HUDHealth : MonoBehaviour
{
    public GameObject[] healthBars;
    private int currentHealth;

    void Start()
    {
        currentHealth = PlayerHealth.Instance.GetLives();
        UpdateHealthBars();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthBars();
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        UpdateHealthBars();
    }

    private void UpdateHealthBars()
    {
        for (int i = 0; i < healthBars.Length; i++)
        {
            healthBars[i].SetActive(i < currentHealth);
        }
    }
}
