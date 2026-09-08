using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_player_ship_die_when_hit : MonoBehaviour {

    //Tags or Layers or Object Type
    // ----------------------------------------------------------------------

    public string st_no_effect_tag = "Player";
    public float fl_death_animation_delay = 1;

    private bool bl_death_animation = false;
    private float fl_death_animation_complete_time;
    private PT_asteroids_game_manager mb_gamemanager;

    void Start()
    {
        mb_gamemanager = GameObject.Find("Asteroids Game_Manager").GetComponent<PT_asteroids_game_manager>();
    }

    // ----------------------------------------------------------------------
    // Has this object collided with another 2D object?
    void OnCollisionEnter2D(Collision2D _cl_detected)
    {

        // when hit, loop through the array of objects spawning each one at this location
        if (_cl_detected.gameObject.tag != st_no_effect_tag)
        {
            mb_gamemanager.PlayerShipDeath();
            //Add animation delay in future build
            Destroy(gameObject);
           
        }
    }//-----
}
