using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSlide : MonoBehaviour
{
    public Canvas yesCanvas;
    public Text answerText;
    public float journeyTime = 1.0f;

    private Vector3 startPosition;
    private Vector2 clickCurrent;
    private Vector2 clickLast;
    private bool clicked = false;

    private float startTime;
    private float fracComplete;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            fracComplete = (Time.time - startTime) / journeyTime;
            gameObject.transform.position = Vector3.Slerp(gameObject.transform.position, startPosition, fracComplete);
            if (startPosition == gameObject.transform.position)
            {
                answerText.text = "";
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            clicked = false;
            startTime = Time.time;
        }

        if (Input.GetMouseButtonDown(0))
        {
            clicked = true;
            clickCurrent = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            clickLast = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (clickLast != clickCurrent)
            {
                gameObject.transform.position = clickLast;
                clickCurrent = clickLast;
                float xMoved = clickLast.x - startPosition.x;
                //answerText.text = xMoved.ToString();
                if (xMoved < 0)
                {
                    //left swiping
                    answerText.text = "No";
                }
                if (xMoved > 0)
                {
                    //left swiping
                    answerText.text = "Yes";
                }
            }
        }
    }
}
