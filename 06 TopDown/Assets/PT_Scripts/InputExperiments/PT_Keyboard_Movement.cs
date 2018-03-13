using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets
{
    public class PT_Keyboard_Movement : MonoBehaviour
    {

        public float fl_PC_Move_Speed;

        private Rigidbody2D RB_PC;

        private Vector3 v3_movement;
        private Vector2 v2_movement;

        // Use this for initialization
        void Start()
        {
            RB_PC = gameObject.GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update()
        {
            //BasicMove();
            //RigidBodyVelocityMove();
            RigidBodyForcesMove();
        }

        void BasicMove()
        {
            //Movement with keyboard no rigidbodies
            print(CrossPlatformInputManager.GetAxis("Horizontal"));
            v3_movement = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0) * fl_PC_Move_Speed * Time.deltaTime;
            transform.Translate(v3_movement);
        }

        void RigidBodyVelocityMove()
        {
            RB_PC.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * fl_PC_Move_Speed;
        }

        void RigidBodyForcesMove()
        {
            v2_movement = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * fl_PC_Move_Speed;
            RB_PC.AddForce(v2_movement);
        }
    }
}