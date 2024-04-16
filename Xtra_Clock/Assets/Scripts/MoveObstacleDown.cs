using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
