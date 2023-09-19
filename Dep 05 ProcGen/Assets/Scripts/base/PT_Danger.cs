using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Danger : MonoBehaviour {

    private PT_Basic_GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<PT_Basic_GameManager>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.deaths++;
           // Destroy(other.gameObject);
            gameManager.RestartLevel();
        }
    }
}
