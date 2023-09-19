using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_Time_Consumer : MonoBehaviour
{
    public Text TimeText;


    // Start is called before the first frame update
    void Start()
    {
        PT_timing_system.OnTick += delegate (object sender, PT_timing_system.OnTickEventArgs e)
        {
            TimeText.text = "Tick: " + e.tick;
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
