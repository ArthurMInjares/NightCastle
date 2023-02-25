using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JumpState : MonoBehaviour, IState
{
    float turnAmount;
    float forwardAmount;
    public float aerialDrive;
    public PlayerStateController player;
    public Vector3 jumpForce;
    public bool isGrounded;
    private Vector3 camForward;
    private Vector3 move;
    Vector3 groundNormal;
    private float groundTime;
    private float groundCountDown;

    public JumpState(PlayerStateController player)
    {
        this.player = player;

    }

    private void Start()
    {
        groundTime = 0.05f;
        groundCountDown = groundTime;
    }

    public void Enter()
    {
        //Debug.Log("Enter Jump State");
        player.animator.SetBool("IsJumping", true);
        player.footstepSource.enabled = false;
        jumpForce.x = player.rb.velocity.x;
        jumpForce.z = player.rb.velocity.z;
        player.rb.AddForce(jumpForce , ForceMode.Impulse);
       
        groundCountDown = groundTime;
    }

    public void Execute()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        ApplyForce(h);

        if (Grounded())
        {
            groundCountDown -= Time.deltaTime;

            if (groundCountDown <= 0)
            {
                //Debug.Log("Ground count down expired.");
                if ((CrossPlatformInputManager.GetAxis("Horizontal") == 0))
                {
                    player.stateMachine.newState = player.idle;
                }
                else if ((CrossPlatformInputManager.GetAxis("Horizontal") != 0))
                {
                    player.stateMachine.newState = player.walk;
                }
            }
        }
        else if (player.rb.velocity.y < 0) //Plays landing animation and allows in air movement if falling
        {
            //Vector3 extraGracvityForce = (Physics.gravity * 2) - Physics.gravity;
            //player.rb.AddForce(extraGracvityForce);
            player.rb.AddForce(Physics.gravity * 4.0f, ForceMode.Acceleration);
            player.animator.SetBool("IsLanding" , true);
           
            ApplyForce(h);
        }
        else
        {
            ApplyForce(h);
            groundCountDown = groundTime;
        }

       
    }

    public void Exit()
    {
        player.animator.SetBool("IsJumping", false);
        player.animator.SetBool("IsLanding", false);
        jumpForce.x = 0;
        jumpForce.z = 0;
        player.footstepSource.enabled = true;
        //Debug.Log("Exit Jump State");

        //player.animator.applyRootMotion = false;
    }

    private bool Grounded()
    {
        if (player.rb.velocity.y == 0 || (player.rb.velocity.y <= 0.1 && player.rb.velocity.y >= -0.1) )
        {
            return true;
        }
        else if (player.rb.velocity.y != 0)
        { 
            return false;
        }
        return false;
    }

    public void ApplyForce(float x)
    {
        //Debug.Log("Applying aerial movement force: " + x);
        if (x > 0)
        {
            player.rb.AddForce(Vector3.right * (player.walk.moveSpeedMultiplier * aerialDrive * Time.deltaTime));
        }
        if (x < 0)
        {
            player.rb.AddForce(Vector3.left * (player.walk.moveSpeedMultiplier * aerialDrive * Time.deltaTime));
        }
    }
}
