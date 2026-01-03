using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    [Header("Hearts UI")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHearts();

        if (currentHealth == 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            hearts[i].enabled = true;
        }
    }

    void Die()
    {
        Debug.Log("Игрок умер!");
    }
}
