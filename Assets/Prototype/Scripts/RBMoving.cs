//PROTOTYPE CODE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RBMoving : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float jumpForce = 10;
    public Rigidbody rb;
    public static bool ghostMode = false;
    int i = 0;



    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    void Update()
    {
        Move();
    }


    public void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(new Vector3(-moveSpeed, 0, 0), ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.VelocityChange);
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}

  