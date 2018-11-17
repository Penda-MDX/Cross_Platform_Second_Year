using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_TileMapMaker : MonoBehaviour {
    public int XSize = 3;
    public int YSize = 3;
    public PT_camera_follow cameraUsed;

    //Lists for each type of map part - prefabs
    public GameObject[] MiddleMapParts;
    public GameObject[] TopLeftMapCorners;
    public GameObject[] TopRightMapCorners;
    public GameObject[] BottomLeftMapCorners;
    public GameObject[] BottomRightMapCorners;
    public GameObject[] TopEdges;
    public GameObject[] BottomEdges;
    public GameObject[] LeftEdges;
    public GameObject[] RightEdges;

    //PC prefab
    public GameObject PlayerCharacter;

    //list of prefab selections for the map
    public GameObject[,] MapData;

    // Use this for initialization
    void Start () {
        BuildMap();
        DrawMap();
        SpawnCharacter();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildMap()
    {
        //Kill old map and Resize Array
        GameObject[,] TmpMap = new GameObject[XSize, YSize];

        //Select Template or Generate a Map for non-square maps [To Be Implemented]

        //Map Tiles are 10 by 10
        //Find and generate corners
        //0,0
        TmpMap[0, 0] = TopLeftMapCorners[Mathf.FloorToInt(Random.Range(0,TopLeftMapCorners.Length))];
        //XSize-1,YSize-1
        TmpMap[XSize - 1, YSize - 1] = BottomRightMapCorners[Mathf.FloorToInt(Random.Range(0, BottomRightMapCorners.Length))];
        //0, YSize-1
        TmpMap[0, YSize - 1] = BottomLeftMapCorners[Mathf.FloorToInt(Random.Range(0, BottomLeftMapCorners.Length))];
        //XSize-1,0
        TmpMap[XSize - 1, 0] = TopRightMapCorners[Mathf.FloorToInt(Random.Range(0, TopRightMapCorners.Length))];

        //Find and Generate Edges
        //Left Edge 0, 1 to YSize-2
        for(int intEdge = 1; intEdge < YSize-1; intEdge++)
        {
            TmpMap[0, intEdge] = LeftEdges[Mathf.FloorToInt(Random.Range(0, LeftEdges.Length))];
        }

        //Right Edge XSize-1, 1 to YSize-2
        for (int intEdge = 1; intEdge < YSize - 1; intEdge++)
        {
            TmpMap[XSize-1, intEdge] = RightEdges[Mathf.FloorToInt(Random.Range(0, RightEdges.Length))];
        }


        //Top Edge 1 to XSize-2, 0
        for (int intEdge = 1; intEdge < XSize - 1; intEdge++)
        {
            TmpMap[intEdge, 0] = TopEdges[Mathf.FloorToInt(Random.Range(0, TopEdges.Length))];
        }
        //Bottom Edge 1 to XSize-2, YSize-1 
        for (int intEdge = 1; intEdge < XSize - 1; intEdge++)
        {
            TmpMap[intEdge, YSize - 1] = BottomEdges[Mathf.FloorToInt(Random.Range(0, BottomEdges.Length))];
        }
        //Find and Generate Middle
        //1 to XSize-2, 1 to YSize-2
        for(int yComponent = 1; yComponent < YSize-1; yComponent++)
        {
            for(int xComponent = 1; xComponent< XSize - 1; xComponent++)
            {
                TmpMap[xComponent, yComponent] = MiddleMapParts[Mathf.FloorToInt(Random.Range(0, MiddleMapParts.Length))];
            }
        }
        MapData = TmpMap;
    }

    private void DrawMap()
    {
        GameObject tmpMapBit;

        for (int yComponent = 0; yComponent < YSize; yComponent++)
        {
            for (int xComponent = 0; xComponent < XSize; xComponent++)
            {
                tmpMapBit = Instantiate(MapData[xComponent, yComponent]);
                tmpMapBit.transform.parent = gameObject.transform;
                tmpMapBit.transform.localPosition = new Vector2(xComponent * 10, yComponent * -10);
            }
        }
    }
    private void SpawnCharacter()
    {

        GameObject[] startPoints = GameObject.FindGameObjectsWithTag("StartSpawn");
        if (startPoints.Length>0)
        {
            Debug.Log("SomePoints");
            cameraUsed.gameObjectFollowedByCamera = Instantiate(PlayerCharacter, startPoints[Mathf.FloorToInt(Random.Range(0, startPoints.Length))].transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("NoPoints");
            cameraUsed.gameObjectFollowedByCamera = Instantiate(PlayerCharacter, startPoints[Mathf.FloorToInt(Random.Range(0, startPoints.Length))].transform.position, Quaternion.identity);
        }
    }
}
