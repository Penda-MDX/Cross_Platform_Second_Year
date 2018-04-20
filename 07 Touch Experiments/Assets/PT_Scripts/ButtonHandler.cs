using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    [SerializeField] private GameObject item1Prefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateNewItem(string ItemType)
    {
        //print("Item type: " + ItemType);
        switch (ItemType)
        {
            case "Type 1":
                Instantiate(item1Prefab);
                break;
            case "Type 2":

                break;
            default:

                break;
        }
    }
}
