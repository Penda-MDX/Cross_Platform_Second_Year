using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Drag_Throw_Touch : MonoBehaviour 
{


	public float fl_PC_Move_Speed = 1;


	private Rigidbody2D RB_PC;

	private Vector3 v3_start_touch_position;
	private Vector3 v3_movement;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch1 = Input.GetTouch(0);
			if (touch1.phase == TouchPhase.Began)
			{
				v3_start_touch_position = Camera.main.ScreenToWorldPoint(touch1.position);
				v3_start_touch_position.z = 0;
			}
			if (touch1.phase == TouchPhase.Ended)
			{
				// convert touch position into world coordinates
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				touchPosition.z = 0;
				// get direction you want to point at
				Vector2 direction = (touchPosition - transform.position).normalized;

				// set vector of transform directly
				transform.up = direction;

				Vector3 _v3_differential = (touchPosition - v3_start_touch_position);
				//print(_v2_differential.magnitude);
				//Add up force
				v3_movement = _v3_differential.sqrMagnitude * transform.up * fl_PC_Move_Speed;
				RB_PC.AddForce(v3_movement);
			}

		}
	}
    
}
