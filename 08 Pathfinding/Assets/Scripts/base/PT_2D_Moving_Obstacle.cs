using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2D_Moving_Obstacle : MonoBehaviour {

    public List<GameObject> wayPoints;
    public int startingWayPoint = 0;
    public float movementSpeed = 3;
    private int currentWayPoint;
    private Rigidbody2D RB_NPC;

    // Use this for initialization
    void Start () {
        currentWayPoint = startingWayPoint;
        RB_NPC = GetComponent<Rigidbody2D>();
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

        //Add up force
        //RB_NPC.AddForce(transform.up * movementSpeed);
        RB_NPC.velocity = transform.up * movementSpeed;

        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, temporaryVector2) < movementSpeed/4)
        {
            // Stop Moving
            RB_NPC.velocity = Vector2.zero;

            currentWayPoint++;
            if (currentWayPoint > wayPoints.Count-1)
            {
                currentWayPoint = startingWayPoint;
            }
        }
	}
}
