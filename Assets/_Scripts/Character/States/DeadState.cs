using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DeadState : MonoBehaviour, IState
{
    public PlayerStateController player;
    //public AudioSource DeathSound;
    public bool isGrounded;

    public DeadState(PlayerStateController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        ////DeathSound.Play();
        ////Debug.Log("Enter Dead State");
        //if (player.rb.velocity.y == 0)
        //{
        //    player.animator.SetBool("IsDead", true);
        //}
        //else if (player.rb.velocity.y < 0)
        //{
            player.animator.SetBool("IsFalling", true);
            player.animator.SetBool("IsDead", true);
        //}
    }

    public void Execute()
    {
        //Debug.Log("Execute Dead State");
        //Does nothing
        
    }

    public void Exit()
    {
        //Debug.Log("Exit Dead State");
        player.animator.SetBool("IsDead", false);
        player.animator.SetBool("IsFalling", false);
    }
}

