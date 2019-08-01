using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : ScriptableObject {
    // Series of rules that must all be true to trigger the ending

    public int priority;
    public List<EndStateRule> requiredRules;

    public string EndingTitle;
    public string EndingDescription;

    public void checkEnding()
    {
        foreach(EndStateRule currentRule in requiredRules)
        {
            if (!currentRule.IsRuleTriggered())
            {
                return;
            }
        }
        //if you manage to loop through all the rules without one false dumping you out then go for it!
        TriggerEnding();
    }

    public void TriggerEnding()
    {
        //
    }
}
