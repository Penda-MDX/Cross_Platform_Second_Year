using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PT_Detect_Touch : MonoBehaviour
{
    private Collider2D bumpCollider;

    public AudioSource beeper;
    public Text textObject;
    public LayerMask targetLayer;

    // Start is called before the first frame update
    void Start()
    {
        bumpCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int touchCounter = 0; touchCounter < Input.touchCount; touchCounter++)
            {

                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCounter).position), Vector2.zero, Mathf.Infinity, targetLayer);
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(touchCounter).position);
                Vector2 touchPosition = new Vector2(wp.x, wp.y);
                textObject.text = hitInfo.collider.gameObject.name;


                //if (bumpCollider == Physics2D.OverlapPoint(touchPosition))
                if(hitInfo.collider.gameObject == gameObject)
                {
                    textObject.text = "Hit";
                    Handheld.Vibrate();
                    if (!beeper.isPlaying)
                    {
                        beeper.Play();
                    }
                }
            }
            

        }
    }
    
}
