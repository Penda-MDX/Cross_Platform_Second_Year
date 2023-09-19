using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_screen_wrap : MonoBehaviour {

    //---------------------------------------------------------------------------------------
    // Variables
    //public Rect re_movement_limits = new Rect(-10, 5, 10, -5);
    public float fl_left_edge = -10;
    public float fl_right_edge = 10;
    public float fl_top_edge = 5;
    public float fl_bottom_edge = -5;

    // This is a rectangle with 4 values x, y, width, height
    // Units are 100 pixels

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // constrain x axis
        if (transform.position.x < fl_left_edge)
        {
            transform.position = new Vector2(fl_right_edge, transform.position.y);
        }

        if (transform.position.x > fl_right_edge)
        {
            transform.position = new Vector2(fl_left_edge, transform.position.y);
        }

        // constrain y axis
        if (transform.position.y > fl_top_edge)
        {
            transform.position = new Vector2(transform.position.x, fl_bottom_edge);
        }

        if (transform.position.y < fl_bottom_edge)
        {
            transform.position = new Vector2(transform.position.x, fl_top_edge);
        }

    }//-----

}
