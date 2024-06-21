using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenuManager : MonoBehaviour
{
    public bool menuOn;
    public Canvas inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuOn)
            {
                inGameMenu.gameObject.SetActive(true);
                menuOn = true;
            }
            else
            {
                inGameMenu.gameObject.SetActive(false);
                menuOn = false;
            }
            
        }
    }

    public void InGameMenuButton(int choice)
    {
        Debug.Log("Menu Button");
        switch (choice)
        {
            case 1:
                SceneManager.LoadScene("Main_Menu");
                Debug.Log("One Clicked");
                break;
            case 2:
                inGameMenu.gameObject.SetActive(false);
                menuOn = false;
                break;
            default:
                break;
        }
    }

}
