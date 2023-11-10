using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTracker : MonoBehaviour
{
    public List<PuzzlePiece> puzzleitems;
    public bool ontrack;
    public bool changed = true;
    public int NumberToComplete;
    private int completionCount;
    private bool isComplete;

    public GameObject indicatorRed;
    public GameObject indicatorGreen;

    // public Color goodSprite;
    //  public Color failSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            if (ontrack || isComplete)
            {
                //indicator.GetComponent<SpriteRenderer>().color = goodSprite;
                indicatorGreen.SetActive(true);
                indicatorRed.SetActive(false);
            }
            else
            {
                //indicator.GetComponent<SpriteRenderer>().color = failSprite;
                indicatorGreen.SetActive(false);
                indicatorRed.SetActive(true);
            }
            changed = false;
        }

        changed = false;
        int bitCount = 0;
        completionCount = 0;
        foreach(PuzzlePiece item in puzzleitems)
        {
            if (item.insideThis)
            {
                bitCount += 1;
            }
            if (item.hasBeenInside)
            {
                completionCount++;
            }

        }

        if (bitCount>0 && !ontrack)
        {
            ontrack = true;
            changed = true;
        }

        if (bitCount == 0 && ontrack)
        {
            ontrack = false;
            changed = true;
            foreach (PuzzlePiece item in puzzleitems)
            {
                item.hasBeenInside = false;
            }
            completionCount = 0;
        }

        if (completionCount == NumberToComplete)
        {
            isComplete = true;
        }


    }

    public void registerPuzzlePiece(PuzzlePiece item)
    {
        puzzleitems.Add(item);
        NumberToComplete++;
    }


}
