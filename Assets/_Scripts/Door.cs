using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    public GameObject NextLeveltxt;

 void OnTriggerEnter (Collider other)
  {
      if (other.CompareTag("Player"))
      {
       NextLeveltxt.SetActive(true);
	  }
  }


  void OnTriggerStay(Collider itemCollider)
    {


        if (Input.GetKeyDown(KeyCode.E))
        {   	
	
		//Switches scene when E Button is pressed next to door
		SceneManager.LoadScene("Kitchen");

        }


    }
        
    
}
