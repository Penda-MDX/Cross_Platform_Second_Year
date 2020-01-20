using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_BasicMessage : MonoBehaviour {

    [SerializeField] private GameObject MessageCanvas;
    [SerializeField] private Text OnScreenText;
    [SerializeField] private GameObject showParent;
    [SerializeField] private Image showImage;
    private GameObject showObject;
    private float timeOut;
    private bool messageOpen;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKey("f"))
        {
            ShowMessage("The quick brown fox jumps over the lazy dog!", 3.0f);
        }
        */

        HideMessage();
	}

    public void ShowMessage(string message, float timeOnScreen)
    {
        OnScreenText.text = message;
        timeOut = Time.time + timeOnScreen;
        showImage.gameObject.SetActive(false);
        MessageCanvas.SetActive(true);
    }

    public void ShowMessage(string message, float timeOnScreen, Sprite imageSprite)
    {
        OnScreenText.text = message;
        timeOut = Time.time + timeOnScreen;
        MessageCanvas.SetActive(true);
    }

    public void ShowMessage(string message, float timeOnScreen, GameObject showObjectClose)
    {
        if (!messageOpen)
        {
            OnScreenText.text = message;
            timeOut = Time.time + timeOnScreen;
            showImage.gameObject.SetActive(false);
            //prevent multiple objects at the sametime
            if (showObject == null)
            {
                showObject = Instantiate(showObjectClose, showParent.transform);
                showObject.transform.localPosition = Vector3.zero;
                Destroy(showObject, timeOnScreen);
            }
            MessageCanvas.SetActive(true);
            messageOpen = true;
        }
    }

    public void CloseMessage()
    {
        MessageCanvas.SetActive(false);
        if (showObject!=null)
        {
            showObject.transform.parent = null;
            showObject.SetActive(false);
        }
        messageOpen = false;
    }
    void HideMessage()
    {
        //if the time out is now less than the current time
        if (timeOut <= Time.time)
        {
            CloseMessage();
        }
    }

}
