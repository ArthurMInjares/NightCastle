using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel1 : MonoBehaviour
{

    public GameObject exitText;

    public GameObject background;

    public bool canLeave;

    void Update()
    {
        canLeave = AquireItem.aquired;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitText.SetActive(true);
            background.SetActive(true);

            if (canLeave == true && Input.GetKeyDown(KeyCode.Return))
            {
                DeadFall.checkpoint = false; 
                SceneManager.LoadScene(4);
                AquireItem.aquired = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitText.SetActive(false);
            background.SetActive(false);
        }
    }
}
