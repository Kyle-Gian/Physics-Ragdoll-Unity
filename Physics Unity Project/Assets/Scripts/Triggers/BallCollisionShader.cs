//Author Kyle Gian
//Date Created 6/4/2021
//Last Modified 6/4/2021

//Used to create the ball flare on collision of player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionShader : MonoBehaviour
{
    Material m_material = null;
    // Start is called before the first frame update
    void Start()
    {
        m_material = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_material.SetFloat("_RimPower", 1);

        }

    }
    private void OnTriggerExit(Collider other)
    {
        m_material.SetFloat("_RimPower", 8);
    }
}
