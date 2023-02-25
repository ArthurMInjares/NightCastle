using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadFall : MonoBehaviour
{
     Scene scene;
     public static bool checkpoint = false;
     GameObject point;
     GameObject player;
    PlayerStateController PSC;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
        PSC = player.GetComponent<PlayerStateController>();
        point = GameObject.FindGameObjectWithTag("CheckPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(scene);
    }

    void OnTriggerEnter(Collider other)
    {
        // addd check for player 
        if (other.gameObject.CompareTag("Player"))
        {
            PSC.stateMachine.newState = PSC.dead;

            Invoke("Spawn", 3f);
        }
    }

    void Spawn()
    {
        if (checkpoint == false)
        {
            SceneManager.LoadScene(scene.name);
            PSC.stateMachine.newState = PSC.idle;
        }
        else
        {
            player.transform.position = point.transform.position;
            PSC.stateMachine.newState = PSC.idle;
        }
    }
}
