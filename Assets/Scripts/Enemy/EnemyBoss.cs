using UnityEngine;

public class EnemyBoss : Enemy
{
    public Weapon bossWeapon;
    public float attackInterval = 3f;
    private float attackTimer;
    public float speed = 5f;
    private Vector2 direction;

    protected override void Start()
    {
        base.Start();
        attackTimer = attackInterval;

        float spawnSide = Random.Range(0, 2) == 0 ? -1f : 1f;
        direction = new Vector2(spawnSide, 0);

        transform.position = new Vector3(spawnSide * 10, Random.Range(-1f, 5f), 0);
        rb.velocity = direction * speed;
    }

    private void Update(){
        if (transform.position.x < -10 || transform.position.x > 10){
            direction = -direction;
            rb.velocity = direction * speed;
        }

        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Attack();
            attackTimer = attackInterval;
        }
    }

    private void Attack()
    {
        if (bossWeapon != null)
        {
            bossWeapon.Shoot();
        }
    }
}