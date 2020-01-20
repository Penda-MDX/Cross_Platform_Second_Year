using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_GrabCheck : MonoBehaviour
{
    public bool canGrab;
    public Rigidbody grabableRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Swingable")
        {
            canGrab = true;
            grabableRB = other.gameObject.GetComponent<Rigidbody>();
            if (grabableRB == null)
            {
                canGrab = false;
            }
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Swingable")
        {
            canGrab = false;
            grabableRB = null;
        }
    }
}
