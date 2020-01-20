using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Trigger : MonoBehaviour {
    public bool bl_enable;
    public GameObject objectToActivate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (bl_enable)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                objectToActivate.SetActive(false);
            }
            
        }
    }
}
