using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    GameObject pickUp = null;
    GameObject player = null;

    float mousePosX, mousePosY;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.FindGameObjectWithTag("Weight");
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Debug.DrawRay(Camera.main.transform.position, Input.mousePosition.normalized);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 30))
        {
            if (hitInfo.collider.gameObject == pickUp)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pickUp.transform.parent = player.transform;
                    pickUp.transform.localPosition = new Vector3(0.2f, 1, 0);
                    pickUp.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

                }

            }
        }
    }
}
