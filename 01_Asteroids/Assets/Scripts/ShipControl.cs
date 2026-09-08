using UnityEngine;
using UnityEngine.InputSystem;

public class ShipControl : MonoBehaviour
{
    private bool isHit;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private string immuneCollisionTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);

        if (Keyboard.current.wKey.isPressed)
        {
            inputMoveDir.x = +1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputMoveDir.x = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            inputMoveDir.y = +1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            inputMoveDir.y = -1f;
        }
        Vector3 moveVector = transform.TransformDirection(Vector2.right) * inputMoveDir.x;
        rigidBody.AddForce(moveVector * moveSpeed * Time.deltaTime);
        Vector3 rotationVector = transform.forward * inputMoveDir.y;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;


    }

    
    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (isHit)
        {
            return;
        }
        // when hit, loop through the array of objects spawning each one at this location
        if (collision2D.gameObject.tag != immuneCollisionTag)
        {
            GameManager.Instance.PlayerShipDeath(this);
            isHit = true;
        }
    }//-----



}
