using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DeckTemplate starterDeck;

    public List<DeckTemplate> availableDecks;

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

    public string path;

    private bool eventSet;
    private bool showAfter;
    private bool endGame;
    private string OutcomeText;
    private string EndingText;

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

        if (EndGameCheck()|| endGame)
        {
            endGame = true;
            showAfter = true;
            eventSet = true;
            MainBodyText.text = EndingText;
        }

    }

    public void GenerateEventList()
    {
        //reset the flags
        endGame = false;
        showAfter = false;
        eventSet = false;
        //Grab the deck from somewhere and shuffle the contents into the list on the manager
        //
        //eventList = starterDeck.EventDeck;
        foreach (EventTemplate eventCard in starterDeck.EventDeck)
        {
            eventList.Add(eventCard);
        }

        //shuffle
        shuffleEventList();

    }

    public void ShowEventData()
    {
        if (eventList.Count < 1)
        {
            EndingText = "No More Cards!";
            endGame = true;
        }
        else
        {
            ChoiceOneText.transform.parent.gameObject.SetActive(true);
            MainBodyText.text = eventList[0].Description;
            ChoiceOneText.text = eventList[0].Choice01;
            ChoiceTwoText.text = eventList[0].Choice02;
        }
    }

    public void ShowEventAftermath()
    {
        MainBodyText.text = OutcomeText;
        ChoiceTwoText.text = "OK";
        ChoiceOneText.transform.parent.gameObject.SetActive(false);


    }

    public void ShowEndingAftermath()
    {

    }


    public void ChooseOne()
    {
        if(eventSet && !showAfter)
        {
            //do choice 1


            Resource01 += eventList[0].Resource01_C01;
            Resource02 += eventList[0].Resource02_C01;
            Resource03 += eventList[0].Resource03_C01;
            Resource04 += eventList[0].Resource04_C01;
            Resource05 += eventList[0].Resource05_C01;

            OutcomeText = eventList[0].Choice01_Outcome;

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
            Resource01 += eventList[0].Resource01_C02;
            Resource02 += eventList[0].Resource02_C02;
            Resource03 += eventList[0].Resource03_C02;
            Resource04 += eventList[0].Resource04_C02;
            Resource05 += eventList[0].Resource05_C02;
            OutcomeText = eventList[0].Choice02_Outcome;
            showAfter = true;

        }
        else if (eventSet && showAfter)
        {
            // this is currently an ok button
            //delete 
            if (!endGame)
            {
                eventList.Remove(eventList[0]);

                showAfter = false;
                eventSet = false;
            }
            else
            {
                GenerateEventList();

            }

        }
    }

    public bool EndGameCheck()
    {
        if(Resource01 <= 0)
        {
            EndingText = Resource01Zero;

            return true;
        }
        if(Resource02 <= 0)
        {
            EndingText = Resource02Zero;
            return true;
        }
        if(Resource03 <= 0)
        {
            EndingText = Resource03Zero;
            return true;
        }
        if(Resource04 <= 0)
        {
            EndingText = Resource04Zero;
            return true;
        }
        if(Resource05 <= 0)
        {
            EndingText = Resource05Zero;
            return true;
        }


        if (Resource01 >= 100)
        {
            EndingText = Resource01Hundred;
            return true;
        }
        if(Resource02 >= 100)
        {
            EndingText = Resource02Hundred;
            return true;
        }
        if(Resource03 >= 100)
        {
            EndingText = Resource03Hundred;
            return true;
        }
        if(Resource04 >= 100)
        {
            EndingText = Resource04Hundred;
            return true;
        }
        if(Resource05 >= 100)
        {
            EndingText = Resource05Hundred;
            return true;
        }

        return false;
    }
    void shuffleEventList()
    {
        for (int i = 0; i < eventList.Count; i++)
        {
            EventTemplate temp = eventList[i];
            int RandomIndex = Random.Range(i, eventList.Count);
            eventList[i] = eventList[RandomIndex];
            eventList[RandomIndex] = temp;
        }
    }

    void GenerateFileList()
    {
        path = Application.dataPath + path;
        print(path);
        DirectoryInfo info = new DirectoryInfo(path);
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            print(file);
            if (file.Extension == "asset")
            {
                //eventList.Add(file);
            }
        }
    }
}
