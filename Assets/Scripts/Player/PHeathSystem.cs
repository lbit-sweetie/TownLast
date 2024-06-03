using UnityEngine;
using UnityEngine.UI;

public class PHeathSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20;
    [SerializeField] private float currentHealth;
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(float amount = 1)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void ChangeHealthAmount(float amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Death()
    {
        Debug.Log("You Dead!!!");
    }
}