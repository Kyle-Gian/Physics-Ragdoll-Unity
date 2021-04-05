using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    ConfigurableJoint configurableJoint = null;

    PlayerRespawn playerRespawn = null;

    private void Start()
    {
        playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        if (GetComponent<ConfigurableJoint>() != null)
        {
            configurableJoint = GetComponent<ConfigurableJoint>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (configurableJoint != null)
        {
            if (CompareTag("Floor Spring"))
            {
                configurableJoint.targetPosition = new Vector3(0, 40, 0);
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
        yield return new WaitForSeconds(2f);
        playerRespawn.ReloadScene();

    }
}
