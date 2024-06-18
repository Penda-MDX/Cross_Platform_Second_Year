using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollow : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform target;
    private Vector3 startingV3;
    private bool respawn;

    private void Start()
    {
        startingV3 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (respawn )
        {
            transform.position = startingV3;
            respawn = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WoodenCage")
        {
            //probably needs to send a message to GameManger
            respawn = true;
        }
    }
}