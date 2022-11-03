using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Resource01;
    public int Resource02;
    public int Resource03;
    public int Resource04;
    public int Resource05;

    public Image ResourceBar01;
    public Image ResourceBar02;
    public Image ResourceBar03;
    public Image ResourceBar04;
    public Image ResourceBar05;

    public Text MainBodyText;

    public Text ChoiceOneText;
    public Text ChoiceTwoText;


    public List<EventTemplate> eventList;


    private bool eventSet;
    private bool showAfter;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEventList();
    }

    // Update is called once per frame
    void Update()
    {
        ResourceBar01.fillAmount = Resource01 / 100.00f;
        ResourceBar02.fillAmount = Resource02 / 100.00f;
        ResourceBar03.fillAmount = Resource03 / 100f;
        ResourceBar04.fillAmount = Resource04 / 100f;
        ResourceBar05.fillAmount = Resource05 / 100f;

        if (eventSet && showAfter)
        {
            ShowEventAftermath();

        //hide button 1
        //change button 2 to ok

        }

        if (!eventSet)
        {
            ShowEventData();
            eventSet = true;
        }

    }

    public void GenerateEventList()
    {
        //Grab the deck from somewhere and shuffle the contents into the list on the manager

    }

    public void ShowEventData()
    {
        MainBodyText.text = eventList[0].Description;
        ChoiceOneText.text = eventList[0].Choice01;
        ChoiceTwoText.text = eventList[0].Choice02;

    }

    public void ShowEventAftermath()
    {

    }

    public void ShowEndingAftermath()
    {

    }


    public void ChooseOne()
    {
        if(eventSet && !showAfter)
        {
            //do choice 1

            showAfter = true;

        }else if(eventSet && showAfter)
        {
            // this is hidden
        }
    }
    public void ChooseTwo()
    {
        if (eventSet && !showAfter)
        {
            //do choice 2
        }
        else if (eventSet && showAfter)
        {
            // this is currently an ok button


            //delete 
            showAfter = false;
            eventSet = false;


        }
    }
}
