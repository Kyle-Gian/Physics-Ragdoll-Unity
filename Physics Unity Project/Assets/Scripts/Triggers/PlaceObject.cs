﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    GameObject player = null;
    [SerializeField]
    GameObject pickUp = null;

    [HideInInspector]
    public bool pickUpPlaced = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if (player.transform.Find("Pick Up") != null)
            {
                pickUp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                pickUp.transform.parent = this.transform;
                pickUp.transform.localPosition = new Vector3(0, 40, 0);
                pickUpPlaced = true;
            }

        }

        if (other.gameObject == pickUp)
        {
            pickUp.transform.parent = this.transform;
            pickUp.GetComponent<Rigidbody>().isKinematic = true;
            pickUpPlaced = true;

        }
    }
}