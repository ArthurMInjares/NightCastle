using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIText : MonoBehaviour
{

   public GameObject AIMessage1;
   public GameObject AIMessage2;
   public GameObject InteractTxt;
   public GameObject TxtBackground;
   public GameObject InteractImage;
   public float TxtNumb = 0f;
   
 

  void OnTriggerEnter (Collider other)
  {
      TxtNumb = 0f;
      if (other.CompareTag("Player"))
      {
       InteractImage.SetActive(true);
	  }
   }

   void OnTriggerStay(Collider other)
   {
       if (Input.GetKeyDown(KeyCode.R))
       {
       
       TxtNumb = TxtNumb + 1;

     


         if (TxtNumb == 1f)
        {
         InteractImage.SetActive(false);
         InteractTxt.SetActive(true);
         TxtBackground.SetActive(true);
         AIMessage1.SetActive(true);
        }

         if (TxtNumb == 2f)
        {
         InteractImage.SetActive(false);
         InteractTxt.SetActive(true);
         TxtBackground.SetActive(true);
         AIMessage1.SetActive(false);
         AIMessage2.SetActive(true);
        }
//======================================Closes Text==================================================================
           if (TxtNumb == 3f)
        {
           InteractImage.SetActive(true);
         InteractTxt.SetActive(false);
         TxtBackground.SetActive(false);
         AIMessage1.SetActive(false);
         AIMessage2.SetActive(false);

         TxtNumb = 0f;
        }


	   }
   }


  void OnTriggerExit(Collider other)
  {

      if (other.CompareTag("Player"))
      {
        InteractImage.SetActive(false);
         InteractTxt.SetActive(false);
         TxtBackground.SetActive(false);
         AIMessage1.SetActive(false);
         AIMessage2.SetActive(false);
	  }

  }
}
