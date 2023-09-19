using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceHandler : MonoBehaviour
{
    public GameObject[] currentSequence;

    public GameObject[] allInteractables;

    public int[,] allSequences;

    private int interactionStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interacted(GameObject clickedObject)
    {
        if (currentSequence[interactionStage] == clickedObject)
        {

        }
    }


}
