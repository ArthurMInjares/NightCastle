using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Master_Behavior : MonoBehaviour
{
    Animator masterAnim;
    GameObject player;
    ToggleGhostMode mastersToggle;
    //public static bool mastersGhostMode;
    private Camera cam;
  

    // Start is called before the first frame update
    void Start()
    {
       
        cam = Camera.main;
        masterAnim = gameObject.GetComponent<Animator>();
        mastersToggle = cam.GetComponent<ToggleGhostMode>();
        InvokeRepeating("masterToggle" , 5f , 10f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //slays the master once Dimitri reaches his platform
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            masterAnim.SetBool("IsDead" , true);
            CancelInvoke();
        }
    }

    void masterToggle()
    { 
        mastersToggle.MastersGhostMode();

    }

}
