using UnityEngine;

public class EnemyTargeting : Enemy
{
    public Transform Player;
    public float speed = 5f;
    private Vector2 spawn;
    void RandomizeSpawnPoint()
    {
        base.Start();

        float spawnx = Random.Range(-9, 9);
        float spawny = Random.Range(-6, 6);

        transform.position = new Vector2(spawnx, spawny);
    }

    protected override void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RandomizeSpawnPoint();
    }
    private void Update()
    {
        if (Player != null)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}