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
    public Text BPMInput;


    // Start is called before the first frame update
    void Start()
    {
        TickScript01.OnCoTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            rawTick++;
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
        fullString = "Current Raw Tick (coroutine): " + ticker.rawTick.ToString() + "Current Beat: " + ticker.rawBeat.ToString() + "Current Bar: " + ticker.rawBar.ToString();
        fullText.text = fullString;
        BPMText.text = "BPM: " + ticker.beatPerMinute.ToString();
    }
    public void setBPM()
    {
        ticker.setBPM(int.Parse(BPMInput.text));
    }
}
