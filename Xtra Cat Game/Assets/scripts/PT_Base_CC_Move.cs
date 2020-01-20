using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Base_CC_Move : MonoBehaviour {
    //public properties
    public float fl_MovementSpeed = 6f;
    public float fl_gravity = 15f;
    public float fl_JumpForce = 8.0f;

    //private properties
    private Vector3 V3_move_direction = Vector3.zero;
    private CharacterController cc_Reference_To_Character_Controller;
    private PT_LevelManager levelManagerReference;

    // Use this for initialization
    void Start () {
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();
        levelManagerReference = GameObject.Find("LevelManager").GetComponent<PT_LevelManager>();
    }	
	// Update is called once per frame
	void Update () {
       

        if (cc_Reference_To_Character_Controller.isGrounded)
        {
            V3_move_direction.x = Input.GetAxis("Horizontal");
            V3_move_direction.y = 0;
            V3_move_direction.z = Input.GetAxis("Vertical");
            V3_move_direction = V3_move_direction * fl_MovementSpeed * Time.deltaTime;

            if (V3_move_direction.x != 0 || V3_move_direction.z != 0)
            {
                Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                Vector3 rightMovement = Vector3.right * Input.GetAxis("Horizontal");
                Vector3 upMovement = Vector3.forward * Input.GetAxis("Vertical");

                Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                transform.forward = heading;
            }

        }
        else
        {
            V3_move_direction.y -= fl_gravity * Time.deltaTime;
        }
        if (cc_Reference_To_Character_Controller.isGrounded && Input.GetButton("Jump"))
        {
            V3_move_direction.y = fl_JumpForce;
        }

        cc_Reference_To_Character_Controller.Move(V3_move_direction);
    }

    void FallToDeath()
    {
        transform.position = levelManagerReference.lastGoodCheckpoint.position;
    }

}
