using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class ToggleGhostMode : MonoBehaviour
{
    public static bool ghostMode = false;
    int i = 0;
    //public float ghostModeTimer = 10.0f;
    private Camera cam;
    //public static PostProcessingProfile PPSGhostMode;

    public AudioSource ghostSound;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cam.GetComponent<PostProcessingBehaviour>().enabled = false;
        //This ine may seem redundant, but it's to make sure ghostMode is off when you respawn
        ghostMode = false;
        //PPSGhostMode = cam.GetComponent<PostProcessingProfile>();//.enabled = false; 

    }

    // Update is called once per frame
    void Update()
    {
        GhostMode();
    }

    public void GhostMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            i++;
            if (i % 2 == 1)
            {
                ghostMode = true;
                cam.GetComponent<PostProcessingBehaviour>().enabled = true;
                ghostSound.Play();
            }
            else if (i % 2 == 0)
            {
                ghostMode = false;
                cam.GetComponent<PostProcessingBehaviour>().enabled = false;
                //ghostSound.Play();
            }
        }
    }


    public void MastersGhostMode()
    {
            i++;
            if (i % 2 == 1)
            {
                ghostMode = true;
                cam.GetComponent<PostProcessingBehaviour>().enabled = true;
                ghostSound.Play();
            }
            else if (i % 2 == 0)
            {
                ghostMode = false;
                cam.GetComponent<PostProcessingBehaviour>().enabled = false;
                //ghostSound.Play();
            }
    }

    //public void ghostModeOn()
    //{
    //    ghostMode = true;
    //    cam.GetComponent<PostProcessingBehaviour>().enabled = true;
    //    ghostSound.Play();
    //}


    //public void ghostModeOff()
    //{
    //    ghostMode = false;
    //    cam.GetComponent<PostProcessingBehaviour>().enabled = false;
    //}


    //public IEnumerator GhostModeToggle()
    //{
    //    if (ghostMode == false)
    //    {
    //        ghostModeOn();
    //        /*if (ghostMode == true)
    //        {
    //            ghostModeTimer -= Time.deltaTime;
    //            if (ghostModeTimer < 0)
    //            {
    //                ghostModeTimer = 10.0f;
    //            }
    //        }*/
    //        yield return new WaitForSeconds(10);
    //        ghostModeOff();
    //    }
    //    else
    //    {
    //        ghostModeOff();
    //    }
    //}







}



