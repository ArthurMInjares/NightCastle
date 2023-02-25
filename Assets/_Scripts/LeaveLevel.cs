using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLevel : MonoBehaviour
{
    public bool canLeave;

    // Update is called once per frame
    void Update()
    {
        canLeave = AquireItem.aquired;
    }
    void OnTriggerStay(Collider itemCollider)
    {
        if (canLeave && (Input.GetKeyDown(KeyCode.E)))
        {
            SceneManager.LoadScene("CreditScene");
            AquireItem.aquired = false;
        }
    }
}
