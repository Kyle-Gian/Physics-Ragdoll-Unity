using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootBall : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab = null;

    [SerializeField]
    float SpawnStart = 1f;
    [SerializeField]
    float SpawnTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullets", SpawnStart, SpawnTimer);

    }

    void SpawnBullets()
    {
        Instantiate(bulletPrefab, this.transform.position, new Quaternion());

    }
}
