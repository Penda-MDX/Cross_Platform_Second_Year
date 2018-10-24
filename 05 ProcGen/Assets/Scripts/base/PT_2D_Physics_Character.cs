using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2D_Physics_Character : MonoBehaviour {

    public float movementSpeed = 6f;
    public float jumpForce = 8.0f;
    public PT_2DFoot footScript;
    public float maxVelocity = 5f;

    public float groundDrag = 2;
    public float movingDrag = 0;
    public float airDrag = 0.5f;
    private Vector3 moveVectorDirection = Vector3.zero;
    private Rigidbody2D characterRB;
    // Use this for initialization
    void Start()
    {
        characterRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //playing with wall running
        //make foot more than 1 in z axis
        //characterRB.useGravity = true;
        if (footScript.isGrounded)
        {
            if (characterRB.velocity.magnitude < maxVelocity)
            {
                moveVectorDirection.x = Input.GetAxis("Horizontal");
                moveVectorDirection.y = 0;
                //moveVectorDirection.z = Input.GetAxis("Vertical");
                moveVectorDirection = moveVectorDirection * movementSpeed * Time.deltaTime;
                if (moveVectorDirection != Vector3.zero)
                {
                    characterRB.AddRelativeForce(moveVectorDirection);
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
                characterRB.AddRelativeForce(transform.up * jumpForce);
                characterRB.drag = airDrag;
            }
        }
        else
        {

        }
    }
}
