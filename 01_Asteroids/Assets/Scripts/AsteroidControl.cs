using UnityEngine;

public class AsteroidControl : MonoBehaviour
{
    [SerializeField] private string asteroidState;
    [SerializeField] private string collisionTag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetAsteroidState()
    {
        return asteroidState;
    }

    public void OnClick()
    {
        GameManager.Instance.DestroyAsteroid(this);
    }
    
    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        Debug.Log("Collider " + collision2D.gameObject.tag);
        // when hit, loop through the array of objects spawning each one at this location
        if (collision2D.gameObject.tag != collisionTag)
        {
            Debug.Log("Asteroid Hit!");
            GameManager.Instance.DestroyAsteroid(this);
        }
    }//-----
}
