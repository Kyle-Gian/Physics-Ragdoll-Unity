using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletMove : MonoBehaviour
{
    Rigidbody rb = null;
    [SerializeField]
    public float speed = 50;

    [SerializeField]
    float DestroyAtDistance = 70;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, speed);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (this.transform.position.z >= DestroyAtDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
