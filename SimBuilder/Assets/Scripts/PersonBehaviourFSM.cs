using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PersonBehaviourFSM : MonoBehaviour
{
    private enum BehaviourState
    {
        Searching,
        Choosing,
        Entering,
        Engaged,
        Leaving,
        Hungry
    }
    private string characterName;
    [SerializeField] private float MovementSpeed = 5.0f;

    private BehaviourState currentState;
    private float timeToChange;
    private List<string> Desires;
    private ChoicePoint currentTarget;
    private ChoicePoint previousTarget;
    

    private float hunger = 0.0f;
    private float morale = 50.0f;
    private float credits = 0.0f;



    void Awake()
    {
        currentState = BehaviourState.Searching;
        //randomly generate a name

    }

    // Update is called once per frame
    void Update()
    {
        //move towards current target based on current time speed and move speed
        if (currentTarget != null)
        {

        }

        switch (currentState)
        {
            case BehaviourState.Searching:
                //find nearest choice and move towards it

                break;
            case BehaviourState.Choosing:
                //check current states
                break;
            case BehaviourState.Entering:
                //move in as animation and then trigger Engaged
                break;
            case BehaviourState.Engaged:
                //once the timer is complete change the numbers
                break;
            case BehaviourState.Leaving: 
                //move out of last room and check to see if hungry or 
                break;
            case BehaviourState.Hungry:
                // is this useful as a seperate state or should it just change searching?
                break;
        }
    }
}
