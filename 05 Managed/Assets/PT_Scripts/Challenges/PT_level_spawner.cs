using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_level_spawner : MonoBehaviour {
    /*
     * 
     * Create a 2-dimensional array that contains a set of numbers and a script that generates the level on start based on the array (see puzzlescript.net). 
     * 
     */
     /*
      * Map data legend
      * 
      * 
      * 
      */

     //fixed size array of integers
    public int[,] int_mapData = new int[10, 10];
    public List<int> myList = new List<int>();

    // Use this for initialization
    void Start () {
		//translate array positions to game world positions in a double for loop and 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
