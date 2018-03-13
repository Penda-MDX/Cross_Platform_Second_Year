using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_2DFoot : MonoBehaviour {

    public bool isGrounded = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
