//Author Kyle Gian
//Date Created 27/3/2021
//Last Modified 29/3/2021

// Used for the players movement and the animations speed with movement


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller = null;
    Animator animator = null;

    public float speed = 3.0f;
    public float pushPower = 2.0f;
    [HideInInspector]
    public bool m_playerCanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerCanMove)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            float MouseX = Input.GetAxis("Mouse X");

            //set the animator variables
            animator.SetFloat("Ypos", vertical);
            animator.SetFloat("Xpos", horizontal);
            animator.SetFloat("Speed", speed * Time.deltaTime);

            //movement
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            move = Vector3.ClampMagnitude(move, 1f);
            controller.Move(move * speed * Time.deltaTime);
            transform.Rotate(0, MouseX, 0);
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }
        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDirection * pushPower;
    }
}
