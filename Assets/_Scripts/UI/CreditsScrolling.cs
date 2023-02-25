using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScrolling : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hyfjtgfj");
        //Object moves up at a constant rate
        transform.position = transform.position + (transform.up * speed * Time.deltaTime);
    }
}
