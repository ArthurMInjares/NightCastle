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
            EndingGhostTxt.SetActive(true);
            NextLevelTrigger.SetActive(true);
        
    }
}
