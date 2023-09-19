using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPress : MonoBehaviour
{
    public bool targetActive = false;
    public string keyBound;
    private GameObject oBlip;
    public float outerRange;
    public float innerRange;
    public float perfectRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetActive && Input.GetKey(keyBound))
        {

            float distance = Mathf.Abs(Vector2.Distance(oBlip.transform.position, gameObject.transform.position));
            if (distance <= perfectRange)
            {
                Debug.Log("20 points");
                targetActive = false;
                Destroy(oBlip);
                oBlip = null;

            }
            else if (distance <= innerRange)
            {
                Debug.Log("10 points");
                targetActive = false;
                Destroy(oBlip);
                oBlip = null;
            }
            else if(distance<= outerRange)
            {
                Debug.Log("5 points");
                targetActive = false;
                Destroy(oBlip);
                oBlip = null;
            } 
            else 
            {
                Debug.Log("Nope");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blip")
        {
            Debug.Log("Blip Ho!");
            targetActive = true;
            oBlip = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blip")
        {
            targetActive = false;
            oBlip = null;
        }
    }
}
