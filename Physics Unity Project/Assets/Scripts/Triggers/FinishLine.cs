using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    GameObject finishLine = null;

    // Start is called before the first frame update
    void Start()
    {
        if (finishLine == null)
        {
            finishLine = GameObject.FindGameObjectWithTag("Finish Line");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            GameTimer.timerFinished = true;
        }
    }

}
