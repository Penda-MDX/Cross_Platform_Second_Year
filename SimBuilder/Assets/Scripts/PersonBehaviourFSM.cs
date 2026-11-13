using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class PersonBehaviourFSM : MonoBehaviour
{
    private enum BehaviourState
    {
        Searching,
        Entering,
        Leaving,
        Hungry
    }

    private List<string> Desires;

    private string characterName;

    private float hunger = 0.0f;
    private float morale = 50.0f;
    private float credits = 0.0f;



    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
