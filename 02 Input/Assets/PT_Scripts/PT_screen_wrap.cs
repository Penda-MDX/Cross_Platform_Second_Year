using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_screen_wrap : MonoBehaviour
{

    //---------------------------------------------------------------------------------------
    // Variables
    public Rect re_movement_limits = new Rect(-10, 5, 10, -5);
    // This is a rectangle with 4 values x, y, width, height
    // Units are 100 pixels

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // constrain x axis
        if (transform.position.x < re_movement_limits.x)
            transform.position = new Vector2(re_movement_limits.width, transform.position.y);

        if (transform.position.x > re_movement_limits.width)
            transform.position = new Vector2(re_movement_limits.x, transform.position.y);

        // constrain y axis
        if (transform.position.y > re_movement_limits.y)
            transform.position = new Vector2(transform.position.x, re_movement_limits.height);

        if (transform.position.y < re_movement_limits.height)
            transform.position = new Vector2(transform.position.x, re_movement_limits.y);
    }//-----

}