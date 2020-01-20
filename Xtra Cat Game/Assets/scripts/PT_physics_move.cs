using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_physics_move : MonoBehaviour
{
    public float fl_push_force = 10f;
    public float fl_jump_force = 10f;
    private Rigidbody rb_Physics_RigidBody;

    public PT_Foot footScript;

    // Start is called before the first frame update
    void Start()
    {
        rb_Physics_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (footScript.isGrounded)
        {
            Vector3 _temporary_force = Vector3.zero;

            _temporary_force.x = Input.GetAxis("Horizontal") * fl_push_force;
            _temporary_force.z = Input.GetAxis("Vertical") * fl_push_force;

            if (Input.GetButton("Jump"))
            {
                _temporary_force.y = fl_jump_force;
            }

            rb_Physics_RigidBody.AddForce(_temporary_force);


        }
    }
}
