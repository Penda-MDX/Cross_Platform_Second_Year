using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Basic_Animation_StateChange : MonoBehaviour {

    private Animator ar_animator;

	// Use this for initialization
	void Start () {
        ar_animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("R"))
        {
            // get a reference to the animator on this gameObject


            ar_animator.SetTrigger("Running");
        }
        else
        {
            ar_animator.SetTrigger("NotRunning");
        }
	}
}
