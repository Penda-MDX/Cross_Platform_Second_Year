using UnityEngine;

public class IncreaseScoreWhenHit : MonoBehaviour
{
    [SerializeField] private string collisionTag;
    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D collision2D)
    {

        // when hit, loop through the array of objects spawning each one at this location
        if (collision2D.gameObject.tag != collisionTag)
        {
            Destroy(gameObject);
        }
    }//-----
}
