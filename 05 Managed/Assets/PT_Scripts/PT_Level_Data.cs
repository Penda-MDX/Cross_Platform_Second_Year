using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Level_Data : MonoBehaviour {

    public string str_level_text;
    public float levelSpeed = 3.0f;

 
    private PT_Game_Manager_Button_Loop sc_game_manager;

	// Use this for initialization
	void Start () {
        if (GameObject.Find("GameManager") != null)
        {
            sc_game_manager = GameObject.Find("GameManager").GetComponent<PT_Game_Manager_Button_Loop>();
            sc_game_manager.RegisterLevel(this);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit_Level()
    {
       // print("ld_call");
        sc_game_manager.OnCLickNext();
    }
}
