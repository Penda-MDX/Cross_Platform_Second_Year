using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Pickup : MonoBehaviour {

    private PT_Basic_GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PT_Basic_GameManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.score++;
            Destroy(gameObject);
        }
    }
}
