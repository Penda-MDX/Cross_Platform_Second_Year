using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_asteroids_game_manager : MonoBehaviour {

    //---------------------------------------------------------------------------------------
    public int in_lives;
    public int in_score;
    public bool bl_level_complete;
    
    public GameObject GO_player_ship_prefab;

    private GameObject go_current_player_ship;

    private Text text_lives;
    private Text text_score;
    private Text text_message;
    private GameObject GO_message_panel;
    private bool bl_respawn = true;
    private int in_remaining_asteroids;

    private int in_current_level_number = 1;

    //Level data - Name, 
    private 

    //---------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Ensure this object never gets destroyed when loading other scenes
        DontDestroyOnLoad(transform.gameObject);

        // Find the text panels
        text_lives = GameObject.Find("Lives_Text").GetComponent<Text>();
        text_score = GameObject.Find("Score_Text").GetComponent<Text>();

        if (go_current_player_ship == null)
        {
            go_current_player_ship = Instantiate(GO_player_ship_prefab);
            bl_respawn = false;

        }
    //    text_message = GameObject.Find("Message_Text").GetComponent<Text>();
    //   GO_message_panel = GameObject.Find("Message_Panel");
    }//-----


    // Update is called once per frame
    void Update () {
        UpdateUI();
        ShowMessage();
        CheckRespawnPlayerShip();
    }

    void UpdateUI()
    {
        text_lives.text = "Lives: " + in_lives.ToString();
        //maybe pad to 6+ figures
        text_score.text = "Score: " + in_score.ToString();
        Debug.Log("Score: " + in_score.ToString());
    }

    void ShowMessage()
    {

    }

    void InitialiseGame()
    {
        //reset lives to 3 

        //load up data for all levels?

        //create current level data handler? and populate

    }

    public void StartLevel()
    {
        //get the next level

    }

    void CheckLevelComplete()
    {
        if (in_remaining_asteroids <= 0)
        {
            //where do I get new level data from?

            //increment current level 
            in_current_level_number++;

            //set the level data

            //trigger end of level message and delay

        }
    }

    void CheckRespawnPlayerShip()
    {
        if (in_lives > 0 && bl_respawn)
        {
            go_current_player_ship = Instantiate(GO_player_ship_prefab);
            bl_respawn = false;
        }
        else
        {
            //Go back to start

        }
    }

    public void PlayerShipDeath()
    {
        //Debug.Log("Death");
        in_lives--;
        bl_respawn = true;
    }
}
