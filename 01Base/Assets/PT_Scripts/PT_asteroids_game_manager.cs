using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_asteroids_game_manager : MonoBehaviour {

    //---------------------------------------------------------------------------------------
    public int in_lives;
    public int in_score;
    public bool bl_level_complete;
    public int in_starting_asteroids;
    //added for flipped controls
    public int in_flip_glob = 1;
    
    public GameObject GO_player_ship_prefab;

    private GameObject go_current_player_ship;

    public GameObject GO_asteroid;

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

        if(Input.GetKeyUp("r"))
        {
            InitialiseGame();
        }

        if(Input.GetButton("Submit"))
        {
            InitialiseGame();
        }

        if (Input.GetKeyUp("k"))
        {
            in_flip_glob *= -1;
        }
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

        GameObject[] CurrentAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroidal in CurrentAsteroids)
        {
            Destroy(asteroidal);
        }

        Destroy(go_current_player_ship);

        //reset lives to 3 
        in_lives = 3;
        bl_respawn = true;
        //load up data for all levels?
        in_remaining_asteroids = in_starting_asteroids;

 
        //create current level data handler? and populate
        SpawnNewAsteroids(in_starting_asteroids);

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

    void SpawnNewAsteroids(int NumberofAsteroids)
    {
        for(int i = 1; i<=NumberofAsteroids;i++)
        {
            Vector3 spawnV3 = Vector3.zero;

            if (Random.Range(-1, 1) > 0)
            {
                spawnV3.x = Random.Range(2, 8);
            }
            else
            {
                spawnV3.x = Random.Range(-8, -2);
            }

            if (Random.Range(-1, 1) > 0)
            {
                spawnV3.y = Random.Range(2, 8);
            }
            else
            {
                spawnV3.y = Random.Range(-8, -2);
            }
            Debug.Log(spawnV3);
            Instantiate(GO_asteroid,spawnV3, Quaternion.identity);
        }
    }

    public void PlayerShipDeath()
    {
        //Debug.Log("Death");
        in_lives--;
        bl_respawn = true;
    }
}
