using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Spawner : MonoBehaviour {
    public int int_numberOfTimes = 3;
    public bool bl_infinite = false;
    public float fl_timeBetween = 1f;
    public GameObject go_spawnee;

    private float fl_nextTime;
    private int int_countSoFar = 0;

	// Use this for initialization
	void Start () {
        fl_nextTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //check there is a spawnee set
        if (go_spawnee != null)
        {
            //has the time between spawns passed
            if (fl_nextTime<Time.time)
            {
                //spawn if either infinite is set or the number of spawns have been not been reached
                if (bl_infinite || int_countSoFar < int_numberOfTimes)
                {
                    Instantiate(go_spawnee, transform.position, transform.rotation);
                    //update count
                    int_countSoFar++;
                    //set the next time to spawn
                    fl_nextTime = Time.time + fl_timeBetween;
                }
            }
        }
	}
}
