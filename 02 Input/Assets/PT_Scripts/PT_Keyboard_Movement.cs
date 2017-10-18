using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Keyboard_Movement : MonoBehaviour {

    public float fl_PC_Move_Speed;

    private Rigidbody2D RB_PC;

    private Vector3 v3_movement;
    private Vector2 v2_movement;

    // Use this for initialization
    void Start () {
        RB_PC = gameObject.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        //BasicMove();
        //RigidBodyVelocityMove();
        RigidBodyForcesMove();
    }

    void BasicMove()
    {
       //Movement with keyboard no rigidbodies
        v3_movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * fl_PC_Move_Speed * Time.deltaTime;
        transform.Translate(v3_movement);
    }

    void RigidBodyVelocityMove()
    {
        RB_PC.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * fl_PC_Move_Speed;
    }

    void RigidBodyForcesMove()
    {
        v2_movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * fl_PC_Move_Speed;
        RB_PC.AddForce(v2_movement);
    }
}
