using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_spawn_when_hit : MonoBehaviour {
    // ----------------------------------------------------------------------

    public string st_no_effect_tag = "Asteroid";
    public GameObject[] GO_Spawnees;


    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D _cl_detected)
    {
        // when hit, loop through the array of objects spawning each one at this location
        if (_cl_detected.gameObject.tag != st_no_effect_tag)
        {
            foreach (GameObject _GO in GO_Spawnees)
            {
                Instantiate(_GO, transform.position, transform.rotation);
            }
        }
    }//-----
}
