using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipMove : MonoBehaviour
{
    public Vector2 bottomLeft;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down and destroy once out of sight
        transform.Translate(0, moveSpeed, 0);

        if (transform.position.y < bottomLeft.y)
        {
            Destroy(gameObject);
        }
    }
}
