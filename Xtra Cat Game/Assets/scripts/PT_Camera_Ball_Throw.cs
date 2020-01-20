using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Camera_Ball_Throw : MonoBehaviour
{

    public GameObject ObjectToThrow;
    public GameObject InGamePointer;
    public bool IsOn;
    public float ShotCoolDown;
    public float ThrowForce;
    public float distanceFromCamera;

    private Rigidbody ThrownRigidBody;
    private Camera mainCamera;
    private float TimeReady;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOn)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;

            InGamePointer.transform.position = Camera.main.ScreenToWorldPoint(pos);

            //The shooting is turned on 
            if (TimeReady<Time.time && Input.GetMouseButton(0))
            {
                GameObject newInstance = Instantiate(ObjectToThrow, mainCamera.transform.position, mainCamera.transform.rotation);
                ThrownRigidBody = newInstance.GetComponent<Rigidbody>();
                newInstance.transform.LookAt(InGamePointer.transform);

                ThrownRigidBody.AddForce(newInstance.transform.forward * ThrowForce);

                TimeReady = Time.time + ShotCoolDown;
            }

        }
    }
}
