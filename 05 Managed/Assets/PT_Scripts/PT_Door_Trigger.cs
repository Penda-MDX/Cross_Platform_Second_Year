using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Door_Trigger : MonoBehaviour {

    public PT_DoorHandler myDoorHandler;
    public bool reversible = true; //is it turned off if the key exits it again
    public bool recieve = true; //is it waiting to recieve a key or have one removed

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "KeyObject")
        {
            
            if (recieve)
            {
                myDoorHandler.TriggerComplete();
            }
            else
            {
                if (reversible)
                {
                    myDoorHandler.TriggerLost();
                }
            }

            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "KeyObject")
        {
            if (recieve)
            {
                if (reversible)
                {
                    myDoorHandler.TriggerLost();
                }
            }
            else
            {
                myDoorHandler.TriggerComplete();
            }
            
        }
    }

}
