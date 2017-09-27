using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_randomised_at_start_movement : MonoBehaviour {

    public float fl_move_speed = 1.0f;

    private Rigidbody2D RB_This_Block;

    // Use this for initialization
    void Start()
    {
        RB_This_Block = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, Random.Range(0,359));
        RB_This_Block.velocity = transform.TransformDirection(Vector2.right) * fl_move_speed;

    }
}
