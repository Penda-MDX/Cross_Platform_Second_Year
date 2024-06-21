using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButton(int choice)
    {
        switch(choice){
            case 1:
                SceneManager.LoadScene("Hub_Screen");
                break;
            case 2:
                SceneManager.LoadScene("Level01");
                break;
            case 3:
                SceneManager.LoadScene("Level02");
                break;
            case 4:
                SceneManager.LoadScene("Level03");
                break;
            case 5:
                SceneManager.LoadScene("Level04");
                break;
            case 6:
                //SceneManager.LoadScene("Level05");
                break;
            default:
                break;
        }
    }

}
