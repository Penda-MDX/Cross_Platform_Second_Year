using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Gyro_Move : MonoBehaviour {

    public float fl_PC_Move_Speed = 25f;

    private Quaternion q_last_attitude;
    private float q_differential_attitude_x;
    private float q_differential_attitude_y;
    private float q_differential_attitude_z;
    private float q_differential_attitude_w;

    private PT_Game_Manager_Button_Loop sc_game_manager; 

    // Use this for initialization
    void Start () {
        
        if (!Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
        }

        q_last_attitude = GyroToUnity(Input.gyro.attitude);
        if (GameObject.Find("GameManager") != null)
        {
            sc_game_manager = GameObject.Find("GameManager").GetComponent<PT_Game_Manager_Button_Loop>();
        }
    }
	
	// Update is called once per frame
	void Update () {

        Quaternion _q_current_attitude = GyroToUnity(Input.gyro.attitude);
        string _str_current_message = "";
        if (q_last_attitude!= _q_current_attitude)
        {

            q_differential_attitude_x = q_last_attitude.x - _q_current_attitude.x;
            q_differential_attitude_y = q_last_attitude.y - _q_current_attitude.y;
            q_differential_attitude_z = q_last_attitude.z - _q_current_attitude.z;
            q_differential_attitude_w = q_last_attitude.w - _q_current_attitude.w;

            _str_current_message = _str_current_message + "X: " + q_differential_attitude_x;
            _str_current_message = _str_current_message + "Y: " + q_differential_attitude_y;
            _str_current_message = _str_current_message + "Z: " + q_differential_attitude_z;
            _str_current_message = _str_current_message + "W: " + q_differential_attitude_w;

            if (sc_game_manager != null)
            {
                sc_game_manager.ShowText(_str_current_message);
            }
            else
            {
                print(_str_current_message);
            }

            Vector3 _v3_next_move = Vector3.zero;
            _v3_next_move.x = q_differential_attitude_x;
            _v3_next_move.y = q_differential_attitude_y;

            transform.Translate(_v3_next_move);

            q_last_attitude = _q_current_attitude;

        }
	}

    /********************************************/
    // From Unity documentation
    // The Gyroscope is right-handed.  Unity is left handed.
    // Make the necessary change to the camera.
    void GyroModifyCamera()
    {
        transform.rotation = GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
