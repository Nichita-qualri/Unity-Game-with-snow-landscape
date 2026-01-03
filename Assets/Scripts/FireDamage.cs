using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
