using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Change_Colour : MonoBehaviour {

    public Material startMaterial;
    public Material endMaterial;
    public bool hasChanged = false;

    private Renderer _Renderer;
    
    // Use this for initialization
    void Start()
    {
        _Renderer = gameObject.GetComponent<Renderer>();
        _Renderer.material = startMaterial;
    
    }

    void OnTriggerEnter(Collider other)
    {
        //if the colour has not already changed 
        if (!hasChanged)
        {
            //change it
            _Renderer.material = endMaterial;
            hasChanged = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        //if the colour has not already changed 
        if (hasChanged)
        {
            //change it
            _Renderer.material = startMaterial;
            hasChanged = false;
        }
    }
}
