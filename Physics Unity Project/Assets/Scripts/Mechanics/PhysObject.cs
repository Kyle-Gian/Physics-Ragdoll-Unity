using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysObject : MonoBehaviour
{
    public Material awakeMat = null;
    public Material sleepMat = null;

    private Rigidbody rb = null;

    bool wasAsleep = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsSleeping() && !wasAsleep && sleepMat != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = sleepMat;
        }

        if (!rb.IsSleeping() && wasAsleep == true && awakeMat != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMat;
        }

    }
}
