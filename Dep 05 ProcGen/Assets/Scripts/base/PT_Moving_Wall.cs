using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Moving_Wall : MonoBehaviour {
    private PT_Level_Data levelDataManager;
	// Use this for initialization
	void Start () {
        GameObject lvlMan = GameObject.Find("Level_Data");
        levelDataManager = lvlMan.GetComponent<PT_Level_Data>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left*levelDataManager.levelSpeed);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -0.05 || 1.05 < pos.x || pos.y < -0.05 || 1.05 < pos.y)
        {
            Destroy(gameObject);
            //print(pos.x);
        }

       // if (pos.x < 0.0) Debug.Log("I am left of the camera's view.");
       // if (1.0 < pos.x) Debug.Log("I am right of the camera's view.");
       // if (pos.y < 0.0) Debug.Log("I am below the camera's view.");
       // if (1.0 < pos.y) Debug.Log("I am above the camera's view.");


    }
}
