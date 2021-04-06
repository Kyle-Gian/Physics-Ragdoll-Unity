//Author Kyle Gian
//Date Created 10/3/2021
//Last Modified 6/4/2021

//Controls the camera movement based off the players position. Allows for moouse movement to rotate around player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject player = null;
    Camera cam = null;
    [SerializeField]
    Vector3 camPos = new Vector3();

    [SerializeField]
    float Y_ANGLE_MIN = 120.0f;
    [SerializeField]
    float Y_ANGLE_MAX = -80.0f;

    [SerializeField]
    float distance = 5.0f;

    float currentX = 0.0f;
    float currentY = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    //// Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        //Clamp the values to stop clipping
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        
   }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, - distance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        cam.transform.position = player.transform.position + rotation * dir;

        cam.transform.LookAt(player.transform.position + camPos);
    }

}
