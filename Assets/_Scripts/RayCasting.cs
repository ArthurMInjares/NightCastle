using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour { 

     public GameObject player;        


     private Vector3 offset;  

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        RayCast();
        transform.position = player.transform.position + offset;

    }

    void RayCast()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 5.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();
            TransparencyManager x = hit.transform.GetComponent<TransparencyManager>();
            

            if (x)
            {
                x.turnTransparent();
            }
        }
    }
}

