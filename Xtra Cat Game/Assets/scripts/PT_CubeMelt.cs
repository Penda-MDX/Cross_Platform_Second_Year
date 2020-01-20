using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_CubeMelt : MonoBehaviour
{
    public float timeToMelt;
    public GameObject nextStagePrefab;

    private float nextPhaseReady;

    // Start is called before the first frame update
    void Start()
    {
        nextPhaseReady = Time.time + timeToMelt;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextPhaseReady < Time.time)
        {
            if (nextStagePrefab != null)
            {
                //left and right versions
                //Vector3 offset = new Vector3();
                Instantiate(nextStagePrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
