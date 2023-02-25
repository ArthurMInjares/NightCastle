using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAggro : MonoBehaviour
{
    public int aggroLevel = 0;
    public float timerReset = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        AggroReset();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Noisy")
        {
            Debug.Log("Message Sent");
            gameObject.SendMessage("IncreaseAggression", 1);
        }

        if (other.gameObject.tag == "Player")
        {
            this.GetComponent<AudioSource>();
        }
    }

    public void IncreaseAggression()
    {
        Debug.Log("Aggro Increased");
        aggroLevel++;
        timerReset += 5.0f;

        if (aggroLevel > 2)
        {
            aggroLevel = 2;
            return;
        }

        //Cases for the Ghost Aggro
        switch (aggroLevel)
        {
            case 1:
                Debug.Log("Searching");
            //Searching for you
                break;
            case 2:
                Debug.Log("Chasing");
            //Chasing after you
                break;
            default:
                Debug.Log("Patrolling");
            //Peacefully patrolling
                break;
        }
    }

    void AggroReset()
    {
        if (aggroLevel >= 1)
        {
            timerReset -= Time.deltaTime;
            if (timerReset < 0)
            {
                aggroLevel--;
                Debug.Log("Aggro Reset");
                return;
            }
        }
    }
}
