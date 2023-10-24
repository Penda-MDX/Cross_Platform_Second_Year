using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTickText : MonoBehaviour
{
    private int rawTick = 0;
    private int poorTick = 0;

    public TickScript01 ticker;
    public Text tickText;
    public Text fullText;
    public Text poorText;
    public string fullString;
    public Text BPMText;
    public Text timeText;
    public Text BPMInput;
    //public bool usingCoroutine = true;
    public Toggle useCoToggle;

    // Start is called before the first frame update
    void Start()
    {
        TickScript01.OnCoTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            rawTick = e.currentTick;
        };

        TickScript01.OnUTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            poorTick = e.currentTick;
        };
    }

    // Update is called once per frame
    void Update()
    {
        tickText.text = "Current Raw Tick (coroutine): " + rawTick.ToString();
        poorText.text = "Poor Tick (update loop): " + poorTick.ToString();
        if (ticker.usingCoroutine)
        {
            fullString = "Current Raw Tick (coroutine): " + ticker.rawTick.ToString() + " Current Beat: " + ticker.rawBeat.ToString() + " Current Bar: " + ticker.rawBar.ToString();
        }
        else
        {
            int uTickBeat = poorTick / ticker.ticksPerBeat;
            int uTickBar = poorTick / (ticker.ticksPerBeat * ticker.beatsInBar);
            fullString = "Current Raw Tick (Update): " + poorTick.ToString() + " Current Beat: " + uTickBeat.ToString() + " Current Bar: " + uTickBar.ToString();
        }
        
        fullText.text = fullString;
        BPMText.text = "BPM: " + ticker.beatPerMinute.ToString();

        float tMinutes = Mathf.Floor(ticker.timeSince / 60);
        float tSeconds = Mathf.Floor(ticker.timeSince % 60);
        float tMilliSeconds = Mathf.Floor((ticker.timeSince*1000) % 1000);
        timeText.text = "Seconds since reset: " + tMinutes.ToString() + " Minutes " + tSeconds + " Seconds " + tMilliSeconds + " ms";
    }
    public void setBPM()
    {
        ticker.setBPM(int.Parse(BPMInput.text));
    }

    public void setUseCoroutine()
    {

        ticker.usingCoroutine = useCoToggle.isOn;
    }
}
