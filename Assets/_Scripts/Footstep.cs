using System.Collections;
using UnityEngine;

public class Footstep : MonoBehaviour
{

    WalkingState characterController;
    public AudioSource characterControllerAudio;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = GetComponent<WalkingState>();
        characterControllerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(characterController.isGrounded == true &&  player.GetComponent<Rigidbody>().velocity.magnitude > 2f && characterControllerAudio.isPlaying == false)
        {
            Step();
        }
    }

    void Step()
    {
        characterControllerAudio.volume = Random.Range(0.8f, 1);
        characterControllerAudio.pitch = Random.Range(0.8f, 1.1f);
        characterControllerAudio.Play();
    }
}
