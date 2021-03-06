﻿//Author Kyle Gian
//Date Created 16/3/2021
//Last Modified 16/3/2021

//stores the start position of the player and uses it as a start position, reloads scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    public void SpawnPlayer()
    {
        Ragdoll r = this.gameObject.GetComponentInParent<Ragdoll>();
        r.RagdollOn = false;
        if (this.transform.position != startPos)
        {
            this.transform.position = startPos;

        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
