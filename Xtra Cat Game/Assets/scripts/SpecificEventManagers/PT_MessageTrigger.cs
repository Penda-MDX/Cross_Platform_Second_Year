using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_MessageTrigger : MonoBehaviour {

    [SerializeField] private PT_BasicMessage messageHandler;
    [SerializeField] private Sprite objectImage;
    [SerializeField] private GameObject objectforShow;
    [SerializeField] private string messageForTrigger;
    private bool interactionActive;

    
    //public int EventNumber;
    //private PT_TaskManager CurrentTaskManager;

    private void OnEnable()
    {
      //CurrentTaskManager = GameObject.Find("TaskManager").GetComponent<PT_TaskManager>();
    }

    // Update is called once per frame
    void Update () {
		if(interactionActive && Input.GetKeyUp("f"))
        {
            //CurrentTaskManager.TaskCompleted(EventNumber);
            messageHandler.CloseMessage();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionActive = true;
            if (objectforShow != null)
            {
                messageHandler.ShowMessage(messageForTrigger, 3.0f, objectforShow);
            }else if (objectImage != null)
            {
                messageHandler.ShowMessage(messageForTrigger, 3.0f, objectImage);
            }
            else
            {
                messageHandler.ShowMessage(messageForTrigger, 3.0f);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactionActive = false;
        }
    }
}
