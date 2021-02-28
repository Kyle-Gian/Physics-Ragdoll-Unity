using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    ConfigurableJoint configurableJoint = null;

    private void Start()
    {
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

            if (CompareTag("Wall Spring"))
            {
                configurableJoint.targetPosition = new Vector3(0, 0, 40);

            }
        }
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            r.RagdollOn = true;
        }
    }
}
