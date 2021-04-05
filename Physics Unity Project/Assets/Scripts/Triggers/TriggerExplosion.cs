using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject m_objTrigger1 = null;
    [SerializeField]
    GameObject m_objTrigger2 = null;


    [SerializeField]
    GameObject m_buttonTrigger = null;

    [SerializeField]
    GameObject m_rocket = null;

    [SerializeField]
    Transform m_launchPosition1 = null;
    [SerializeField]
    Transform m_launchPosition2 = null;

    ParticleSystem m_particleSystem1 = null;
    ParticleSystem m_particleSystem2 = null;


    PlaceObject m_objPlacement1 = null;
    PlaceObject m_objPlacement2 = null;

    bool m_buttonCanBeSwitched = false;
    bool m_buttonSwitchedOn = false;

    int m_rocketsReleased = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (m_objTrigger1 != null)
        {
            m_objPlacement1 = m_objTrigger1.GetComponent<PlaceObject>();
        }
        if (m_objTrigger2 != null)
        {
            m_objPlacement2 = m_objTrigger2.GetComponent<PlaceObject>();
        }

        m_particleSystem1 = m_launchPosition1.GetComponent<ParticleSystem>();
        m_particleSystem2 = m_launchPosition2.GetComponent<ParticleSystem>();
        m_particleSystem1.gameObject.SetActive(false);
        m_particleSystem2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (m_objPlacement1 != null && m_objPlacement2 != null)
        {
            if (m_objPlacement1.pickUpPlaced && m_objPlacement2.pickUpPlaced)
            {
                m_buttonCanBeSwitched = true;

            }
        }

        if (m_buttonCanBeSwitched)
        {
            Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(rayPos, Camera.main.transform.forward, out hitInfo, 30))
                {
                    if (hitInfo.collider.gameObject == m_buttonTrigger)
                    {

                        m_buttonSwitchedOn = true;
                    }
                }
            }
        }

        if (m_buttonSwitchedOn && m_rocketsReleased <= 0)
        {
            m_rocketsReleased++;
            ReleaseTheRockets();
        }

    }

    void ReleaseTheRockets()
    {
        if (m_rocket != null)
        {
            Instantiate(m_rocket, m_launchPosition1.position, Quaternion.identity);
            Instantiate(m_rocket, m_launchPosition2.position, Quaternion.identity);
            m_launchPosition1.GetComponent<ParticleSystem>().gameObject.SetActive(true);
            m_launchPosition2.GetComponent<ParticleSystem>().gameObject.SetActive(true);


        }
    }
}
