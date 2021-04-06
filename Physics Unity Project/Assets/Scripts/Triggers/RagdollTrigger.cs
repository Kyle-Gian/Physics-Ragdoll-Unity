//Author Kyle Gian
//Date Created 15/2/2021
//Last Modified 6/4/2021

// Gets the players ragdoll component when there is a colision and resets the player to start position after set time
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    ConfigurableJoint m_configurableJoint = null;

    PlayerRespawn m_playerRespawn = null;

    private void Start()
    {
        m_playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        if (GetComponent<ConfigurableJoint>() != null)
        {
            m_configurableJoint = GetComponent<ConfigurableJoint>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_configurableJoint != null)
        {
            if (CompareTag("Floor Spring"))
            {
                m_configurableJoint.targetPosition = new Vector3(0, 40, 0);
            }
        }
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            StartCoroutine("ResetPlayer");

            r.RagdollOn = true;
        }
    }

    IEnumerator ResetPlayer()
    {
        // Restart scene after 2 seconds
        yield return new WaitForSeconds(2f);
        m_playerRespawn.ReloadScene();

    }
}
