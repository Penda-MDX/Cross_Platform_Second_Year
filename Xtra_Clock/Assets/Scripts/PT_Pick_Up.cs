using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Pick_Up : MonoBehaviour {

    //[SerializeField]
    private bool canPickUp = false;
    private GameObject movableObject;
    private GameObject carriedObject;

    private bool carryingObject = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("e"))
        {
            if (carryingObject)
            {
                carryingObject = false;
                carriedObject.transform.SetParent(null);
            }
            else
            {
                if (canPickUp)
                {
                    carryingObject = true;
                    movableObject.transform.SetParent(gameObject.transform);
                    carriedObject = movableObject;
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Movable")
        {
            canPickUp = true;
            movableObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Movable")
        {
            canPickUp = false;
            movableObject = null;
        }
    }
}
