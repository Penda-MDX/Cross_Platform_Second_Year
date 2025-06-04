using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private GameManager GameManagerObject;
    //private SceneManager sceneManager;
    public string gameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        //singleton grab for GM

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameButton()
    {
        //send to GameManager to set the gamestate objects (e.g. location, map, relationships) to the starting state

        //start the game
        SceneManager.LoadScene(gameSceneName);
    }

    public void ContinueGameButton()
    {
        //offer the option to pick continue slot?

        //start game
        SceneManager.LoadScene(gameSceneName);
    }

    public void OptionsButton()
    {
        //activate Options canvas
    }

    public void ExitOptions()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
