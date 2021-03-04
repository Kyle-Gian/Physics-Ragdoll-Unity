using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    PlaceObject placeObject;
    ConfigurableJoint configurableJoint = null;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<ConfigurableJoint>() != null)
        {
            configurableJoint = GetComponent<ConfigurableJoint>();
        }

        placeObject = GameObject.FindGameObjectWithTag("Floor Plate").GetComponent<PlaceObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (placeObject.pickUpPlaced == true)
        {
               configurableJoint.targetPosition = new Vector3(10, 0, 0);           
        }
    }
}
