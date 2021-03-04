using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    Rigidbody rb = null;
    [SerializeField]
    public float speed = 10;

    [SerializeField]
    float radius = 40;
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
        rb.AddForce(-speed, 0, 0);

    }
    private void FixedUpdate()
    {

        DestroyRocket();

    }

    private void OnCollisionEnter(Collision collision)
    {
        Detonate();

    }

    private void DestroyRocket()
    {
        if (this.transform.position.z >= DestroyAtDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void Detonate()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (var hit in colliders)
        {
            Rigidbody otherRb = GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                otherRb.AddExplosionForce(1000, this.transform.position, radius, 100, ForceMode.Impulse);

            }


        }
    }
}
