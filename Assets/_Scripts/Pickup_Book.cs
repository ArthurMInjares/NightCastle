using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Book : MonoBehaviour
{
    //public AudioSource pickupSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Destroy(this);
            //pickupSound.Play();
            //send message to level event manager that book has been picked up.
        }
    }
}
