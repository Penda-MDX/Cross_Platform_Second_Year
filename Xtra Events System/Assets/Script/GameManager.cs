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

    public string Resource01Name;
    public string Resource02Name;
    public string Resource03Name;
    public string Resource04Name;
    public string Resource05Name;

    public string Resource01Zero;
    public string Resource02Zero;
    public string Resource03Zero;
    public string Resource04Zero;
    public string Resource05Zero;

    public string Resource01Hundred;
    public string Resource02Hundred;
    public string Resource03Hundred;
    public string Resource04Hundred;
    public string Resource05Hundred;

    public Image ResourceBar01;
    public Image ResourceBar02;
    public Image ResourceBar03;
    public Image ResourceBar04;
    public Image ResourceBar05;
    public Text ResourceBar01Text;
    public Text ResourceBar02Text;
    public Text ResourceBar03Text;
    public Text ResourceBar04Text;
    public Text ResourceBar05Text;

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
        
        ResourceBar01Text.text = Resource01Name;
        ResourceBar02Text.text = Resource02Name;
        ResourceBar03Text.text = Resource03Name;
        ResourceBar04Text.text = Resource04Name;
        ResourceBar05Text.text = Resource05Name;
        
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

    public bool EndGameCheck()
    {
        if(Resource01 <= 0)
        {
            //MainBodyText.text = Resource01Zero;

            return true;
        }
        if(Resource02 <= 0)
        {
            //MainBodyText.text = Resource02Zero;
            return true;
        }
        if(Resource03 <= 0)
        {
            //MainBodyText.text = Resource03Zero;
            return true;
        }
        if(Resource04 <= 0)
        {
            //MainBodyText.text = Resource04Zero;
            return true;
        }
        if(Resource05 <= 0)
        {
            //MainBodyText.text = Resource05Zero;
            return true;
        }


        if (Resource01 >= 100)
        {
            //MainBodyText.text = Resource01Hundred;
            return true;
        }
        if(Resource02 >= 100)
        {
            //MainBodyText.text = Resource02Hundred;
            return true;
        }
        if(Resource03 >= 100)
        {
            //MainBodyText.text = Resource03Hundred;
            return true;
        }
        if(Resource04 >= 100)
        {
            //MainBodyText.text = Resource04Hundred;
            return true;
        }
        if(Resource05 >= 100)
        {
            //MainBodyText.text = Resource05Hundred;
            return true;
        }

        return false;
    }
}
