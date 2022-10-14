using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_MultiTouch : MonoBehaviour
{

    public Transform characterTransform;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    private GameObject[] touchCircles;

    public Transform circle;
    public Transform outerCircle;
    public GameObject touchObject;

    // Update is called once per frame
    void Update()
    {


        if(Input.touchCount>0)
        {
            Touch[] TouchList = Input.touches;
            if(touchCircles.Length<Input.touchCount)
            {
                int countStart = touchCircles.Length;
                GameObject[] newTouchCircles = new GameObject[Input.touchCount];

                for(int touchCounter = 0; touchCounter < Input.touchCount; touchCounter++)
                {
                    if(touchCounter<countStart)
                    {
                        newTouchCircles[touchCounter] = touchCircles[touchCounter];
                    }
                    else
                    {
                        newTouchCircles[touchCounter] = Instantiate(touchObject);
                    }
                }
                touchCircles = newTouchCircles;
            }
            for(int counter=0; counter< Input.touchCount; counter++)
            {
               touchCircles[counter].transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(counter).position);
            }

        }
    }
}
