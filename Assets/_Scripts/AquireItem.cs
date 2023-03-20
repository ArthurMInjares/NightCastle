using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AquireItem : MonoBehaviour
{

    
    public GameObject FindBookObjectiveTxt;
    public GameObject ExitTask;
    public GameObject EndingGhostTxt;
    public GameObject NextLevelTrigger;
    public GameObject EndingGhostTxt2;
    public GameObject EndingGhostTxt3;
    public GameObject EndingGhostTxt4;
    public GameObject EndingGhostTxt5;

    public static bool aquired = false;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider itemCollider)
    {
        
            aquired = true;
            Destroy(gameObject);

            
            FindBookObjectiveTxt.SetActive(false);
            ExitTask.SetActive(true);

            EndingGhostTxt2.SetActive(false);
            EndingGhostTxt3.SetActive(false);
            EndingGhostTxt4.SetActive(true);
            EndingGhostTxt5.SetActive(true); 
            EndingGhostTxt.SetActive(true);
            NextLevelTrigger.SetActive(true);
            
        
    }
}
