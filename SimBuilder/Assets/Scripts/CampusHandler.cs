using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CampusHandler : MonoBehaviour
{
    private List<ChoicePoint> choicePoints;

    // Update is called once per frame
    void Update()
    {
        
    }

    public ChoicePoint GetNearest(string desire, Vector3 pointLocation)
    {
        ChoicePoint current = null;
        float currentDistance = 100.0f;
        foreach(ChoicePoint cp in choicePoints)
        {
            if (cp.MatchesDesire(desire))
            {
                float testDist = Vector3.Distance(pointLocation, transform.position);
                if (currentDistance>testDist)
                {
                    currentDistance = testDist;
                    current = cp;
                }

            }
        }
        return current;

    }
}
