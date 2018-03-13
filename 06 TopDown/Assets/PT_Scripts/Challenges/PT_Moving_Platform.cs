using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Moving_Platform : MonoBehaviour {

    public List<GameObject> wayPoints;
    public int startingWayPoint = 0;
    public float movementSpeed = 3;
    public bool pauseAtEnd;
    public float pauseTime = 1.5f;
    private int currentWayPoint;
    private float startTime;
    private float journeyLength;
    private float pauseUntil;
    private bool paused = false;
    private Transform startMarker;
    private Transform endMarker;

    // Use this for initialization
    void Start()
    {
        currentWayPoint = startingWayPoint;
        CalculateJourney();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused||!pauseAtEnd)
        {
            float distCovered = (Time.time - startTime) * movementSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
        else
        {
            if (pauseUntil < Time.time)
            {
                paused = false;
            }
        }
        //when near the waypoint change to the next waypoint
        if (Vector3.Distance(transform.position, endMarker.position) < movementSpeed / 4)
        {
            paused = true;
            pauseUntil = Time.time + pauseTime;

            currentWayPoint++;
            if (currentWayPoint > wayPoints.Count - 1)
            {
                currentWayPoint = 0;
            }
            CalculateJourney();
        }
    }

    void CalculateJourney()
    {

        startTime = Time.time;
        if (currentWayPoint == wayPoints.Count - 1)
        {
            startMarker = wayPoints[currentWayPoint].transform;
            endMarker = wayPoints[0].transform;
        }
        else
        {
            startMarker = wayPoints[currentWayPoint].transform;
            endMarker = wayPoints[currentWayPoint + 1].transform;
        }
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }

    }
}
