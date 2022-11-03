using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CardTemplate : ScriptableObject
{
    public string CardName;
    public string EventDescription;
    public string Choice01Short;
    public string Choice02Short;

    public string Choice01Outcome;
    public string Choice02Outcome;

    public int Choice01Resource01Change;
    public int Choice01Resource02Change;
    public int Choice01Resource03Change;
    public int Choice01Resource04Change;
    public int Choice01Resource05Change;

    public int Choice02Resource01Change;
    public int Choice02Resource02Change;
    public int Choice02Resource03Change;
    public int Choice02Resource04Change;
    public int Choice02Resource05Change;

}
