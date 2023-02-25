using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneScript : MonoBehaviour
{
    public int windForceX;
    public int windForceY;
    public int windForceZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<Rigidbody>().AddForce(windForceX, windForceY, windForceZ , ForceMode.Acceleration);
        }
    }
}
