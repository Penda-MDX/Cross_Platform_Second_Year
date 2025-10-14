using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WorldTilt : MonoBehaviour
{
    public float rotationMultiplier;
    private Vector3 interpIncrement;
    private Quaternion startRotation;
    private Quaternion fromRotation;
    private float timeCount;
    private bool inputFound;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //tilt in direction pressed (rotation is around axes - forward back is around x axis - left right is around z axis)
        Vector3 _vector3Input = new Vector3( Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        if(_vector3Input != Vector3.zero)
        {
            transform.Rotate(_vector3Input * rotationMultiplier);
            inputFound = true;
        }
        else
        {
            if (inputFound)
            {
                inputFound = false;
                timeCount = 0;
                fromRotation = transform.rotation;
            }
            // interpolate back to 0
            if (transform.rotation != startRotation)
            {
                transform.rotation = Quaternion.Slerp(fromRotation, startRotation, timeCount);
                timeCount = timeCount + Time.deltaTime;

                // Clamp timeCount to ensure it stays between 0 and 1
                timeCount = Mathf.Clamp01(timeCount);

            }

               
        }
        


    }
}
