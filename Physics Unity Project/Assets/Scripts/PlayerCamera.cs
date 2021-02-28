using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    GameObject player = null;
    Camera cam = null;

    [SerializeField]
    float Y_ANGLE_MIN = 120.0f;
    [SerializeField]
    float Y_ANGLE_MAX = -80.0f;

    [SerializeField]
    float distance = 5.0f;
    [SerializeField]
    float sensitivityX = 4.0f;
    [SerializeField]
    float sensitivityY = 1.0f;

    float currentX = 0.0f;
    float currentY = 0.0f;

    public Transform obstruction = null;
    float zoomSpeed = 2.0f;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    //// Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        

    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, - distance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        cam.transform.position = player.transform.position + rotation * dir;

        cam.transform.LookAt(player.transform.position);
        ViewObstructed();
    }

    void ViewObstructed()
    {

        if (Physics.Raycast(transform.position, player.transform.position, out RaycastHit info, 4.5f))
        {

            if (info.collider.gameObject.tag != "Player")
            {
                obstruction = info.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if (Vector3.Distance(obstruction.position, transform.position) >=1f && Vector3.Distance(transform.position, player.transform.position) >= 0.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            if (Vector3.Distance(transform.position, player.transform .position) < 4.5f)
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);

            }

        }
    }
}
