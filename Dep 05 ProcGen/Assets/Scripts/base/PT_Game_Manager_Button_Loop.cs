using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PT_Game_Manager_Button_Loop : MonoBehaviour {

    public Text tx_Main_Text;
    public Button bt_Next;
    public Button bt_Previous;
    public GameObject textPanel;

    public Canvas textInterface;
    public Canvas joystickInterface;

    public bool showSceneButtons = true;
    public bool showTextPanel = true;
    public bool showTextInterface = true;
    public bool showJoystickInterface = true;


    private PT_Level_Data sc_current_loaded_level;
    
	// Use this for initialization
	void Start () {
        // Ensure this object never gets destroyed when loading other scenes
        DontDestroyOnLoad(transform.gameObject);

        //Check resolution and resize panel and reposition 

    }

    // Update is called once per frame
    void Update() {
        //Disable previous first level
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            bt_Previous.interactable = false;
        }
        else
        {
            bt_Previous.interactable = true;
        }

        //Disabler next when this is last level
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            bt_Next.interactable = false;
        }
        else
        {
            bt_Next.interactable = true;
        }
           
    }

    public void OnCLickPrevious()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            // Load the scene with the next index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    public void OnCLickNext()
    {
        
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Load the scene with the next index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RegisterLevel(PT_Level_Data _sc_current_level)
    {

        sc_current_loaded_level = _sc_current_level;
        tx_Main_Text.text = sc_current_loaded_level.str_level_text;

    }

    public void ShowText(string _str_message)
    {
        tx_Main_Text.text = _str_message;
    }

    public void OnMenu(bool valueOfToggle)
    {
        print("All Change" + valueOfToggle);
        //textInterface.gameObject.SetActive(valueOfToggle);
        //showTextInterface = valueOfToggle;
        showTextPanel = valueOfToggle;
        showSceneButtons = valueOfToggle;

        textPanel.SetActive(showTextPanel);
        bt_Next.gameObject.SetActive(showSceneButtons);
        bt_Previous.gameObject.SetActive(showSceneButtons);
    }
}
