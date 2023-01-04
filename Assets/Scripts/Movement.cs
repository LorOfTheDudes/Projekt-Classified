 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed;
    static float startSpeed = 12f;
    float prevSpeed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck; 
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isSneaked;
    
    void Start()
    {
        speed = startSpeed;
    }

    void Update()
    {
        if (Input.GetButtonDown("Sprint") )
        {
            speed = speed * 1.5f;
        }
        else if (Input.GetButtonUp("Sprint")) 
        {
            speed = speed/1.5f;
        }

        

        if (Input.GetButtonDown("Sneak") && isSneaked == false)
        {
            transform.localScale = new Vector3(1f, 0.5f, 1f);
            speed = speed / 2;
            isSneaked = true;
        }   
        if (Input.GetButtonUp("Sneak"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            speed = speed*2;
            isSneaked = false;
            
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
