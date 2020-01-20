using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_basic_death_zone : MonoBehaviour {
    public GameObject respawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}
