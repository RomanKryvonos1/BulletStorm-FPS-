using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    bool isGrounded;

    Vector3 velocity;

    public CharacterController controller;

    public Transform groundCheck;

    public LayerMask groundMask;

    public float groundDistance = 0.4f;
    public float speed;//12
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
