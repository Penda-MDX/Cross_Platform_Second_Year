using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour {

    //cards to be used
    public Deck mainDeck;
    //cards from last time or for next time
    public Deck consequenceDeck;
    //the deck in use
    public List<CardTemplate> currentDeck;

    public CardTemplate currentDrawnCard;

    public GameObject CardUIManager;

    //private 

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShuffleDeck()
    {

    }
    
    public void DrawNextCard()
    {

    }

    public void EndOfDeck()
    {

    }
}
