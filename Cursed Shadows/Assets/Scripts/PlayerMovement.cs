using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 100f; // Rotation speed
    public Vector3 startingV3;
    public bool respawn;

    private Rigidbody rb;

    void Start()
    {
        startingV3 = transform.position;

        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        rb.freezeRotation = true; // Freeze rotation to prevent falling
    }

    void Update()
    {
        // Calculate rotation based on mouse movement
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);

        // Calculate movement based on keyboard input
        float moveInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.deltaTime;

        // Add strafing movement based on A and D keys
        float strafeInput = Input.GetAxis("Horizontal");
        movement += transform.right * strafeInput * moveSpeed * Time.deltaTime;

        // Apply movement
        rb.MovePosition(rb.position + movement);

        if (respawn)
        {
            transform.position = startingV3;
            respawn = false;
        }
    }

    void OnTriggerEnter(Collider other )
    {
        if(other.gameObject.tag == "Doom")
        {
            respawn = true;
        }
    }
}
