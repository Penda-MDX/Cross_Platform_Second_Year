using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adapted from script example here - https://pressstart.vip/tutorials/2018/06/22/39/mobile-joystick-in-unity.html

public class PT_sprite_joystick : MonoBehaviour {
    public Transform characterTransform;
    public float speed = 5.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform circle;
    public Transform outerCircle;

	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0)){
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            //pointA = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);

            //circle.transform.position = pointA * -1;
            //outerCircle.transform.position = pointA * -1;
            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        if(Input.GetMouseButton(0)){
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }else{
            touchStart = false;
        }
        
	}
	private void FixedUpdate(){
        if(touchStart){
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            //moveCharacter(direction * -1);
            moveCharacter(direction);

            //circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }else{
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

	}
	void moveCharacter(Vector2 direction){
        characterTransform.Translate(direction * speed * Time.deltaTime);
    }
}