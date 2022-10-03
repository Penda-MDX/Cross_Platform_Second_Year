using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_joystick : MonoBehaviour
{
    public bool joyStart = false;

    private Vector3 startTouchPosition;
    private Vector3 currentTouchPosition;
    private Vector3 lastTouchPosition;

    public Vector3 centerPoint;
    public float outerRadius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joyStart)
        {
            Touch touch1 = Input.GetTouch(0);
            currentTouchPosition = Camera.main.ScreenToWorldPoint(touch1.position);
            //constraints
            Vector3 v3Diff = (currentTouchPosition - startTouchPosition);
            if (v3Diff.sqrMagnitude<outerRadius)
            {
                //move button


                //reset last position
                lastTouchPosition = currentTouchPosition;
            }
            else
            {

            }


        }
    }

    //event bound to button
    public void joystick_start()
    {
        joyStart = true;
        Touch touch1 = Input.GetTouch(0);
        startTouchPosition = Camera.main.ScreenToWorldPoint(touch1.position);
        startTouchPosition.z = 0;
    }
}
