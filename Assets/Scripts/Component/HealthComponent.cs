using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;
    private void Awake()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Subtract(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
//            totalKill++;
        }
    }
}