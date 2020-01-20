using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Death_Zone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //print("Death");
        other.gameObject.SendMessage("FallToDeath",null, SendMessageOptions.DontRequireReceiver);
    }
}
