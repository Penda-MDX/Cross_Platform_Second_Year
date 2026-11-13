using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChoicePoint : MonoBehaviour
{
    private List<string> OfferedFulfillments;

    public bool MatchesDesire(string desire)
    {
        
        foreach(string fulfillment in OfferedFulfillments)
        {
            if (desire == fulfillment)
            {
                return true;
            }
        }
        return false;
    }
}
