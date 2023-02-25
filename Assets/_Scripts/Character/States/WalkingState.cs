using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WalkingState : MonoBehaviour, IState
{
    
    public  bool isGrounded;
    float turnAmount;
    float forwardAmount;
    public float moveSpeedMultiplier;
    public float moveForceModifier;
    Vector3 groundNormal;
    private Vector3 camForward;             // The current forward direction of the camera
    public Vector3 move;
    float movingTurnSpeed;
    float stationaryTurnSpeed;

    public PlayerStateController player;

    private void Start()
    {
        movingTurnSpeed = 540;
        stationaryTurnSpeed = 360;
        moveSpeedMultiplier = 1f;
    }

    public WalkingState(PlayerStateController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        //Debug.Log("Enter Walking State");
        player.animator.SetBool("IsWalking", true);
        player.animator.applyRootMotion = false;
        player.jump.isGrounded = true;
    }

    public void Execute()
    {
        //Debug.Log("Execute walking state.");
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (h == 0 && v == 0)
        {
            player.stateMachine.newState = player.idle;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.stateMachine.newState = player.jump;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeedMultiplier = 2;
            player.animator.speed = moveSpeedMultiplier;
            player.animator.SetBool("IsRunning" , true);
        }
        else
        {
            moveSpeedMultiplier = 1;
            player.animator.speed = moveSpeedMultiplier;
            player.animator.SetBool("IsRunning", false);
        }

        //Plays landing animation and allows in air movement if falling from walking state.
        if (player.rb.velocity.y < 0 || player.rb.velocity.y > 0)
        {
            player.rb.AddForce(Physics.gravity * 4.0f, ForceMode.Acceleration);
            player.animator.SetBool("IsRunning", false);
            player.animator.SetBool("IsWalking", false);
            player.animator.SetBool("IsLanding", true);
            player.footstepSource.enabled = false;
            ApplyForce(h);
        }
        else
        {
            player.animator.SetBool("IsWalking", true);
            player.footstepSource.enabled = true;
        }

        // calculate move direction to pass to character
        if (player.cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(player.cam.forward, new Vector3(1, 0, 1)).normalized;
            camForward = Vector3.Scale(player.cam.forward, new Vector3(1, 0, 1)).normalized;
            move = v * camForward + h * player.cam.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = v * Vector3.forward + h * Vector3.right;
        }
        
        // pass all parameters to the character control script
        Move(move , h);
    }

    public void Move(Vector3 move , float x)
    {
        if (move.magnitude >= 1f)
        {
            move.Normalize();
        }
        move = player.transform.InverseTransformDirection(move);
       

        move = Vector3.ProjectOnPlane(move, groundNormal);
        turnAmount = Mathf.Atan2(move.x, move.z);
        forwardAmount = move.z;

        ApplyExtraTurnRotation();
        ApplyForce(x);
    }

    void ApplyExtraTurnRotation()
    {
        float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
        player.transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }

    public void ApplyForce(float x)
    {
        if (x > 0)
        {
            player.rb.AddForce(Vector3.right * (moveSpeedMultiplier * moveForceModifier * Time.deltaTime));
        }
        if (x < 0)
        {
            player.rb.AddForce(Vector3.left * (moveSpeedMultiplier * moveForceModifier * Time.deltaTime) );
        }
    }


    public void Exit()
    {
        player.animator.SetBool("IsWalking", false);
        player.rb.velocity.Set(0, 0, 0);
    }
}