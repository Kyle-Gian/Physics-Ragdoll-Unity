//Author Kyle Gian
//Date Created 10/3/2021
//Last Modified 6/4/2021

//Takes in a pick up object that needs to be placed on an object to change the shader, set object to kinematic and set postion/scale

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    GameObject m_player = null;
    [SerializeField]
    GameObject m_pickUp = null;

    Material m_objShader = null;


    [HideInInspector]
    public bool m_pickUpPlaced = false;

    bool m_dissolveShader = false;
    float m_dissolveValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        m_objShader = m_pickUp.GetComponent<Renderer>().material;
        m_objShader.SetFloat("_DissolveAmount", 0);
    }

    private void Update()
    {
        //increase the dissolve amount slowly
        if (m_dissolveShader && m_dissolveValue < 1)
        {
            m_objShader.SetFloat("_DissolveAmount", m_dissolveValue += 0.1f * Time.fixedDeltaTime);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //When object is attched to the player as child
        if (other.gameObject == m_player)
        {
            if (m_player.transform.Find("Pick Up") != null)
            {
                m_pickUp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                m_pickUp.transform.parent = this.transform;
                m_pickUp.transform.localPosition = new Vector3(0, 40, 0);
                m_pickUpPlaced = true;
            }

        }

        //If the object needs to touch the other run this code
        if (other.gameObject == m_pickUp)
        {
            m_pickUp.GetComponent<Rigidbody>().isKinematic = true;
            m_pickUpPlaced = true;
            m_dissolveShader = true;
        }
    }

}
