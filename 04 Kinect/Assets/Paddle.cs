using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float paddleSpeed = 1f;

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = transform.position.x;

        if (PT_KinectTest.instance.IsAvailable)
        {
            xPos = PT_KinectTest.instance.PaddlePosition;
        }
        else
        {
            xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        }
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, -8f), -9.5f, 0f);

        transform.position = playerPos;
	}
}
