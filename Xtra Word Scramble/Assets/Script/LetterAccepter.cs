using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterAccepter : MonoBehaviour
{
    public string LetterAccepted;

    [SerializeField]
    private GameObject emptyGO;
    [SerializeField]
    private GameObject presentGO;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        DraggableLetter collidedLetter = collision.gameObject.GetComponent<DraggableLetter>();

        if (collidedLetter != null)
        {

            //change colour
            emptyGO.SetActive(false);
            presentGO.SetActive(true);
            //verify letter
            
        }
    }
}
