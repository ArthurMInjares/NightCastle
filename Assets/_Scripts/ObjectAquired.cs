using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAquired : MonoBehaviour
{
    public bool hasObject;

    bool hasPlayed = false;

    public AudioSource pickupSound;
    void Update()
    {
       hasObject = AquireItem.aquired;
        if (AquireItem.aquired == true && !hasPlayed)
        {
            pickupSound.Play();
            hasPlayed = true;
        }
    }
}
