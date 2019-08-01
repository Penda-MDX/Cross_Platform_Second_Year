using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Deck : ScriptableObject {

    public string DeckName = "new deck name";
    public List<CardTemplate> CardList;
    public List<CardTemplate> Discards;

    public bool resetFromDiscard;
    public bool resetToEmpty;

    public void Shuffle()
    {
        // change the order of the CardList
    }

    public void Next()
    {
        //Move Current Card to Discard

        //

    }

    public void Reset()
    {
        //Reset to Empty or Add Back the Discards

    }

}
