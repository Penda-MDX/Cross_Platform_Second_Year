using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTemplate : ScriptableObject {
    //abstract class for Actions - add to or subtract from a pool int or float, add or remove cards (specific cards, specific part of the deck, etc.), add a deck to another deck?, shuffle the deck

    public string ActionName = "New Action";

    public abstract void TriggerAction();

}
