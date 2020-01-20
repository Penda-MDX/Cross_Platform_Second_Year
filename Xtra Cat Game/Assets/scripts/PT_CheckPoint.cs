using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_CheckPoint : MonoBehaviour {

    public Material mt_Blue;
    public Material mt_Red;

    private Renderer _Renderer;
    private PT_LevelManager levelManagerReference;
    // Use this for initialization
    void Start () {
        _Renderer = gameObject.GetComponent<Renderer>();
        _Renderer.material = mt_Red;
        levelManagerReference = GameObject.Find("LevelManager").GetComponent<PT_LevelManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        //print(_Renderer.material.name);

        if (_Renderer.material.name == "Red (Instance)")
        {
            //print("Change");
            _Renderer.material = mt_Blue;
            levelManagerReference.lastGoodCheckpoint = transform;
        }
    }
}
