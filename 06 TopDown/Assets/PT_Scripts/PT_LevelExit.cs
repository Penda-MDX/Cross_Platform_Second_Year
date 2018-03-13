using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_LevelExit : MonoBehaviour {
    public PT_Level_Data myLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myLevel.Exit_Level();
        }
    }
}
