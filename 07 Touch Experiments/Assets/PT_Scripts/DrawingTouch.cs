using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTouch : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Update()
    {
        Drawing();
    }

    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            // grab shape and score it based on criteria
            ScoreLine(currentLineRenderer);
            currentLineRenderer = null;
        }
    }

    void ScoreLine(LineRenderer lastLine)
    {
        float _value = 0.0.f;
       for(int i = 0; i<lastLine.positionCount-2;i++)
       {

       }

    }

    void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        //because you gotta have 2 points to start a line renderer, 
        Vector3 _currentPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(_currentPosition.x, _currentPosition.y);
        //Debug.Log("Mouse pos: " + Input.mousePosition);
        //Debug.Log("Calc pos: " + mousePos);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector3 _currentPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(_currentPosition.x, _currentPosition.y);

        //Debug.Log("Mouse pos: " + Input.mousePosition);
        //Debug.Log("Calc pos: " + mousePos);

        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
}
