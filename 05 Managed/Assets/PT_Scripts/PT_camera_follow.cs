using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_camera_follow : MonoBehaviour {

    public GameObject gameObjectFollowedByCamera;
       
    //Set an offset for the camera follow if it is not directly above the PC
    public float cameraOffsetPositionX = 0f;
    public float cameraOffsetPositionY = 0f;
    public float cameraOffsetPositionZ = -10f;

    //Set an offset angle for the camera follow so that the view can be rotated in euler(e.g. paperboy)
    public float cameraOffsetRotationX = 0f;
    public float cameraOffsetRotationY = 0f;
    public float cameraOffsetRotationZ = 0f;
    
    // Use this for initialization
    void Start () {
        if (gameObjectFollowedByCamera == null)
        {
            gameObjectFollowedByCamera = GameObject.FindGameObjectWithTag("Player");
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(cameraOffsetRotationX, cameraOffsetRotationY, cameraOffsetRotationZ);

        transform.position = gameObjectFollowedByCamera.transform.position + new Vector3(cameraOffsetPositionX, cameraOffsetPositionY, cameraOffsetPositionZ);

	}
}
