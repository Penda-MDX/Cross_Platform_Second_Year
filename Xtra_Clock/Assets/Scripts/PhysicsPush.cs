using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPush : MonoBehaviour {

    public Vector3 forcePush;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {

          PushSomething(gameObject.GetComponent<Rigidbody>(), forcePush);
        }
    }

    public void PushSomething(Rigidbody thingy, Vector3 forceDirection)
    {
        thingy.AddForce(forceDirection);
    }
}
