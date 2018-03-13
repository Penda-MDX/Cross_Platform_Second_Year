using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_Basic_GameManager : MonoBehaviour {

    public PT_2D_Map_Builder MapManager;
    public string[] levelsData;
    public int currentLevelIndex = 0;

    public int maxLevelIndex;
    public int score;
    public int deaths;

    public Text scoreText;
    public Text deathstext;
    public Text levelText;
    public Text winText;

    // Use this for initialization
    void Start () {
        MapManager.rawMapData = levelsData[currentLevelIndex];
        MapManager.ReloadMap();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("x"))
        {
            currentLevelIndex = 0;
            MapManager.rawMapData = levelsData[currentLevelIndex];
            MapManager.ReloadMap();
            winText.gameObject.SetActive(false);
        }
        int tmpLevel = currentLevelIndex + 1;
        scoreText.text = "Score: " + score.ToString();
        deathstext.text = "Died: " + deaths.ToString();
        levelText.text = "Level: " + tmpLevel.ToString();
    }

    public void LoadNextLevel()
    {
        if((currentLevelIndex + 1) < levelsData.Length)
        {
            currentLevelIndex++;
            print("currentlevelIndex: " + currentLevelIndex.ToString());
            MapManager.rawMapData = levelsData[currentLevelIndex];
            MapManager.ReloadMap();
        }
        else
        {
            winText.gameObject.SetActive(true);
        }
    }
    public void RestartLevel()
    {
        MapManager.ReloadMap();
    }
}
