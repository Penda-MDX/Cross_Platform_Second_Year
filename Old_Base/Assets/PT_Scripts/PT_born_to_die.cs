using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_born_to_die : MonoBehaviour {

    public float fl_life_seconds = 1;
	// Use this for initialization
	void Start () {

        
        Destroy(gameObject, fl_life_seconds);
       //Debug.Log("Go");
  	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
