using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_die_when_hit : MonoBehaviour {

    //Tags or Layers or Object Type
    // ----------------------------------------------------------------------

    public string st_no_effect_tag = "Asteroid";


    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D _cl_detected)
    {
        
        // when hit, loop through the array of objects spawning each one at this location
        if (_cl_detected.gameObject.tag != st_no_effect_tag)
        {
            Destroy(gameObject);
        }
    }//-----

}
