using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    private HealthComponent health;
    private void Awake()
    {
        if (healthComponent == null)
        {
            healthComponent = GetComponent<HealthComponent>();
        }
    }

    public void Damage(int damage)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
        if (invincibility == null && !invincibility.IsInvincible())
        {
            health.Subtract(damage);
        }

        healthComponent.Subtract(damage);
    }

    public void Damage(Bullet bullet)
    {
        Damage(bullet.damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            Damage(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}