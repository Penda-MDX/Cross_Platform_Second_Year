using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickScript01 : MonoBehaviour
{
    public int beatPerMinute = 60;
    public int ticksPerBeat = 480;
    public int beatsInBar = 4;
    public int rawTick = 0;
    public int rawTickInBeat = 0;
    public int rawTickInBar = 0;
    public int rawBeat = 0;
    public int rawBar = 0;
    public int poorTick = 0;

    public float secondsPerTick;
    public Coroutine coR;

    public class OnTickEventArgs : EventArgs
    {
        public int currentTick;
    }

    public static event EventHandler<OnTickEventArgs> OnCoTick;
    public static event EventHandler<OnTickEventArgs> OnUTick;



    private float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        //setTick();

    }

    public void setTick()
    {
        secondsPerTick = 60f / (ticksPerBeat * beatPerMinute);
        nextTime = Time.time + secondsPerTick;
        rawTick = 0;
        poorTick = 0;
        coR = StartCoroutine(TickCounter(secondsPerTick));
    }
    public void startTick()
    {
        if (coR != null)
        {
            StopCoroutine(coR);
        }
        setTick();
    }

    public void stopTick()
    {
        StopCoroutine(coR);
    }

    public void setBPM(int newIntBPM)
    {
        Debug.Log("Set New BPM to " + newIntBPM.ToString());
        if (newIntBPM != 0)
        {
            beatPerMinute = newIntBPM;
            if (coR != null)
            {
                StopCoroutine(coR);
            }
            setTick();
        }
    }

    private IEnumerator TickCounter(float waitTime)
    {
        while (true)
        {
            rawTick++;
            rawTickInBeat = rawTick%ticksPerBeat;
            rawTickInBar = rawTick % (ticksPerBeat * beatsInBar);

            if (OnCoTick != null)
            {
                OnCoTick(this, new OnTickEventArgs { currentTick = rawTick });
            }
            yield return new WaitForSeconds(waitTime);
        }

    }
    // Update is called once per frame
    void Update()
    {

        if(secondsPerTick>0 && nextTime> 0)
        {
            while (Time.time > nextTime)
            {
                poorTick++;
                nextTime = nextTime + secondsPerTick;
                if (OnUTick != null)
                {
                    OnUTick(this, new OnTickEventArgs { currentTick = poorTick });
                }
            }
        }
        rawBeat = rawTick / ticksPerBeat;
        rawBar = rawTick / (ticksPerBeat * beatsInBar);

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopCoroutine(coR);
            setTick();
        }


    }


}
