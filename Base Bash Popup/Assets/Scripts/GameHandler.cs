using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VolumeComponent;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance { get; private set; }
    [SerializeField] private int ActivateTime = 4;
    [SerializeField] private int TimeToContent = 6;
    [SerializeField] private List<PopUp> PopUps;
    [SerializeField] private float BigTicksTime = 1.0f;
    [SerializeField] private float LittleTicksTime = 0.25f;
    [SerializeField] private float GoodOccurance = 0.25f;
    [SerializeField] private float EndPause = 3.25f;

    [SerializeField] private int InitialActivate = 4;
    [SerializeField] private int NewActivateEvery = 16;

    private int Score = 0;
    private int Lives = 3;

    private bool startUp = true;
    private bool paused = false;
    private bool GameEndStart = false;
    private float GameEndWait = 0.0f;
    private int BigTickCount = 0;
    private int LittleTickCount = 0;
    private float BigTickNext;
    private float LittleTickNext;
    public event EventHandler BigTick;
    public event EventHandler LittleTick;
    public event EventHandler ScoreChanged;
    public event EventHandler LivesChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one GameHandler! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BigTickNext = Time.time + BigTicksTime;
        LittleTickNext = Time.time + LittleTicksTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startUp)
        {
            for(int count = 0; count < InitialActivate; count++)
            {
                Debug.Log("Activate Starter");
                ActivateRandomPopup();
            }
            startUp = false;
        }
        if (!paused)
        {
            CheckTicks();
        }
        if (GameEndStart && GameEndWait<Time.time)
        {
            SceneManager.LoadScene(0);
        }


    }

    private void CheckTicks()
    {
        if (Time.time > BigTickNext)
        {
            BigTickCount++;
            BigTick?.Invoke(this, EventArgs.Empty);
            BigTickNext = Time.time + BigTicksTime;

            if (BigTickCount % ActivateTime == 0)
            {
                StartNextPopup();
            }
            if (BigTickCount % NewActivateEvery == 0)
            {
                ActivateRandomPopup();
            }
        }

        if (Time.time > LittleTickNext)
        {
            LittleTickCount++;
            LittleTick?.Invoke(this, EventArgs.Empty);
            LittleTickNext = Time.time + LittleTicksTime;
        }
    }

    private void ActivateRandomPopup()
    {
        int indexNo = UnityEngine.Random.Range(0, PopUps.Count - 1);
        int countUp = 0;
        while(!PopUps[indexNo].IsDeactivated())
        {
            indexNo = UnityEngine.Random.Range(0, PopUps.Count - 1);
            countUp++;
            if(countUp>=PopUps.Count)
            {
                return;
            }

        }
        PopUps[indexNo].Activate();
    }
    private void StartNextPopup()
    {
        
        int indexNo = UnityEngine.Random.Range(0, PopUps.Count - 1);
        string nextType = "";

        if (UnityEngine.Random.Range(0.0f, 1.0f) <= GoodOccurance)
        {
            nextType = "GoodPop";
        }
        else
        {
            nextType = "BadPop";
        }
        int countUp = 0;
        while (PopUps[indexNo].CanBeActivated() == false)
        {
            countUp++;
            indexNo = UnityEngine.Random.Range(0, PopUps.Count - 1);
            if (countUp >= PopUps.Count)
            {
                Debug.Log("No Activatable PopUps");
                return;
            }
        }
        PopUps[indexNo].ActivateAs(nextType, TimeToContent);

    }

    public void RegisterPopUp(PopUp newAddition)
    {
        PopUps.Add(newAddition);
    }

    public int GetScore()
    {
        return Score;
    }

    public int GetLives()
    {
        return Lives;
    }

    public void PopupHit(string PopupType)
    {
        switch (PopupType)
        {
            case "BadPop":
                Score += 50;
                ScoreChanged?.Invoke(this, EventArgs.Empty);
                break;
            case "GoodPop":
                LoseLife();
                break;
        }
    }

    public void MissedOne()
    {
        //Debug.Log("Missed One");
        LoseLife();
    }

    private void LoseLife()
    {
        Lives--;
        LivesChanged?.Invoke(this, EventArgs.Empty);
        if (Lives <= 0)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        Debug.Log("Game Over!");
        paused = true;
        UIHandler.Instance.GameOver();
        GameEndStart = true;
        GameEndWait = Time.time + EndPause;
    }
}
