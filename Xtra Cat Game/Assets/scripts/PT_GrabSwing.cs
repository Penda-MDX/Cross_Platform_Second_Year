using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_GrabSwing : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject rightSide;

    private PT_GrabCheck leftCheck;
    private PT_GrabCheck rightCheck;
    private Rigidbody characterRB;
    private HingeJoint swingHinge;



    // Start is called before the first frame update
    void Start()
    {
        leftCheck = leftSide.GetComponent<PT_GrabCheck>();
        rightCheck = rightSide.GetComponent<PT_GrabCheck>();
        characterRB = gameObject.GetComponent<Rigidbody>();
        swingHinge = characterRB.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leftCheck.canGrab)
        {
            swingHinge.connectedBody = leftCheck.grabableRB;
        }
        else if(rightCheck.canGrab)
        {
            print("Swiing");    
            swingHinge.connectedBody = rightCheck.grabableRB;
        }
    }
}
