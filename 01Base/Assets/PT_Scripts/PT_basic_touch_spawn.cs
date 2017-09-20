using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_basic_touch_spawn : MonoBehaviour {

    public GameObject GO_fingerprint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //when there is more than one touch then spawn touches
        if (Input.touchCount > 0)
        {
            foreach(Touch _one_touch in Input.touches)
            {
                Vector3 _touch_position = Camera.main.ScreenToWorldPoint(_one_touch.position);
                _touch_position = new Vector3(_touch_position.x, _touch_position.y,0);
                //Instantiate(GO_fingerprint, _touch_position, new Quaternion(0,0,0,0));
                Instantiate(GO_fingerprint, _touch_position, Quaternion.identity);

            }
        }else if(Input.GetMouseButtonUp(0))
        {
            Vector3 _mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mouse_position = new Vector3(_mouse_position.x, _mouse_position.y, 0);
            //Instantiate(GO_fingerprint, _mouse_position, new Quaternion(0, 0, 0, 0));
            Instantiate(GO_fingerprint, _mouse_position, Quaternion.identity);
        }
	}
}
