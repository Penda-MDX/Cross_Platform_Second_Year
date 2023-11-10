using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public PuzzleTracker tracker;
    public bool insideThis;
    public bool hasBeenInside;

    // Start is called before the first frame update
    void Start()
    {
        tracker.registerPuzzlePiece(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            Debug.Log("I'm in!");
            insideThis = true;
            hasBeenInside = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            insideThis = true;
            hasBeenInside = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer")
        {
            Debug.Log("I'm out!");
            insideThis = false;
        }

    }
}
