using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject objTrigger1 = null;
    [SerializeField]
    GameObject objTrigger2 = null;

    [SerializeField]
    GameObject buttonTrigger = null;

    [SerializeField]
    GameObject rocket = null;

    [SerializeField]
    Transform launchPosition1 = null;
    [SerializeField]
    Transform launchPosition2 = null;

    ParticleSystem particleSystem1 = null;
    ParticleSystem particleSystem2 = null;


    PlaceObject objPlacement1 = null;
    PlaceObject objPlacement2 = null;

    bool buttonCanBeSwitched = false;
    bool buttonSwitchedOn = false;

    int rocketsReleased = 0;


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

        particleSystem1 = launchPosition1.GetComponent<ParticleSystem>();
        particleSystem2 = launchPosition2.GetComponent<ParticleSystem>();


        particleSystem1.gameObject.SetActive(false);
        particleSystem2.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (objPlacement1 != null && objPlacement2 != null)
        {
            if (objPlacement1.pickUpPlaced && objPlacement2.pickUpPlaced)
            {
                buttonCanBeSwitched = true;

            }
        }

        if (buttonCanBeSwitched)
        {
            Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hitInfo;
            if (Physics.Raycast(rayPos, Camera.main.transform.forward, out hitInfo, 30))
            {
                if (hitInfo.collider.gameObject == buttonTrigger)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        buttonSwitchedOn = true;
                    }

                }
            }

        }

        if (buttonSwitchedOn && rocketsReleased <= 0)
        {
            rocketsReleased++;
            ReleaseTheRockets();
        }

    }

    void ReleaseTheRockets()
    {
        if (rocket != null )
        {
            Instantiate(rocket, launchPosition1.position, Quaternion.identity);
            Instantiate(rocket, launchPosition2.position, Quaternion.identity);
            launchPosition1.GetComponent<ParticleSystem>().gameObject.SetActive(true);
            launchPosition2.GetComponent<ParticleSystem>().gameObject.SetActive(true);


        }
    }
}
