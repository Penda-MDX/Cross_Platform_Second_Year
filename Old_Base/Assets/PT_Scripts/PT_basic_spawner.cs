using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_basic_spawner : MonoBehaviour {

    public float fl_time_between_spawn = 1.0f;
    public GameObject GO_thing_to_spawn;

    private float fl_next_spawn_time;


    // Use this for initialization
    void Start () {
        fl_next_spawn_time = Time.time + fl_time_between_spawn;
	}
	
	// Update is called once per frame
	void Update () {
        // is it past time for spawning
        if (Time.time>fl_next_spawn_time)
        {
            Spawn();
        }
	}

    //user defined function for handling spawning
    void Spawn()
    {
        Instantiate(GO_thing_to_spawn, transform.position, transform.rotation);

        //set next time
        fl_next_spawn_time = Time.time + fl_time_between_spawn;
    }
}
