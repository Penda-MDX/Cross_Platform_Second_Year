using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimed : MonoBehaviour {
    public float LifeLengthSeconds;
    private float timeToDie;
	// Use this for initialization
	void Start () {
        timeToDie = Time.time + LifeLengthSeconds;

	}
	
	// Update is called once per frame
	void Update () {
        if (timeToDie < Time.time)
        {
            Destroy(gameObject);
        }
	}
}
