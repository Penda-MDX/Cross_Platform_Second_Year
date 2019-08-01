using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnCard : MonoBehaviour {

    private Vector2 v2_start_mouse_position;
    private Vector2 v2_movement;
    private Vector2 v2_offset;
    private Vector2 v2_startPosition;

    // Use this for initialization
    void Start () {
        v2_startPosition = (Vector2)gameObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnMouseDrag()
    {
        Vector2 _v2_mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _v2_differential = (_v2_mouseScreenPosition - v2_start_mouse_position);
        //v2_movement = _v2_differential.sqrMagnitude * Vector2(1,1);
        //print("draggg");
        gameObject.transform.position = v2_startPosition + _v2_differential;
    }

    private void OnMouseDown()
    {
        //maybe there is a time component too?
        v2_start_mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v2_offset = (Vector2)gameObject.transform.position - v2_start_mouse_position;
        print("down");
    }

    private void OnMouseUp()
    {
        //calculate the difference left (yes) or right (no)
		


    }

    void PointToMouse()
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;
    }
}
