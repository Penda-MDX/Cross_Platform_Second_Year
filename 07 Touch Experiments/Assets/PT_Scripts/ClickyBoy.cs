using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickyBoy: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject closedSprite;
    public GameObject openSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (closedSprite.activeSelf)
        {
            closedSprite.SetActive(false);
            openSprite.SetActive(true);

        }
    }
}
