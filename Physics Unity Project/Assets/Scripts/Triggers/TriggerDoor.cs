//Author Kyle Gian
//Date Created 12/3/2021
//Last Modified 6/4/2021

// If condition is met door opens using configurable joint


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField]
    PlaceObject m_placeObject;
    ConfigurableJoint m_configurableJoint = null;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<ConfigurableJoint>() != null)
        {
            m_configurableJoint = GetComponent<ConfigurableJoint>();
        }
        if (m_placeObject != null)
        {
            m_placeObject = GameObject.FindGameObjectWithTag("Floor Plate").GetComponent<PlaceObject>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        // set door target position when condition is met
        if (m_placeObject.m_pickUpPlaced == true)
        {
               m_configurableJoint.targetPosition = new Vector3(10, 0, 0);           
        }
    }
}
