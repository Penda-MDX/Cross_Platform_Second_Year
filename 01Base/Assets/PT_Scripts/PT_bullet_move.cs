using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_bullet_move : MonoBehaviour {

    [SerializeField]
    private float fl_Bullet_Move_Speed = 5;
    [SerializeField]
    private float fl_Bullet_Range = 20;

    //----
    private Rigidbody2D RB_Bullet;

    public float Fl_Bullet_Move_Speed
    {
        get
        {
            return fl_Bullet_Move_Speed;
        }

        set
        {
            fl_Bullet_Move_Speed = value;
        }
    }

    public float Fl_Bullet_Range
    {
        get
        {
            return fl_Bullet_Range;
        }

        set
        {
            fl_Bullet_Range = value;
        }
    }

    // Use this for initialization
    void Start () {
        RB_Bullet = GetComponent<Rigidbody2D>();
        // Set velocity to move forwards at the speed defined above
        RB_Bullet.velocity = transform.TransformDirection(Vector2.right) * Fl_Bullet_Move_Speed;

        // Remove this object from the scene when the range is reached - 
        Destroy(gameObject, Fl_Bullet_Range / Mathf.Abs(Fl_Bullet_Move_Speed));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
