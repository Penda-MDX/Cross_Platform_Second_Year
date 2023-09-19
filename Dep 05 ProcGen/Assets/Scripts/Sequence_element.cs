using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_element : MonoBehaviour
{


    public Material baseMatter;
    public Material activatedMatter;
    public Material clickedMatter;
    public float changeCoolDown;

    private float restTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restTime < Time.time)
        {
            ChangeMaterial(baseMatter);
        }

    }
 
    void OnMouseDown()
    {
        SetClicked();
    }

    public void SetActive()
    {
        ChangeMaterial(activatedMatter);
    }

    public void SetClicked()
    {
        ChangeMaterial(clickedMatter);
    }

    void ChangeMaterial(Material newMaterial)
    {
        gameObject.GetComponent<Renderer>().material = newMaterial;
        if (newMaterial != baseMatter)
        {
            restTime = Time.time + changeCoolDown;
        }
    }
}
