using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Physics_Character : MonoBehaviour {

    public float fl_MovementSpeed = 6f;
    public float fl_JumpForce = 8.0f;
    public PT_Foot footScript;
    public float maxVelocity = 5f;

    public float groundDrag = 2;
    public float movingDrag = 0;
    public float airDrag = 0.5f;
    private Vector3 V3_move_direction = Vector3.zero;
    private Rigidbody characterRB;
    // Use this for initialization
    void Start () {
        characterRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //playing with wall running
        //make foot more than 1 in z axis
        //characterRB.useGravity = true;
        if (footScript.isGrounded)
        {
            if (characterRB.velocity.magnitude < maxVelocity)
            {
                V3_move_direction.x = Input.GetAxis("Horizontal");
                V3_move_direction.y = 0;
                V3_move_direction.z = Input.GetAxis("Vertical");
                V3_move_direction = V3_move_direction * fl_MovementSpeed * Time.deltaTime;
                if (V3_move_direction!=Vector3.zero)
                {
                    characterRB.AddRelativeForce(V3_move_direction);
                    characterRB.drag = movingDrag;
                    //playing with wall running
                    //characterRB.useGravity = false;
                }
                else
                {
                    characterRB.drag = groundDrag;
                }
                
            }
            

            if (Input.GetButton("Jump"))
            {
                characterRB.AddRelativeForce(transform.up * fl_JumpForce);
                characterRB.drag = airDrag;
            }
        }
	}

}
