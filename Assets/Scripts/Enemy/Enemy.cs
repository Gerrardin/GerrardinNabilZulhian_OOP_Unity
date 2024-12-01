using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Level;
    public EnemySpawner enemySpawner;
    [SerializeField] public CombatManager combatManager;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnDestroy()
    {
        if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.onDeath();
            combatManager.onDeath();

        }
    }

    protected virtual void Start()
    {
        // Logika dasar untuk Enemy
    }
}
