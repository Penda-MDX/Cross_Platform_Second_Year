using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrebuchetControl : MonoBehaviour {

    //public bool TurnOn;
    public Rigidbody frontWeight;
    private float originalMass;
    
    private GameObject[] partsArray;
    private Vector3[] positionsArray;
    private Quaternion[] rotationsArray;


    // Use this for initialization
    void Start () {
        partsArray = new GameObject[transform.childCount];
        positionsArray = new Vector3[transform.childCount];
        rotationsArray = new Quaternion[transform.childCount];

        int indexCount = 0;
        foreach (Transform child in transform)
        {
            //child is your child transform
            partsArray[indexCount] = child.gameObject;
            positionsArray[indexCount] = child.position;
            rotationsArray[indexCount] = child.rotation;
            indexCount++;
        }

        //frontWeight.gameObject.SetActive(false);
        originalMass = frontWeight.mass;
        //frontWeight.mass = 0;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            frontWeight.mass = originalMass;
                
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            frontWeight.mass = 0;
                
            for(int indexCounter = 0; indexCounter<partsArray.Length; indexCounter++)
            {
                partsArray[indexCounter].transform.position = positionsArray[indexCounter];
                partsArray[indexCounter].transform.rotation = rotationsArray[indexCounter];
                partsArray[indexCounter].GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
                
        }
        
	}
}
