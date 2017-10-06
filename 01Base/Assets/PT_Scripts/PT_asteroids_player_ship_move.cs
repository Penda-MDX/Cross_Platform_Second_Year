using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_asteroids_player_ship_move : MonoBehaviour {
    public GameObject GO_bullet;
    public float fl_Ship_Rotation_Speed = 90;
    public float fl_Ship_Thrust = 5;
    public float fl_CoolDownTime = 3;

    //---
    private Touch tc_FirstTouch;


    //---Private and used internally
    private float fl_CoolDown;
    private Rigidbody2D RB_PC;

    // Use this for initialization
    void Start()
    {
        RB_PC = GetComponent<Rigidbody2D>();
        fl_CoolDown = Time.time + fl_CoolDownTime;
    }

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // Call the custom functions each frame
        MovePC();
        MoveTouch();
        Attack();
    }//----- 

    //---------------------------------------------------------------------------------------
    // Custom method for Character movement - Asteroid Style 
    void MovePC()
    {
        // Rotate with H axis    
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * fl_Ship_Rotation_Speed * Time.deltaTime);

        // Fix the movement to be push based
        RB_PC.AddForce(transform.right * Input.GetAxis("Vertical") * fl_Ship_Thrust);

        // Move with V axis only move while key is pressed
        //RB_PC.velocity = transform.TransformDirection(Vector2.right) * fl_Character_Move_Speed * Input.GetAxis("Vertical");

    }//-----

    void MoveTouch()
    {
        // tc_FirstTouch =  Input.touches[0];
        // do some triangle maths to move towards touch?

        // rubber band?

    }

    // Custom method  for triggering an attack
    void Attack()
    {
        /*
         * 
         * 
         * 
         // spawn a bomb when B is pressed
        if (Input.GetKeyDown("b") && in_bombs > 0)
        {
            Instantiate(GO_bomb, transform.position + transform.TransformDirection(Vector2.right), transform.rotation);
            in_bombs--;
        }
         */

        // Has the fire button (CTRL or mouse) been pressed and cooldown delay time passed
        if (Input.GetButtonDown("Fire1") && Time.time > fl_CoolDown)
        {
            // create a bullet 1 unit in front of the PC if the front is the right hand side
            Instantiate(GO_bullet, transform.position + transform.TransformDirection(Vector2.right), transform.rotation);

            // reset cooldown time
            fl_CoolDown = Time.time + fl_CoolDownTime;
        }

    }
}
