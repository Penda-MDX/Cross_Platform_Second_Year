using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkConstructorScript : MonoBehaviour
{
    public string ChunkData;
    public List<GameObject> prefabList;
    private bool ChunKValid;
    private int[,] ChunkBuildData;

    public void ParseChunkData()
    {
        //break the map string on semicolons
        string[] dataRows;
        dataRows = ChunkData.Split(';');
        int NumberOfRows = dataRows.Length;
        int NumberOfColumns = 1;
        string[] dataColumns;
        //break each line on commas and find the longest to get a number of columns
        for (int rowcount = 0; rowcount < dataRows.Length; rowcount++)
        {
            dataColumns = dataRows[rowcount].Split(',');
            if (NumberOfColumns < dataColumns.Length)
            {
                NumberOfColumns = dataColumns.Length;
            }
        }

        //create a new array
        ChunkBuildData = new int[NumberOfRows, NumberOfColumns];
        //loop through and load the data from each string into the array
        int rowCount = 0;
        //loop through array of rows
        foreach (string _row in dataRows)
        {
            dataColumns = _row.Split(',');
            //loop through each column in the row and put the number into the correct slot in the map data
            int columnCount = 0;
            foreach (string _item in dataColumns)
            {
                //print(_item);
                
                ChunkBuildData[rowCount, columnCount] = Convert.ToInt32(_item.Trim());
                columnCount++;
            }
            rowCount++;
        }
    }

    public void BuildChunk()
    {

        
        /*
        //positive x is right 
        //negative y is down
        for (int rowCount = 0; rowCount < currentMapData.GetLength(0); rowCount++)
        {
            for (int colCount = 0; colCount < currentMapData.GetLength(1); colCount++)
            {
                if(currentMapData[rowCount, colCount] == 0)
                {

                }else if (currentMapData[rowCount, colCount] == 1)
                {
                    _currentWall = Instantiate(wallPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);

                }else if (currentMapData[rowCount, colCount] == 2)
                {
                    _currentWall = Instantiate(exitPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }else if (currentMapData[rowCount, colCount] == 3)
                {
                    _currentWall = Instantiate(dangerPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }else if (currentMapData[rowCount, colCount] == 4)
                {
                    _currentWall = Instantiate(pickupPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }else if (currentMapData[rowCount, colCount] == 5)
                {
                    //Moving Danger horizontal
                    _currentWall = Instantiate(movingDangerPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }else if (currentMapData[rowCount, colCount] == 6)
                {
                    //Moving Danger vertical
                    _currentWall = Instantiate(verticalMovingDangerPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                }else if (currentMapData[rowCount, colCount] == 9)
                {
                    _currentWall = Instantiate(PCPrefab, transform);
                    _currentWall.transform.localPosition = new Vector3(colCount, -rowCount, 0);
                    followCam.gameObjectFollowedByCamera = _currentWall;
                }
            }
            

        }*/
    }
}
