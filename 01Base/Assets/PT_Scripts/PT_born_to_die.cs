using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_born_to_die : MonoBehaviour {

    public float fl_life_seconds = 1;
	// Use this for initialization
	void Start () {

        Destroy(this, fl_life_seconds);
  	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
