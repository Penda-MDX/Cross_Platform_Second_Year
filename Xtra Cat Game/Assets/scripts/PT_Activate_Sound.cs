using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Activate_Sound : MonoBehaviour {
    public float activateAtDistance;
    public Transform playerCharacter;
    private AudioSource soundController;
	// Use this for initialization
	void Start () {
        soundController = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {

		if(Vector3.Distance(playerCharacter.position, transform.position) < activateAtDistance)
        {
            if (!soundController.isPlaying)
            {
                soundController.Play();
            }
        }
        else
        {
            soundController.Stop();
        }
	}
}
