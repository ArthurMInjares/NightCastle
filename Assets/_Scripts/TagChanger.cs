using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChanger : MonoBehaviour
{
    public float timerReset = 0.0f;


    void Start()
    {
        this.gameObject.tag = "Silent";
    }


    void Update()
    {
        TagReset();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Message Sent");
            gameObject.SendMessage("TagSwitch");
        }

    }

    public void TagSwitch()
    {
        if (this.gameObject.tag == "Silent")
        {
            this.gameObject.transform.tag = "Noisy";
            timerReset += 5.0f;
        }
    }

    public void TagReset()
    {
        if (this.gameObject.tag == "Noisy")
        {
           timerReset -= Time.deltaTime;
           if (timerReset < 0)
           {
               this.gameObject.transform.tag = "Silent";
           }
        }
    }
}
