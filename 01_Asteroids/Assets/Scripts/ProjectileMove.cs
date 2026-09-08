using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float bulletRange = 20f;

    //----
    private Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // Set velocity to move forwards at the speed defined above
        rigidBody.linearVelocity = transform.TransformDirection(Vector2.right) * moveSpeed;

        // Remove this object from the scene when the range is reached - 
        Destroy(gameObject, bulletRange / Mathf.Abs(moveSpeed));
    }

    // Update is called once per frame
    private void Update()
    {

    }
}
