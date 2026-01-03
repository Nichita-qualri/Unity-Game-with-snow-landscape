using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Image[] hearts;
    public GameOverManager gameOverManager;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHearts();

        if (currentHealth == 0)
        {
            Debug.Log("Player is dead!");
            gameOverManager.ShowGameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }
}
