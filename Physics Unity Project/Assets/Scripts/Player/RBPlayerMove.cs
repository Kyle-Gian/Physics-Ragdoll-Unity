using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBPlayerMove : MonoBehaviour
{
    //Rigidbody rb = null;
    CharacterController controller = null;
    Animator animator = null;

    public float speed = 80.0f;
    public float pushPower = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float MouseX = Input.GetAxis("Mouse X");

        //controller.SimpleMove(transform.up * Time.fixedDeltaTime);

        //rb.AddForce(transform.up * speed * Time.fixedDeltaTime);
        
        animator.SetFloat("Ypos", vertical * speed * Time.fixedDeltaTime);
        animator.SetFloat("Xpos", horizontal * speed * Time.fixedDeltaTime);

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        //move = Vector3.ClampMagnitude(move, 1f);

        controller.SimpleMove(move * speed * Time.fixedDeltaTime);
        transform.Rotate(0, MouseX, 0);
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
