using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Moving_Obstacle : MonoBehaviour {

    public List<GameObject> wayPoints;
    public int startingWayPoint = 0;
    public float movementSpeed = 3;
    private int currentWayPoint;

	// Use this for initialization
	void Start () {
        currentWayPoint = startingWayPoint;
    }
	// Update is called once per frame
	void Update () {
        //point at the waypoint but make the way point 
        //at the same y position to prevent tilting
        Vector3 temporaryVector3 = Vector3.zero;
        //
        temporaryVector3.x = wayPoints[currentWayPoint].transform.position.x;
        temporaryVector3.y = gameObject.transform.position.y;
        temporaryVector3.z = wayPoints[currentWayPoint].transform.position.z;
        //
        transform.LookAt(temporaryVector3);
        //move towards the waypoint
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, temporaryVector3) < movementSpeed/4)
        {
            currentWayPoint++;
            if (currentWayPoint > wayPoints.Count-1)
            {
                currentWayPoint = startingWayPoint;
            }
        }
	}
}
