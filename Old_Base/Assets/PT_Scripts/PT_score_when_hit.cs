using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_score_when_hit : MonoBehaviour {

    //How much does this score
    public int in_this_will_score = 100;
    public string st_hit_by_tag_to_score = "Player";
    private PT_asteroids_game_manager mb_gamemanager;

    void Start()
    {
        mb_gamemanager = GameObject.Find("Asteroids Game_Manager").GetComponent<PT_asteroids_game_manager>();
    }

    void OnCollisionEnter2D(Collision2D _cl_detected)
    {
        // when this is hit by something with this tag then increase the score by the agreed amount
        if (_cl_detected.gameObject.tag == st_hit_by_tag_to_score)
        {
            mb_gamemanager.in_score = mb_gamemanager.in_score + in_this_will_score;
        }        
    }
}
