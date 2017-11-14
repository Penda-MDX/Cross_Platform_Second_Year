using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Follow_Mouse : MonoBehaviour {

   
    public float fl_PC_Move_Speed;

    private Rigidbody2D RB_PC;

    private Vector3 v3_last_mouse_position;
    private Vector2 v2_movement;

    // Use this for initialization
    void Start()
    {
        RB_PC = gameObject.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if(v3_last_mouse_position != Input.mousePosition)
        {
            v3_last_mouse_position = Input.mousePosition;
            //stop moving
            RB_PC.velocity = Vector2.zero;
            //Turn and face the mouse
            PointToMouse();

            //
            v2_movement = transform.up * fl_PC_Move_Speed;
            RB_PC.AddForce(v2_movement);
        }

        
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
