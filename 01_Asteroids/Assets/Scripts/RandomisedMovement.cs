using UnityEngine;

public class RandomisedMovement : MonoBehaviour
{
    private float moveSpeed = 1.0f;

    private Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, Random.Range(0, 359));
        rigidBody.linearVelocity = transform.TransformDirection(Vector2.right) * moveSpeed;

    }
}
