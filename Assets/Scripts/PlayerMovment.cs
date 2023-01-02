using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9f;
    public Transform GroundCheck;
    public float groundDistance = 0.1f;
    public float jumpHeight = 3f;
    public LayerMask groundMask; 

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        doDebug();
    }


    void Update()
    {
       

        isGrounded = Physics.CheckBox(GroundCheck.position, new Vector3(0, 0.5f, 0), Quaternion.Euler(new Vector3(0,0,0)), groundMask);
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.2f;
        }

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime );
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity* Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void doDebug()
    {
        Debug.Log("test");
    }
}
