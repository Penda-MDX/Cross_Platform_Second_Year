using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Invisible_In_Play : MonoBehaviour {
    private Renderer _renderer;

	// Use this for initialization
	void Start () {
        _renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        _renderer.enabled = false;
	}
}
