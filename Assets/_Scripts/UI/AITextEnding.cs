using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AITextEnding : MonoBehaviour
{
 public GameObject EndingText1;
 public GameObject EndingText2;
 


 public GameObject Background;



 void OnTriggerEnter(Collider other)
 {
    
     if (other.CompareTag("Player"))
     {
      EndingText2.SetActive(true); 
      EndingText1.SetActive(true);
      Background.SetActive(true);
	 }
 }

 void OnTriggerExit(Collider other)
 {
      EndingText2.SetActive(false);
      EndingText1.SetActive(false);
      Background.SetActive(false);
 }
}
