using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour {

    public AudioSource Scream;
    public GameObject Dimitri;
    public GameObject JumpCam;
    public GameObject Flashing;

    void OnTriggerEnter () {
        Scream.Play ();
        JumpCam.SetActive (true);
        Dimitri.SetActive (false);
        Flashing.SetActive (true);
        StartCoroutine (EndJump ());
    }

    IEnumerator EndJump() {
        yield return new WaitForSeconds (3.03f);
        Dimitri.SetActive (true);
        JumpCam.SetActive(false);
        Flashing.SetActive (false);
    }
}



