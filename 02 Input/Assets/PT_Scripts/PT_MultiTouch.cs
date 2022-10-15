using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_MultiTouch : MonoBehaviour
{

    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public GameObject[] touchCircles;

    public GameObject touchObject;
    public GameObject[] indicatorObjects;
    public Text textObject;


    // Update is called once per frame
    void Update()
    {

        for (int touchCounter = 0; touchCounter < touchCircles.Length; touchCounter++)
        {
            indicatorObjects[touchCounter].SetActive(false);
            touchCircles[touchCounter].SetActive(false);
        }

        if (Input.touchCount>0)
        {
            for (int touchCounter = 0; touchCounter < Input.touchCount; touchCounter++)
            {
                indicatorObjects[touchCounter].SetActive(true);
                touchCircles[touchCounter].SetActive(true);

                Vector3 tempNewPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCounter).position);
                tempNewPosition.z = 0;

                touchCircles[touchCounter].transform.position = tempNewPosition;
            }


        }
    }
}
