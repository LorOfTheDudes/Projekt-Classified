using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int Number;
    public int horizontal;
    public int vertical;
    // Start is called before the first frame update
    void Start()
    {
        SayHello();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        
        if (Input.GetKeyDown("left"))
        {
            int horizontal = -1;

        }
        if (Input.GetKeyDown("right"))
        {
            int horizontal = 1;
        }
        transform.Translate(new Vector3(horizontal, 0, vertical));
    }
    public void SayHello()
    {
        Debug.Log("Welcome to this Programm.");
        Debug.Log("Please referr to your common sense for the controls:)");
        Debug.Log(Number);
    }
}
