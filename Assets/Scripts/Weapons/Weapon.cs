using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    //private readonly bool collectionCheck = false;
    //private readonly int defaultCapacity = 30;
    //private readonly int maxSize = 100;
    private float timer;
    public Transform parentTransform;

    private void Start()
    {
        objectPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnBulletGet,
            OnBulletRelease,
            OnBulletDestroy,
            collectionCheck: false,
            defaultCapacity: 30,
            maxSize: 100
        );
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            Shoot();
            timer = 0;
        }
    }

    public void Shoot()
    {
        Bullet newBullet = objectPool.Get();
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.rotation = bulletSpawnPoint.rotation;
    }

    private Bullet CreateBullet()
    {
        return Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    private void OnBulletGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnBulletRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnBulletDestroy(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}

