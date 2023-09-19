using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2D_NPC_Seeker : MonoBehaviour {

    public string nameOfCharacter;
    public int strength;
    public float walkingSpeed;
    public float runningSpeed;
    public bool isRunning;
    public float waitTimeLostQuary;
    public string currentActivityState;
    public List<GameObject> levelWayPoints;
    //look for a solution for waypoint routes that allows choices
    public int[,] waypointRoutingTable;
    public int currentGoal = 0;
    private GameObject currentWaypointTarget;
    private Rigidbody2D RB_NPC;
    private float waitTimer;

    // Use this for initialization
    void Start () {
        currentWaypointTarget = FindNearestWayPoint();
        RB_NPC = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        switch (currentActivityState)
        {
            case "Patrol":
                MoveToNextWaypoint();
                CheckSurroundings();
                break;
            case "Chase":
                MoveToFollowPC();
                CheckDistanceToPC();
                CheckSurroundings();
                break;
            case "Pause":
                WaitForTimeToPass();
                CheckSurroundings();
                break;
            case "Capture":
                MoveToPrison();
                break;
            case "ReturnToPatrol":

                break;
            default:
                break;
        }
    }

    private void MoveToFollowPC()
    {

    }

    private void MoveToPrison()
    {
        print("Go to jail! Do not pass go.");
    }

    private void MoveToNextWaypoint()
    {
        Vector3 temporaryVector2 = Vector2.zero;
        //
        temporaryVector2.x = currentWaypointTarget.transform.position.x;
        temporaryVector2.y = currentWaypointTarget.transform.position.y;

        //Use Trig to rotate and look at
        // get direction you want to point at
        Vector2 direction = ((Vector2)currentWaypointTarget.transform.position - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;

        float movementSpeed = 0;

        if (isRunning)
        {
            movementSpeed = runningSpeed;
        }
        else
        {
            movementSpeed = walkingSpeed;
        }
        //Add up force
        //RB_NPC.AddForce(transform.up * movementSpeed);
        RB_NPC.velocity = transform.up * movementSpeed;

        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, temporaryVector2) < movementSpeed / 4)
        {
            // Stop Moving
            RB_NPC.velocity = Vector2.zero;
            currentWaypointTarget = FindNextWayPoint();
        }
    }

    private void CheckSurroundings()
    {
        //Check sight and sound rules to check if you need to chase or wait


    }

    private void CheckDistanceToPC()
    {
        //Check to see if the PC is close enough to be captured
    }

    private void WaitForTimeToPass()
    {

    }

    private void TransitionChaseToPause()
    {

    }

    private void TransitionPatrolToChase()
    {

    }


    private GameObject FindNearestWayPoint()
    {
        GameObject bestGuess = null;

        //look through the waypoint list and find the one that is within 3 meters
        foreach(GameObject wp in levelWayPoints)
        {
            if (Vector3.Distance(wp.transform.position,transform.position)<3.0f)
            {
                bestGuess = wp;
                return bestGuess;
            }
        }
        bestGuess = levelWayPoints[0];
        return bestGuess;
    }

    private GameObject FindNextWayPoint()
    {
        GameObject bestGuess = null;

        //use goal and look up table for level to find next


        return bestGuess;
    }

}
