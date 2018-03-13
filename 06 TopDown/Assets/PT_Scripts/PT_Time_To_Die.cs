using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Time_To_Die : MonoBehaviour {
    public float secondToDeath = 3f;
    public float variationInSpan = 0f;

    private float timeOfDeath;
	// Use this for initialization
	void Start () {
        float randomNumber = 0;
        if (variationInSpan < 0)
        {
            Random.Range(variationInSpan, 0);
        }
        else
        {
            Random.Range(0,variationInSpan);
        }
        timeOfDeath = Time.time + secondToDeath + randomNumber;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > timeOfDeath)
        {
            Destroy(gameObject);
        }
	}
}
