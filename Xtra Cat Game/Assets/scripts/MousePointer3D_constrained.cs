using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer3D_constrained : MonoBehaviour
{
  
    public GameObject InGamePointer;
    public bool IsOn;
    public float distanceFromCamera;
    public float minDistancefromCamera;
    public float maxDistancefromCamera;
    public float scrollScale;

    private Camera mainCamera;
    private float currentDistanceFromCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        currentDistanceFromCamera = distanceFromCamera;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistanceFromCamera = currentDistanceFromCamera + (Input.mouseScrollDelta.y * scrollScale);
        if (currentDistanceFromCamera < minDistancefromCamera)
        {
            currentDistanceFromCamera = minDistancefromCamera;
        }

        if (currentDistanceFromCamera > maxDistancefromCamera)
        {
            currentDistanceFromCamera = maxDistancefromCamera;
        }


        if (IsOn)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = currentDistanceFromCamera;

            InGamePointer.transform.position = Camera.main.ScreenToWorldPoint(pos);

           
        }
    }
}
