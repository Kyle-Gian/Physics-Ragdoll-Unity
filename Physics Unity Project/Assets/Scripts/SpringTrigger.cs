using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringTrigger : MonoBehaviour
{

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

    }
}
