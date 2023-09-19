using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_DoorHandler : MonoBehaviour {

    public GameObject doorToOpen;
    public int numberOfTriggers;

    public int countTriggered = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countTriggered >= numberOfTriggers)
        {
            doorToOpen.SetActive(false);
        }
        else
        {
            doorToOpen.SetActive(true);
        }
	}

    public void TriggerComplete()
    {
        countTriggered++;
    }

    public void TriggerLost()
    {
        countTriggered--;
    }


}
