using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutHandler : MonoBehaviour {

    [SerializeField] private int squareSize;
    private GameObject[,] layout2DArray ;
    [SerializeField] private GameObject emptyPrefab;

    private GameObject currentLayoutItem;
	
    // Use this for initialization
	void Start () {
        //positive x is right (columns)
        //negative y is down (rows)
        layout2DArray = new GameObject[squareSize, squareSize];
        for (int rowCount = 0; rowCount < layout2DArray.GetLength(0); rowCount++)
        {
            for (int colCount = 0; colCount < layout2DArray.GetLength(1); colCount++)
            {
                currentLayoutItem = Instantiate(emptyPrefab, transform);
                currentLayoutItem.transform.localPosition = new Vector3(colCount, -rowCount, 0);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
