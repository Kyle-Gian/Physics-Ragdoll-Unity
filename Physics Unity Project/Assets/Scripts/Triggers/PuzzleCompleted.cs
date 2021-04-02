using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleted : MonoBehaviour
{

    PuzzleScript m_puzzleScript = null;

    [SerializeField]
    ParticleSystem m_fireWorks = null;

    [SerializeField]
    ConfigurableJoint m_doorJoint = null;
    // Start is called before the first frame update
    void Start()
    {
        m_puzzleScript = GetComponent<PuzzleScript>();

        if (m_fireWorks != null)
        {
           m_fireWorks.Pause();
        }
        else
        {
            Debug.Log("Particle system not attached!!");
        }

        if (m_doorJoint == null)
        {
            Debug.Log("Door joint not attached!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_puzzleScript.CheckMatchingColors())
        {
            if (m_fireWorks != null && m_doorJoint != null)
            {
                m_fireWorks.Play();
                m_doorJoint.targetPosition = new Vector3(10, 0, 0);
            }
        }
        
    }
}
