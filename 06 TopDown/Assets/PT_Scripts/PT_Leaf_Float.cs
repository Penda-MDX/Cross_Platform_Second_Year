using UnityEngine;
using System.Collections;

public class PT_Leaf_Float : MonoBehaviour {
    public float fl_force_time = 0.5f;
    public Vector2 v2_force_vector = new Vector2(1, 0);
    public float fl_thrust = 3.0f;

    public float lifeAfterLanding = 5;

    private bool isGrounded;
    private float _fl_next_time;
    private Rigidbody2D rb_leaf;

	// Use this for initialization
	void Start () {
        rb_leaf = GetComponent<Rigidbody2D>();
        rb_leaf.AddForce(v2_force_vector * fl_thrust);
        fl_thrust = fl_thrust * -1;
        _fl_next_time = Time.time + fl_force_time;

	}
	
	// Update is called once per frame
	void Update () {
        if (!isGrounded)
        {
            if (Time.time > _fl_next_time)
            {
                float _fl_down = rb_leaf.velocity.y;
                rb_leaf.velocity = new Vector2(0, _fl_down);
                rb_leaf.AddForce(v2_force_vector * fl_thrust);
                fl_thrust = fl_thrust * -1;
                _fl_next_time = Time.time + fl_force_time;
            }
        }
        else
        {
            if(Time.time > _fl_next_time)
            {
                Destroy(gameObject);
            }
        }
	}

    public void RespondToWind()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hit");
        isGrounded = true;
        _fl_next_time = Time.time + lifeAfterLanding;
    }
}
