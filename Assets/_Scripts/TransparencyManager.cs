using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyManager : MonoBehaviour
{
    public bool inWay = false;
    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            rend.material.shader = Shader.Find("Transparent/Diffuse");
            Color tempColor = rend.material.color;
            tempColor.a = 1.0F;
            rend.material.color = tempColor;
        
    }

    public void turnTransparent()
    {
       
            rend.material.shader = Shader.Find("Transparent/Diffuse");
            Color tempColor = rend.material.color;
            tempColor.a = 0.3F;
            rend.material.color = tempColor;

    }
}
