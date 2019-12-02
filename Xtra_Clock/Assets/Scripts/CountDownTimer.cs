using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    public Canvas messageBox;

    public Text messageTextonScreen;
    public Text statusText;
    /*
    [System.Serializable]
    public struct DateTime : IComparable, IComparable<DateTime>, IConvertible, IEquatable<DateTime>, IFormattable, System.Runtime.Serialization.ISerializable
    */
    public String FinishDateTime = "20080501T08:30:52Z";
    private DateTime endDateTime; 

    public bool includetimerCount;

    private float timeComplete = 0;

    private int hours;
    private int minutes;
    private int seconds;

    private bool timerRunning;
    private float timerStart;
    private float timerEnd;
    public bool countDown;
    private int timerDays;
    private int timerHours;
    private int timerMinutes;
    private int timerSeconds;

    private string dateNow;
    private string statusMessage;

    // Start is called before the first frame update
    void Start()
    {
        endDateTime = DateTime.ParseExact(FinishDateTime, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture);
        print("Date Time: " + endDateTime.ToString());
        if (countDown)
        {
            timerRunning = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        ComposeStatus();
    }


    public void ComposeStatus()
    {
        //date time stuff
        var culture = new CultureInfo("en-GB");
        dateNow = System.DateTime.Now.ToString(culture);
        float timeSoFar = 0;

        //
        if (timerRunning)
        {
            if (countDown)
            {
                DateTime currentDateTime = DateTime.Now;
                TimeSpan temp = endDateTime.Subtract(currentDateTime);
                timerEnd = (float)temp.TotalSeconds;
                print("Second Left: " + timerEnd);
                timeSoFar = timerEnd;
            }
            else
            {
                timeSoFar = Time.time - timerStart;
            }

            //print("Timer " + timeSoFar);
            timerDays = Mathf.FloorToInt(timeSoFar / 86400f);
            timerHours = Mathf.FloorToInt((timeSoFar % 86400f) / 3600f);
            timerMinutes = Mathf.FloorToInt((timeSoFar % 3600f) / 60);
            timerSeconds = Mathf.FloorToInt((timeSoFar % 3600f) % 60);
        }
        string timer = timerDays.ToString().PadLeft(2, '0') + " Days " + timerHours.ToString().PadLeft(2, '0') + ":" + timerMinutes.ToString().PadLeft(2, '0') + ":" + timerSeconds.ToString().PadLeft(2, '0') + " ";
        string tween = " to " + endDateTime.ToString();
        if (includetimerCount)
        {
            statusText.text = timer.PadRight(30) + timeSoFar.ToString().PadRight(35);
        }
        else
        {
            statusText.text = timer + tween;

        }


    }
}
