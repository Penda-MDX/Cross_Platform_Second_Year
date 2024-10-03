using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueCharacterMove : MonoBehaviour
{
    public int squaresPerMove;
    public int currentAttack;
    // state waiting, moving, attacking, dying
    public string state;

    private Vector2 nextTarget;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "waiting")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                nextTarget = new Vector2(transform.position.x, transform.position.y) + (Vector2.up * squaresPerMove);
                state = "moving";
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

            }
        }

        if(state == "moving")
        {

        }

    }
}
