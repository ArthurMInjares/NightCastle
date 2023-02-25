using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Ghostmode : MonoBehaviour
{
    Renderer rend;
    Collider Bcollider;
  
    
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        Bcollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if(ToggleGhostMode.ghostMode == true )
        {
            TurnSolid();
        }
        else
        {
            turnTransparent();
        }
    }

    public void turnTransparent()
    {

        rend.material.shader = Shader.Find("Transparent/Diffuse");
        Color tempColor = rend.material.color;
        tempColor.a = 0.3F;
        rend.material.color = tempColor;
        Bcollider.isTrigger = true;

    }

    public void TurnSolid()
    {
        rend.material.shader = Shader.Find("Transparent/Diffuse");
        Color tempColor = rend.material.color;
        tempColor.a = 1.0F;
        rend.material.color = tempColor;
        Bcollider.isTrigger = false;
    }
}
