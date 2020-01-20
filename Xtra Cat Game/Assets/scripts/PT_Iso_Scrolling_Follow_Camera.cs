using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Iso_Scrolling_Follow_Camera : MonoBehaviour {

    public GameObject go_thingToBeFollowed;
    public float fl_distanceOn_zAxis = 10f;
    public float fl_distanceOn_xAxis = -3f;
    public float fl_distanceOn_yAxis = -3f;
    public bool bl_pointAt = true;
    private Vector3 v3_new_camera_position = Vector3.zero;

	// Use this for initialization
	void Start () {
        //if a thing to be followed by the camera has not been defined in the editor then 
        if (go_thingToBeFollowed == null)
        {
            //Try getting all the objects with the Player Tag and pick the first one
            GameObject[] _List_Of_GameObjects = GameObject.FindGameObjectsWithTag("Player");
            go_thingToBeFollowed = _List_Of_GameObjects[0];
        }
        //if there is still no object what do we do?
	}
	
	// Update is called once per frame
	void Update () {
       // print(go_thingToBeFollowed.transform.position.x);
        v3_new_camera_position.x = go_thingToBeFollowed.transform.position.x - fl_distanceOn_xAxis;
        v3_new_camera_position.y = go_thingToBeFollowed.transform.position.y - fl_distanceOn_yAxis;
        v3_new_camera_position.z = go_thingToBeFollowed.transform.position.z - fl_distanceOn_zAxis;
        //
        if (v3_new_camera_position.x != transform.position.x || v3_new_camera_position.y != transform.position.y || v3_new_camera_position.z != transform.position.z)
        {
            transform.position = v3_new_camera_position;
        }
        // should we rotate the camera to point at the thing we are following?
        if (bl_pointAt)
        {
            transform.LookAt(go_thingToBeFollowed.transform);
        }
    }
}
