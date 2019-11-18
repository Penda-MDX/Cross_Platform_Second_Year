using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public GameObject spawnee;
    public bool spawnee_selected;


    private Vector2 v2_last_mouse_position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            v2_last_mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(spawnee, v2_last_mouse_position, Quaternion.identity);
        }
    }
}
