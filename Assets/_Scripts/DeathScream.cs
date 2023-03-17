using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScream : MonoBehaviour {

    public AudioSource ScreamDeath;
    public GameObject Dimitri;
    public GameObject DeathCam;

    void OnTriggerEnter () {
        ScreamDeath.Play ();
        DeathCam.SetActive (true);
        Dimitri.SetActive (true);
        StartCoroutine (EndJump ());
    }

    IEnumerator EndJump() {
        yield return new WaitForSeconds (2.5f);
        Dimitri.SetActive (true);
        DeathCam.SetActive(false);
    }
}
