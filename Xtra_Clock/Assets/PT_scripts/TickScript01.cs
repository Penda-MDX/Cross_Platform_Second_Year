using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TickScript01 : MonoBehaviour
{
    public float beatPerMinute = 60f;
    public float ticksPerBeat = 480f;
    public int rawTick = 0;
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
        setTick();

    }

    public void setTick()
    {
        secondsPerTick = 60 / (ticksPerBeat * beatPerMinute);
        nextTime = Time.time + secondsPerTick;
        rawTick = 0;
        poorTick = 0;
        coR = StartCoroutine(TickCounter(secondsPerTick));
    }

    private IEnumerator TickCounter(float waitTime)
    {
        while (true)
        {
            rawTick++;
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


        while (Time.time > nextTime)
        {
            poorTick++;
            nextTime = nextTime + secondsPerTick;
            if (OnUTick != null)
            {
                OnUTick(this, new OnTickEventArgs { currentTick = poorTick });
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StopCoroutine(coR);
            setTick();
        }


    }
}
