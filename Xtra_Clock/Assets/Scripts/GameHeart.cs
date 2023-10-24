using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHeart : MonoBehaviour
{
    public int heartTick = 0;
    public float timeSince;
    public bool usingCoroutine = true;

    public float updatedTickTime = 0.2f;

    private float secondsPerTick;
    public float SecondsPerTick
    {
        get { return secondsPerTick; }
        set { secondsPerTick = value; }
    }
    
    
    private bool clockRunning = false;

    public class OnTickEventArgs : EventArgs
    {
        public int currentTick;
    }

    public static event EventHandler<OnTickEventArgs> OnheartTick;



    private float nextTime;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        //setTick();

    }

    public void setTick()
    {
        startTime = Time.time;
        nextTime = Time.time + secondsPerTick;
        heartTick = 0;
        clockRunning = true;
    }

    public void startTick()
    {
        setTick();
    }

    public void stopTick()
    {
        clockRunning = false;
        heartTick = 0;
    }


    // Update is called once per frame
    void Update()
    {

        if (secondsPerTick > 0 && nextTime > 0)
        {
            if (clockRunning)
            {
                while (Time.time > nextTime)
                {
                    heartTick++;
                    nextTime = nextTime + secondsPerTick;
                    if (OnheartTick != null)
                    {
                        OnheartTick(this, new OnTickEventArgs { currentTick = heartTick });
                    }
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.R))
        {
           
            setTick();
        }
        timeSince = Time.time - startTime;

    }

}
