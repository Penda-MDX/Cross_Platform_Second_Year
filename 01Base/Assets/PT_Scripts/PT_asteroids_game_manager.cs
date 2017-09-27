using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_asteroids_game_manager : MonoBehaviour {

    //---------------------------------------------------------------------------------------
    public static int in_lives;
    public static int in_score;
    public static bool bl_level_complete;

    public GameObject GO_player_ship_prefab;

    private GameObject go_current_player_ship;

    private Text text_lives;
    private Text text_score;
    private Text text_message;
    private GameObject GO_message_panel;
    //---------------------------------------------------------------------------------------
    // Use this for initialization
    void Start()
    {
        // Ensure this object never gets destroyed when loading other scenes
        DontDestroyOnLoad(transform.gameObject);

        // Find the text panels
        text_lives = GameObject.Find("Lives_Text").GetComponent<Text>();
        text_score = GameObject.Find("Score_Text").GetComponent<Text>();
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
    }

    void ShowMessage()
    {

    }

    void CheckRespawnPlayerShip()
    {
        if (in_lives > 0 || go_current_player_ship==null)
        {
            go_current_player_ship = Instantiate(GO_player_ship_prefab);
        }
        else
        {
            //Go back to start

        }
    }
}
