//Author Kyle Gian
//Date Created 15/2/2021
//Last Modified 6/4/2021

// Gets the players ragdoll component when there is a colision and resets the player to start position after set time
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    PlayerRespawn m_playerRespawn = null;
    Player m_playerMovement = null;

    private void Start()
    {
        m_playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        m_playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            StartCoroutine("ResetPlayer");
            m_playerMovement.m_playerCanMove = false;
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
