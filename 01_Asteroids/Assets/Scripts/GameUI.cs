using System;
using TMPro;
using UnityEngine;
public class GameUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    private GameObject mainMenu;

    private GameObject pauseMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
        GameManager.Instance.OnDeath += GameManager_OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameManager_OnScoreChanged(object sender, EventArgs e)
    {
        UpdateScore();
    }

    private void GameManager_OnDeath(object sender, EventArgs e)
    {
        UpdateLives();
    }


    private void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }

    private void UpdateLives()
    {
        livesText.text = "Lives: " + GameManager.Instance.GetLives().ToString();
    }

}
