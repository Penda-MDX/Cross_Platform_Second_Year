using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Basic_Move : MonoBehaviour {//start of class definition

    //public variable of type float - decimal mumber 
    public float fl_MovementSpeed = 1;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //When you press M the item moves up
        if(Input.GetKeyUp("k"))
        {
            transform.Translate(0, fl_MovementSpeed, 0);
        }

        if (Input.GetKeyUp("m"))
        {
            transform.Translate(0, -fl_MovementSpeed, 0);
        }


    }


}//end of class definition


