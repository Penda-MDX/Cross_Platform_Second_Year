using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_basic_forward_move : MonoBehaviour {

    public float fl_move_speed = 1.0f;

    private Rigidbody2D RB_This_Block;

	// Use this for initialization
	void Start () {
        RB_This_Block = GetComponent<Rigidbody2D>();
        RB_This_Block.velocity = transform.TransformDirection(Vector2.right) * fl_move_speed;

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
