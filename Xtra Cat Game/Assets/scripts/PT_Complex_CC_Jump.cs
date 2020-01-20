using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Complex_CC_Jump : MonoBehaviour {

    public float fl_MovementSpeed = 6f;
    public float AirMovementSpeed = 3f;
    public float fl_gravity = 15f;
    public float fl_JumpForce = 8.0f;
    public float fallMultiplier = 2.0f;
    //Private 
    private Vector3 V3_move_direction = Vector3.zero;
    private CharacterController cc_Reference_To_Character_Controller;
    private PT_LevelManager levelManagerReference;
    private bool canJumpAgain = true;
    private bool isClimbing = false;

    // Use this for initialization
    void Start()
    {
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();
        levelManagerReference = GameObject.Find("LevelManager").GetComponent<PT_LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //
        if (cc_Reference_To_Character_Controller.isGrounded)
        {
            canJumpAgain = true;
            V3_move_direction.y = 0;

            MovePC(fl_MovementSpeed);

        }
        else if (isClimbing)
        {
            canJumpAgain = true;
            //V3_move_direction.y = 0;

            MovePC(fl_MovementSpeed);
        }
        else
        {
            //AirMovementSpeed
            MovePC(AirMovementSpeed);
            V3_move_direction.y -= fl_gravity * Time.deltaTime;

            //if the PC is falling (has passed apogee) then increase the gravity impact
            if (V3_move_direction.y < 0 && !isClimbing)
            {
                V3_move_direction.y -= (fl_gravity * Time.deltaTime)*fallMultiplier;
            }

        }

        if (cc_Reference_To_Character_Controller.isGrounded && Input.GetButton("Jump"))
        {
                 V3_move_direction.y = fl_JumpForce;

        } else if (Input.GetButtonDown("Jump") && canJumpAgain){
                V3_move_direction.y += fl_JumpForce;
                canJumpAgain = false;
        }
        cc_Reference_To_Character_Controller.Move(V3_move_direction);
    }

    void MovePC(float _speed)
    {
        if (!isClimbing)
        {
            V3_move_direction.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
            V3_move_direction.z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        
            //Uses the direction of movement to turn the character to face the direction of travel
            if (V3_move_direction.x != 0 || V3_move_direction.z != 0)
            {
                Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                Vector3 rightMovement = Vector3.right * Input.GetAxis("Horizontal");
                Vector3 upMovement = Vector3.forward * Input.GetAxis("Vertical");

                Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                transform.forward = heading;
            }
        }
        else if(isClimbing)
        {
            //climbing
            V3_move_direction.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
            V3_move_direction.y = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

            //Uses the direction of movement to turn the character to face the direction of travel
            if (V3_move_direction.x != 0 || V3_move_direction.z != 0)
            {
                Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                Vector3 rightMovement = Vector3.right * Input.GetAxis("Horizontal");
                Vector3 upMovement = Vector3.forward * Input.GetAxis("Vertical");

                Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                transform.forward = heading;
            }
        }

    }
    void FallToDeath()
    {
        transform.position = levelManagerReference.lastGoodCheckpoint.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Climbable")
        {
            isClimbing = false;
        }
    }
}
