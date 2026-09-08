using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_level_data_handler : MonoBehaviour {

    public int in_lives = 3;
    public int in_asteroids = 5;
    public string str_level_name = "";

    private PT_asteroids_game_manager mb_gamemanager;

    void Start()
    {
        mb_gamemanager = GameObject.Find("Asteroids Game_Manager").GetComponent<PT_asteroids_game_manager>();
        mb_gamemanager.in_lives = in_lives;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
