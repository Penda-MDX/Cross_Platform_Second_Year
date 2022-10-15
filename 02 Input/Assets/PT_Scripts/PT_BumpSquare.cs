using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_BumpSquare : MonoBehaviour
{
    public AudioSource beeper;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "touch")
        {
            Handheld.Vibrate();
            if(!beeper.isPlaying)
            {
                beeper.Play();
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "touch")
        {
            Handheld.Vibrate();

            if (!beeper.isPlaying)
            {
                beeper.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "touch")
        {

            if (beeper.isPlaying)
            {
                beeper.Stop();
            }
            
        }
    }
}
