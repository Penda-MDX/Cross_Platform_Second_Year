using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColourOnTick : MonoBehaviour
{
    private Image imageRenderer;
    public Sprite onSprite;
    public Sprite offSprite;

    public int tickRate;


    private bool onFlag;
    // Start is called before the first frame update
    void Start()
    {
        imageRenderer = gameObject.GetComponent<Image>();
        TickScript01.OnCoTick += delegate (object sender, TickScript01.OnTickEventArgs e)
        {
            switchColor(e.currentTick);
        };
    }

    private void switchColor(int tick)
    {
        if (tick % tickRate == 0)
        {
            onFlag = !onFlag;
            if (onFlag)
            {
                imageRenderer.sprite = onSprite;
            }
            else
            {
                imageRenderer.sprite = offSprite;
            }
        }
    }

}
