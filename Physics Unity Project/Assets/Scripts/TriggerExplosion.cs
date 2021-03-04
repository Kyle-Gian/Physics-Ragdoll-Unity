using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject objTrigger1 = null;
    [SerializeField]
    GameObject objTrigger2 = null;

    PlaceObject objPlacement1 = null;
    PlaceObject objPlacement2 = null;

    // Start is called before the first frame update
    void Start()
    {
        if (objTrigger1 != null)
        {
            objPlacement1 = objTrigger1.GetComponent<PlaceObject>();

        }
        if (objTrigger2 != null)
        {
            objPlacement2 = objTrigger2.GetComponent<PlaceObject>();

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (objPlacement1 != null && objPlacement2 != null)
        {
            if (objPlacement1.pickUpPlaced && objPlacement2.pickUpPlaced)
            {

            }
        }
  
    }
}
