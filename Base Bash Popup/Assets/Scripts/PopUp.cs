using UnityEngine;
using UnityEngine.InputSystem.LowLevel;


public class PopUp : MonoBehaviour
{

    [SerializeField] private string PopUpState = "Deactivated";
    [SerializeField] private GameObject EmptyVisual;
    [SerializeField] private GameObject ApproachingVisual;
    [SerializeField] private GameObject GoodVisual;
    [SerializeField] private GameObject BadVisual;
    [SerializeField] private int arrivalLittleTicks = 3;
    [SerializeField] private int upTimeLittleTicks = 6;
    [SerializeField] private int CoolDownTime = 4;

    private BoxCollider2D CollisionBox;
    private bool ActivePopup = false;
    private int OnCoolDown = 0;
    private string PopUpContent = "";
    private int countToPopup;
    private int countToArrival;
    private int countToEnd;

    private string lastState = "Deactivated";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CollisionBox = gameObject.GetComponent<BoxCollider2D>();
        CollisionBox.enabled = false;
        GameHandler.Instance.BigTick += GameHandler_BigTick;
        GameHandler.Instance.LittleTick += GameHandler_LittleTick;
        GameHandler.Instance.RegisterPopUp(this);
        DeactivateAll();
    }

    private void GameHandler_LittleTick(object sender, System.EventArgs e)
    {
        if (ActivePopup && countToPopup == 0 && PopUpState == "Arriving")
        {
            countToArrival--;
        }
        if (ActivePopup && (PopUpState == "GoodPop" || PopUpState == "BadPop") && countToEnd > 0)
        {
            countToEnd--;
        }
        if (OnCoolDown > 0)
        {
            OnCoolDown--;
        }
    }

    private void GameHandler_BigTick(object sender, System.EventArgs e)
    {
        if (ActivePopup && countToPopup > 0)
        {
            countToPopup--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //test using properties input
        if (PopUpState != lastState)
        {
            StateChange(PopUpState);
            lastState = PopUpState;
        }

        if(ActivePopup && countToPopup == 0 && PopUpState=="Empty")
        {
            StateChange("Arriving");
        }

        if (ActivePopup && PopUpState == "Arriving" && countToArrival == 0)
        {
            StateChange(PopUpContent);
        }

        if (ActivePopup && (PopUpState == "GoodPop" || PopUpState == "BadPop") && countToEnd == 0)
        {
            if (PopUpState == "BadPop" && BadVisual.activeSelf)
            {
                //Debug.Log("Missed One Trigger");
                GameHandler.Instance.MissedOne();
            }
            StateChange("Empty");
            ActivePopup = false;
            OnCoolDown = CoolDownTime;

        }


    }

    public bool IsDeactivated()
    {
        return PopUpState == "Deactivated";
    }

    public void Activate()
    {
        StateChange("Empty");
    }
    public bool CanBeActivated() 
    {
        if (PopUpState=="Empty" && !ActivePopup && OnCoolDown<=0)
        {
            return true;
        }
        return false;
    }
    public void ActivateAs(string ContentType, int TicksToContent)
    {
        PopUpContent = ContentType;
        countToPopup = TicksToContent;
        ActivePopup = true;
        StateChange("Empty");

    }

    private void StateChange(string newState)
    {
        if (newState != PopUpState)
        {
            DeactivateAll();
            PopUpState = newState;
            switch (PopUpState)
            {
                case "Deactivated":
                    ActivePopup = false;
                    break;
                case "Empty":
                    EmptyVisual.SetActive(true);
                    break;
                case "Arriving":
                    countToArrival = arrivalLittleTicks;
                    ApproachingVisual.SetActive(true);
                    break;
                case "GoodPop":
                    CollisionBox.enabled = true;
                    countToEnd = upTimeLittleTicks;
                    GoodVisual.SetActive(true);
                    break;
                case "BadPop":
                    CollisionBox.enabled = true;
                    countToEnd = upTimeLittleTicks;
                    BadVisual.SetActive(true);
                    break;
            }
        }
    }


    private void DeactivateAll()
    {
        CollisionBox.enabled = false;
        EmptyVisual.SetActive(false);
        ApproachingVisual.SetActive(false);
        GoodVisual.SetActive(false);
        BadVisual.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bop")
        {

            if (PopUpState == "GoodPop")
            {
                Debug.Log("Oh no you hit a good guy!");
                GoodVisual.SetActive(false);
                GameHandler.Instance.PopupHit("GoodPop");
            }
            if (PopUpState == "BadPop")
            {
                Debug.Log("Oh yey you hit a bad guy!");
                BadVisual.SetActive(false);
                GameHandler.Instance.PopupHit("BadPop");
            }

        }
    }
}
