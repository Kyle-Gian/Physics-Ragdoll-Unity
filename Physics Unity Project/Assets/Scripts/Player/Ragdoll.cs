//Author Kyle Gian
//Date Created 6/3/2021
//Last Modified 6/3/2021

//Used to control the player's ragdoll and animation when collided with

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    private Animator animator = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public bool RagdollOn
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;
            foreach (Rigidbody r in rigidbodies)
            {
                r.isKinematic = !value;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        foreach (Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
        }

    }

}
