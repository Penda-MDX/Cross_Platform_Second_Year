using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTickText : MonoBehaviour
{
    private int rawTick = 0;
    private int poorTick = 0;

    public Text tickText;
    public Text poorText;

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
    }
}
