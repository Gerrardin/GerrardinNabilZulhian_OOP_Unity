using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject) return;

        HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            InvincibilityComponent invincibility = collision.GetComponent<InvincibilityComponent>();
            if (invincibility != null && !invincibility.IsInvincible())
            {
                invincibility.ActivateInvincibility();
            }
        }
    }
}