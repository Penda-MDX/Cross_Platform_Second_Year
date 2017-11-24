using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2D_Moving_Obstacle : MonoBehaviour {

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
        Vector3 temporaryVector2 = Vector2.zero;
        //
        temporaryVector2.x = wayPoints[currentWayPoint].transform.position.x;
        temporaryVector2.y = wayPoints[currentWayPoint].transform.position.y;

        //Use Trig to rotate and look at
        // get direction you want to point at
        Vector2 direction = ((Vector2)wayPoints[currentWayPoint].transform.position - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;

        //move towards the waypoint
        transform.Translate((transform.up * movementSpeed * Time.deltaTime));
        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, temporaryVector2) < movementSpeed/4)
        {
            currentWayPoint++;
            if (currentWayPoint > wayPoints.Count-1)
            {
                currentWayPoint = startingWayPoint;
            }
        }
	}
}
