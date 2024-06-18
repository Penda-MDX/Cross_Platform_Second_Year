using UnityEngine;

public class Creature : MonoBehaviour
{
    public Transform player; // Reference to the player object
    public float followDistance = 20f; // Distance at which the creature follows the player
    public float moveSpeed = 3f; // Speed at which the creature moves

    private void Update()
    {
        // Check if the player object is assigned
        if (player != null)
        {
            // Calculate the direction vector from the creature to the player
            Vector3 direction = player.position - transform.position;

            // Calculate the distance between the creature and the player
            float distance = direction.magnitude;

            // Check if the player is beyond the follow distance
            if (distance > followDistance)
            {
                // Normalize the direction vector
                direction /= distance;

                // Calculate the target position where the creature should move
                Vector3 targetPosition = player.position - direction * followDistance;

                // Move the creature towards the target position with smooth interpolation
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}
