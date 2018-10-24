using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets
{
    public class PT_TD_RPG_Movement : MonoBehaviour
    {


        public float fl_PC_Move_Speed;
        public float fl_PC_Rotate_Speed = 3f;
        public float max_velocity = 30f;
       

        private Vector3 v3_movement;
        private Vector2 v2_movement;

        // Use this for initialization
        void Start()
        {
       

        }

        // Update is called once per frame
        void Update()
        {
            TurnandMove();


        }


        void TurnandMove()
        {

            //Rotate to point in direction of travel
            transform.Rotate(0, 0, CrossPlatformInputManager.GetAxis("Horizontal") * -fl_PC_Rotate_Speed);
            v2_movement = new Vector2(0, CrossPlatformInputManager.GetAxis("Vertical")) * fl_PC_Move_Speed;
            //v2_movement = CrossPlatformInputManager.GetAxis("Vertical") * fl_PC_Move_Speed * transform.up;

            transform.Translate(v2_movement*Time.deltaTime);
                

        }
    }
}