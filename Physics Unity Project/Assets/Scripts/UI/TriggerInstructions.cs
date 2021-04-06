//Author Kyle Gian
//Date Created 17/3/2021
//Last Modified 18/3/2021

//Triggers a canvas with instructions when player enters collider

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInstructions : MonoBehaviour
{
    [SerializeField]
    Canvas canvas = null;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(false);

        }
    }
}
