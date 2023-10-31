using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

    private Vector3 currentPosition;
    private bool isFollowing = true;
    [SerializeField] private float timeoutSeconds;
    private float nextTime;

	// Use this for initialization
	void Start () {
        nextTime = Time.time + timeoutSeconds;
    }
	
	// Update is called once per frame
	void Update () {
        if (isFollowing)
        {
            currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("Mouse pos: " + Input.mousePosition);
            //Debug.Log("Calc pos: " + currentPosition);
            // Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print("Mouse position: " + Input.mousePosition);
            print("Convert: " + currentPosition);
            currentPosition.z = transform.position.z;

            //transform.position = Vector3.MoveTowards(transform.position, currentPosition, 0.5f * Time.deltaTime);
            transform.position = currentPosition;
//            if (Input.GetMouseButtonUp(0))
//            {
//                isFollowing = !isFollowing;
//            }

        }
        

	}
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && nextTime<=Time.time)
        {
            print("Yes and...");
            isFollowing = !isFollowing;
            nextTime = Time.time + timeoutSeconds;
        }
    }
}
