using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets
{
    public class PT_TopDown_Controller : MonoBehaviour
    {


        public float fl_PC_Move_Speed;
        public float fl_PC_Rotate_Speed = 3f;
        public float max_velocity = 30f;
        private Rigidbody2D RB_PC;

        private Vector3 v3_movement;
        private Vector2 v2_movement;

        private int flip = 1;
        // Use this for initialization
        void Start()
        {
            RB_PC = gameObject.GetComponent<Rigidbody2D>();
            flip = GameObject.FindGameObjectWithTag("GameController").GetComponent<PT_Basic_GameManager>().flip_glob;
        }

        // Update is called once per frame
        void Update()
        {
            RigidBodyForcesMove();
            
        }


        void RigidBodyForcesMove()
        {

           transform.Rotate(0, 0, CrossPlatformInputManager.GetAxis("Horizontal") * -fl_PC_Rotate_Speed *flip);
            if (RB_PC.velocity.magnitude < max_velocity)
            {
                //v2_movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * fl_PC_Move_Speed;
                v2_movement = CrossPlatformInputManager.GetAxis("Vertical") * fl_PC_Move_Speed * transform.up * flip;
                RB_PC.AddForce(v2_movement);
            }
            
            //Rotate to point in direction of travel

        }
    }
}