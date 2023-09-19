using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Exit : MonoBehaviour {
    private PT_Basic_GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PT_Basic_GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.score += 20;
            gameManager.LoadNextLevel();
            gameObject.SetActive(false);
            other.gameObject.transform.position = new Vector3(-10, -10, 0);
        }
    }

}
