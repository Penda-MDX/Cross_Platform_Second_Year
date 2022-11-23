using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterActions : MonoBehaviour
{

    public GameObject attackTrigger;
    public float attackTime;

    private float attackComplete;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            attackTrigger.SetActive(true);
            attackComplete = Time.time + attackTime;
        }
        if (attackComplete < Time.time)
        {
            attackTrigger.SetActive(false);
        }
    }
}
