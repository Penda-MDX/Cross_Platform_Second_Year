using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Pull : MonoBehaviour {

    public float pullRange = 2;
    //public
    private bool isPulling = false;
    private GameObject objPulled;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            if (objPulled)
            {
                if (!isPulling)
                {
                    objPulled.GetComponent<Rigidbody2D>().isKinematic = true;
                    objPulled.transform.parent = transform;
                    isPulling = true;
                }
                else
                {
                    objPulled.transform.parent = null;
                    objPulled.GetComponent<Rigidbody2D>().isKinematic = false;
                    isPulling = false;
                }
            }
        }

	}

    //private void OnTriggerEnter2D(Collider2D collision)
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "KeyObject")
        {
            objPulled = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "KeyObject")
        {
            if(objPulled = collision.gameObject)
            {
                objPulled = null;
            }
        }
    }


}
