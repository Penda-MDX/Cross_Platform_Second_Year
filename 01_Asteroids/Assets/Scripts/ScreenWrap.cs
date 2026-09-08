using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    //---------------------------------------------------------------------------------------
    // Variables
    //public Rect re_movement_limits = new Rect(-10, 5, 10, -5);
    [SerializeField] private float leftEdge = -10;
    [SerializeField] private float rightEdge = 10;
    [SerializeField] private float topEdge = 5;
    [SerializeField] private float bottomEdge = -5;

    // This is a rectangle with 4 values x, y, width, height
    // Units are 100 pixels

    //---------------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        // constrain x axis
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }

        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }

        // constrain y axis
        if (transform.position.y > topEdge)
        {
            transform.position = new Vector2(transform.position.x, bottomEdge);
        }

        if (transform.position.y < bottomEdge)
        {
            transform.position = new Vector2(transform.position.x, topEdge);
        }

    }//-----
}
