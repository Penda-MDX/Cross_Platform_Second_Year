using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateRule : ScriptableObject {

   
    //threshold Type should be equal (exactly equal), more (equal or greater), less (equal or less than)
    [Tooltip("threshold Type should be one of equal (exactly equal), more (equal or greater), less (equal or less than)")]
    public string thresholdType;

    public int thresholdValue;
    [Tooltip("Which IntVariable resource pool is being monitored for this?")]
    public IntVariable resourcePoolMonitored;

    public bool IsRuleTriggered()
    {
        switch(thresholdType){
            case "equal":
                if (resourcePoolMonitored.RuntimeValue==thresholdValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            case "less":
                if (resourcePoolMonitored.RuntimeValue <= thresholdValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "more":
                if (resourcePoolMonitored.RuntimeValue >= thresholdValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;

        }
    }

}
