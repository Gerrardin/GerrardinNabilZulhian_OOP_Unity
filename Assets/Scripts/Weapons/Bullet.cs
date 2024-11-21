using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20f;
    public int damage = 10;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Logika ketika peluru bertabrakan dengan objek lain, seperti menghancurkan atau memberi damage
        // Despawn bullet back to the pool, or destroy
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
