using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    GameObject player = null;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        startPos = player.transform.position;
    }

    void SpawnPlayer()
    {
        player.transform.position = startPos;
    }

}
