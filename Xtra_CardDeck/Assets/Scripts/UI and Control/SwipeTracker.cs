using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeTracker : MonoBehaviour
{
    public string status;
    private Vector2 initialPosition;
    private Touch currentTouch;

    // Start is called before the first frame update
    void Start()
    {
        status = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //print("mouse");
        }

        if (Input.touchCount >0)
        {
            print("touch");
            currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                initialPosition = currentTouch.position;
            }
            else if (currentTouch.phase == TouchPhase.Moved || currentTouch.phase == TouchPhase.Stationary)
            {
                // get the moved direction compared to the initial touch position
                Vector2 direction = currentTouch.position - initialPosition;

                // get the signed x direction
                // if(direction.x >= 0) 1 else -1
                float signedDirection = Mathf.Sign(direction.x);

                if (signedDirection == 1)
                {
                    //right
                    status = "Right";
                }
                else
                {
                    //left
                    status = "Left";
                }

                // are you sure you want to become faster over time?
                //rb.AddForce(sidewaysForce * signedDirection * Time.deltaTime, 0, 0);
            }
        }


    }

    
    /*
    public void OnEndDrag(PointerEventData eventData)
    {

        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        GetDragDirection(dragVectorDirection);
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }
    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        return draggedDir;
    }
    */

}
