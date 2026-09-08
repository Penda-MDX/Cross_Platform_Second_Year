using UnityEngine;

public class SpawnWhenHit : MonoBehaviour
{
    [SerializeField] private string collisionTag;
    
    public GameObject[] spawneeList;


    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        // when hit, loop through the array of objects spawning each one at this location
        if (collision2D.gameObject.tag != collisionTag)
        {
            foreach (GameObject gameObject in spawneeList)
            {
                Instantiate(gameObject, transform.position, transform.rotation);
            }
        }
    }//-----
}
