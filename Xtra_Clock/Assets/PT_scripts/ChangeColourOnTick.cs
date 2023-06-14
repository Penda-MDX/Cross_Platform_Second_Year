using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColourOnTick : MonoBehaviour
{
    private Image imageRenderer;
    public Sprite onSprite;
    public Sprite offSprite;

    public int tickinBeat;
    public TickScript01 ticker;
    public int offset = 10;
    

    private bool onFlag;
    // Start is called before the first frame update
    void Start()
    {

        imageRenderer = gameObject.GetComponent<Image>();
        TickScript01.OnCoTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            if (ticker.usingCoroutine)
            {
                switchColor(e.currentTick);
            }
            
        };

        TickScript01.OnUTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            if (!ticker.usingCoroutine)
            {
                switchColor(e.currentTick);
            }

        };


    }

    private void switchColor(int tick)
    {
        if (tick % ticker.ticksPerBeat == tickinBeat)
        {
            onFlag = true;
            imageRenderer.sprite = onSprite;

        }

        if(onFlag && (tick % ticker.ticksPerBeat >= tickinBeat + offset))
        {
            if (onFlag)
            {
                onFlag = false;
                imageRenderer.sprite = offSprite;

            }
                
        }
    }

}
