using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostModeTutorial : MonoBehaviour
{
   public GameObject GMTutorial;
   public GameObject txtBackground;

   void OnTriggerStay (Collider other)
   {
   if (other.CompareTag("Player"))
   {
       GMTutorial.SetActive(true);
       txtBackground.SetActive(true);
   }
   
   }

   void OnTriggerExit (Collider other)
   {
       GMTutorial.SetActive(false);
       txtBackground.SetActive(false);
   }
}
