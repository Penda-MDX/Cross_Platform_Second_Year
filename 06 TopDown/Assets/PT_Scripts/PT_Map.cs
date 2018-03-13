using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "Map_Walls", order = 1)]
public class PT_Map : ScriptableObject {

    public string mapName;
    public int[,] mapData;

    //comma and return delimited map text data
    public string rawMapData;
    
    public void ParseRawMapData()
    {
            string[] dataRows;
            dataRows = rawMapData.Split((char)13);
            int NumberOfRows = dataRows.Length;
            string[] dataColumns = dataRows[1].Split(',');
            int NumberOfColumns = dataColumns.Length;
            mapData = new int[NumberOfColumns, NumberOfRows];
            int rowCount = 0;
            foreach(string _row in dataRows)
            {
                dataColumns = _row.Split(',');
                int columnCount = 0;
                foreach(string _item in dataColumns)
                {
                    mapData[columnCount, rowCount] = Convert.ToInt32(_item);
                    columnCount++;
                }
                rowCount++;
            }
     }

}
