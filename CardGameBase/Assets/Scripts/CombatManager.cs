using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public string CurrentState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //states: PlayerTurn, AITurn, OrdersComplete, Outcome, EndTurn

        switch (CurrentState)
        {

            case "PlayerTurn":
                //check for inputs

                break;

            case "AITurn":
                
                break;

            case "OrderComplete":
                
                break;

            case "Outcome":
                
                break;
            case "EndTurn":

                break;
            default:

                break;

        }
    }

    public void SubmitOrders()
    {

    }
}
