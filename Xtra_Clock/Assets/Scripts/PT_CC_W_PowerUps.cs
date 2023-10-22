using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_CC_W_PowerUps : MonoBehaviour {

    public float movementSpeed = 6f;
    public float AirMovementSpeed = 3f;
    public float speedUpAmount;
    public float speedDownAmount;
    public float powerUpTime = 1.0f;

    public float fl_gravity = 15f;
    public float fl_JumpForce = 8.0f;
    public float fallMultiplier = 2.0f;
    //Private 
    private Vector3 V3_move_direction = Vector3.zero;
    private CharacterController cc_Reference_To_Character_Controller;
    private PT_LevelManager levelManagerReference;
    private bool canJumpAgain = true;
    private float startSpeed;
    private float startAirSpeed;

    private bool timer;
    private float timeOut;

    // Use this for initialization
    void Start()
    {
        startSpeed = movementSpeed;
        startAirSpeed = AirMovementSpeed;
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();
        levelManagerReference = GameObject.Find("LevelManager").GetComponent<PT_LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            if (timeOut < Time.time)
            {
                timer = false;
                ResetSpeed();
            }
        }


        //
        if (cc_Reference_To_Character_Controller.isGrounded)
        {
            canJumpAgain = true;
            V3_move_direction.y = 0;

            MovePC(movementSpeed);

        }
        else
        {
            //AirMovementSpeed
            MovePC(AirMovementSpeed);
            V3_move_direction.y -= fl_gravity * Time.deltaTime;

            //if the PC is falling (has passed apogee) then increase the gravity impact
            if (V3_move_direction.y < 0)
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
    public void FallToDeath()
    {
        transform.position = levelManagerReference.lastGoodCheckpoint.position;
        //levelManagerReference.lastGoodCheckpoint.gameObject.SendMessage("ResetThisZone", SendMessageOptions.DontRequireReceiver);
        levelManagerReference.lastGoodCheckpoint.gameObject.GetComponent<PT_CheckPoint>().ResetThisZone();
        ResetSpeed();
    }

    public void ChangeSpeed(float changeValue)
    {
        movementSpeed += changeValue;
        AirMovementSpeed += changeValue;
        timer = true;
        timeOut = Time.time + powerUpTime;
    }

    public void ResetSpeed()
    {
        movementSpeed = startSpeed;
        AirMovementSpeed = startAirSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "SpeedUp":
                ChangeSpeed(speedUpAmount);
                other.gameObject.SetActive(false);
                break;
            case "SpeedDown":
                ChangeSpeed(speedDownAmount);
                other.gameObject.SetActive(false);
                break;
            case "TimeBonus":
                levelManagerReference.BonusTime(20f);
                other.gameObject.SetActive(false);
                break;
            case "StartCountDown":
                //setup script on the trigger and check for time to go
                levelManagerReference.StartTimer(30f);
                other.gameObject.SetActive(false);
                break;
            default:

                break;
        }
    }
}
