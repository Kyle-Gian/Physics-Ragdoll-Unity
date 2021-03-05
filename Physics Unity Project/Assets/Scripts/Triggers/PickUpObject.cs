﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    GameObject player = null;
    Vector3 pos = new Vector3(200,200,0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hitInfo;
        if (Physics.Raycast(rayPos,Camera.main.transform.forward, out hitInfo, 30))
        {
            if (hitInfo.collider.gameObject == this.gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.transform.parent = player.transform;
                    this.transform.localPosition = new Vector3(0.2f, 1, 0);
                    this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                }

            }
        }
    }
}