using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Click_Follow_Mouse : MonoBehaviour {


    public float fl_PC_Move_Speed;
    public float fl_proximity_offset = 0.1f;

    private Rigidbody2D RB_PC;

    private Vector2 v2_last_mouse_position;
    private Vector2 v2_movement;

    // Use this for initialization
    void Start()
    {
        RB_PC = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            v2_last_mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            //stop moving
            RB_PC.velocity = Vector2.zero;
            //Turn and face the mouse
            PointToMouse();

            //Add up force
            v2_movement = transform.up * fl_PC_Move_Speed;
            RB_PC.AddForce(v2_movement);
        }

        StopNearClick();


    }

    void PointToMouse()
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;

        /* Using Trigonometery
         *   var mouse = Input.mousePosition;
             var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
             var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
             var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.Euler(0, 0, angle);
        */


    }

    void StopNearClick()
    {
        //Work out when the mover is close to the click spot and stop
        //temporary proximity bounds
        float _fl_right = (transform.position.x + fl_proximity_offset);
        float _fl_left = (transform.position.x - fl_proximity_offset);
        float _fl_bottom = (transform.position.y + fl_proximity_offset);
        float _fl_top = (transform.position.y - fl_proximity_offset);

        //print("X: " + (_fl_right > v2_last_mouse_position.x && _fl_left < v2_last_mouse_position.x));

        if ((_fl_right > v2_last_mouse_position.x && _fl_left < v2_last_mouse_position.x) && (_fl_bottom > v2_last_mouse_position.y && _fl_top < v2_last_mouse_position.y))
        {
            RB_PC.velocity = Vector2.zero;
        }
    }

}
