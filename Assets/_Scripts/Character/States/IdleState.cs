using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class IdleState : MonoBehaviour, IState
{
    public PlayerStateController player;
    public bool isGrounded;
    

    public IdleState(PlayerStateController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        //Debug.Log("Enter Idle State");
        player.animator.SetBool("IsIdle" , true);
        player.jump.isGrounded = true;
    }

    public void Execute()
    {
        //Debug.Log("Execute Idle State");

        //transitions from idle to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Calling jummp from idle");
            player.stateMachine.newState = player.jump;
        }
        else if ((CrossPlatformInputManager.GetAxis("Horizontal") != 0) || (CrossPlatformInputManager.GetAxis("Vertical") != 0))
        {
            player.stateMachine.newState = player.walk;
        }

        //Plays landing animation and allows in air movement if falling from idle state.
        if (player.rb.velocity.y < 0 || player.rb.velocity.y > 0)
        {
            player.animator.SetBool("IsIdle", false);
            //player.animator.SetBool("IsLanding", true);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            player.rb.AddForce(Physics.gravity * 4.0f, ForceMode.Acceleration);
            player.walk.ApplyForce(h);
            player.footstepSource.enabled = false;
        }
        else
        {
            player.animator.SetBool("IsIdle", true);
            player.footstepSource.enabled = true;
        }
    }

    public void Exit()
    {
        //Debug.Log("Exit Idle State");
        player.animator.SetBool("IsIdle", false);
        player.rb.velocity = Vector3.zero;
    }
}

