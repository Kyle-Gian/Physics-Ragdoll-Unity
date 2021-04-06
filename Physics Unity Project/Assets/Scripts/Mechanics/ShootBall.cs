//Author Kyle Gian
//Date Created 20/3/2021
//Last Modified 6/4/2021

// Gets a location based off a object position and spawns bullet prefab in a direction

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
