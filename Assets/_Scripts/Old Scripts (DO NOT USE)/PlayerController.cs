//DO NOT USE! OLD DEMO CODE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float range = 5.0f;
    public float moveSpeed = 0.5f;
    public float jumpForce = 10;
    public bool climbing;
    public Rigidbody rb;
    public Animator animator;
    public float heightFactor = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        climbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Climb();
    }

    private void Climb()
    {
        if ((climbing == true && Input.GetKey(KeyCode.D)) || (climbing == true && Input.GetKey(KeyCode.A)) ||
            (climbing == true && Input.GetKey(KeyCode.RightArrow) || (climbing == true && Input.GetKey(KeyCode.LeftArrow))))
        {
            rb.useGravity = false;
            transform.position += Vector3.up / heightFactor;
        }
        if (climbing == true && Input.GetKey(KeyCode.S))
        {
           rb.useGravity = true;
           transform.position += Vector3.down / heightFactor;
        }
        else
        {
           rb.useGravity = true;
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Climbable")
        {
            climbing = true;
        }
    }

    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Climbable")
        {
            climbing = !climbing;
        }
    }


    public void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(new Vector3(-moveSpeed, 0, 0), ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.D )|| Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(new Vector3(moveSpeed, 0, 0), ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(new Vector3(0, 0, moveSpeed), ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(new Vector3(0, 0, -moveSpeed), ForceMode.VelocityChange);
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

   

    void OnCollisionEnter(Collision col)
    {
        // change player name for the name of your players game object
        if (col.gameObject.name == "Enemy")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("DemoScene");
        }
    }
}

