using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class PT_LevelManager : MonoBehaviour {

    public Transform lastGoodCheckpoint;
    public PT_CC_W_PowerUps playerCharConrol;

    public Canvas infoBar;
    public Canvas messageBox;

    public Text messageTextonScreen;
    public Text statusText;
    public float timeOnScreen = 2.5f;

    public string LevelName;
    public bool includetimerCount;

    private float timeComplete = 0;

    private int hours;
    private int minutes;
    private int seconds;

    private bool timerRunning;
    private float timerStart;
    private float timerEnd;
    private bool countDown;
    private int timerHours;
    private int timerMinutes;
    private int timerSeconds;

    private string date;
    private string statusMessage;

    public float incrementScore = 0.2f;
    public int score = 0;
    private float tick;

    // Use this for initialization
    void Start () {
        timerHours = 0;
        timerMinutes = 0;
        timerSeconds = 0;
        timerRunning = false;
        countDown = false;
        tick = Time.time + incrementScore;

    }
	
	// Update is called once per frame
	void Update () {
        if(tick< Time.time && timerRunning)
        {
            score++;
            tick = Time.time + incrementScore;
        }

        if (countDown && (timerEnd - Time.time)<=0)
        {
            // time to die
            playerCharConrol.FallToDeath();
            countDown = false;

        }


        if (timeComplete < Time.time)
        {
            if (messageTextonScreen != null)
            {
                messageBox.gameObject.SetActive(false);
            }
        }
        //timer test with key press
        if (Input.GetKeyUp("l"))
        {
            //print("l pressed");
            if (timerRunning)
            {
                EndTimer();
            }
            else
            {
                StartTimer(0f);
            }
        }
        ComposeStatus();

    }

    public void ShowMessage(string currentMessage)
    {
        if (messageTextonScreen != null)
        {
            messageTextonScreen.text = currentMessage;
            messageBox.gameObject.SetActive(true);
            timeComplete = Time.time + timeOnScreen;
        }
    }


    public void ComposeStatus()
    {
        //date time stuff
        var culture = new CultureInfo("en-GB");
        date = System.DateTime.Now.ToString(culture);
        float timeSoFar = 0; 

        //
        if (timerRunning)
        {
            if (countDown)
            {
                timeSoFar = timerEnd - Time.time;
            }
            else
            {
                timeSoFar = Time.time - timerStart;
            }
            
            //print("Timer " + timeSoFar);
            timerHours = Mathf.FloorToInt(timeSoFar/3600f);
            timerMinutes = Mathf.FloorToInt((timeSoFar%3600f)/60);
            timerSeconds = Mathf.FloorToInt((timeSoFar % 3600f) % 60);
        }
        string timer = timerHours.ToString().PadLeft(2,'0') + ":" + timerMinutes.ToString().PadLeft(2, '0') + ":" + timerSeconds.ToString().PadLeft(2, '0') + " ";
        string tween = "";
        if (includetimerCount)
        {
            statusText.text = timer.PadRight(30) + timeSoFar.ToString().PadRight(35) + "Score: " + score.ToString().PadRight(10) +  LevelName.PadRight(60) + date;
        }
        else
        {
            statusText.text = timer.PadRight(30) + tween.ToString().PadRight(35) + "Score: " + score.ToString().PadRight(10) + LevelName.PadRight(60) + date;
        }
        

    }

    public void StartTimer(float timerLength)
    {
        timerStart = Time.time;
        if (timerLength>0f)
        {
            countDown = true;
            timerEnd = Time.time + timerLength;
        }
        tick = Time.time + incrementScore;
        score = 0;
        timerRunning = true;
    }

    public void EndTimer()
    {
        timerHours = 0;
        timerMinutes = 0;
        timerSeconds = 0;
        timerRunning = false;
        countDown = false;
    }

    public void BonusTime(float timeValue)
    {
        if (countDown)
        {
            timerEnd += timeValue;
        }
    }
}
