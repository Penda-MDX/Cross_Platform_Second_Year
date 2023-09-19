using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Drag_Throw_Mouse : MonoBehaviour {

    public float fl_PC_Move_Speed = 1;
    

    private Rigidbody2D RB_PC;

    private Vector2 v2_start_mouse_position;
    private Vector2 v2_movement;

    // Use this for initialization
    void Start()
    {
        RB_PC = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        //maybe there is a time component too?
        v2_start_mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //stop moving when you click on it
        RB_PC.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        PointToMouse();
        Vector2 _v2_mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _v2_differential = (_v2_mouseScreenPosition - v2_start_mouse_position);
        //print(_v2_differential.magnitude);
        //Add up force
        v2_movement = _v2_differential.sqrMagnitude * transform.up * fl_PC_Move_Speed;
        RB_PC.AddForce(v2_movement);
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
