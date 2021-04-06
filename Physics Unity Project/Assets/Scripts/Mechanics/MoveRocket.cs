//Author Kyle Gian
//Date Created 22/3/2021
//Last Modified 22/3/2021


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
    //float DestroyAtDistance = 70f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(-speed, 0, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Detonate();
        StartCoroutine("DestroyRocket");
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
    IEnumerator DestroyRocket()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
