using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_Accelerometer_Rotate_Move : MonoBehaviour {

    public float fl_PC_Move_Speed = 25f;
    public bool bl_filter = true;

    private float q_differential_attitude_x;
    private float q_differential_attitude_y;
    private float q_differential_attitude_z;
    private float q_differential_attitude_w;

    private PT_Game_Manager_Button_Loop sc_game_manager;

    float AccelerometerUpdateInterval = 1.0f / 60.0f;
    float LowPassKernelWidthInSeconds = 1.0f;
    private float LowPassFilterFactor; // tweakable
    private Vector3 lowPassValue = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        LowPassFilterFactor = AccelerometerUpdateInterval / LowPassKernelWidthInSeconds;
        lowPassValue = Input.acceleration;

        if (GameObject.Find("GameManager") != null)
        {
            sc_game_manager = GameObject.Find("GameManager").GetComponent<PT_Game_Manager_Button_Loop>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(bl_filter)
        {
            LowPassFilteredInput();
        }
        else
        {
            UnfilteredInput();
        }

        Vector3 _v3_next_move = Vector3.zero;
        _v3_next_move.x = q_differential_attitude_x;
        _v3_next_move.y = q_differential_attitude_y;

        transform.Translate(_v3_next_move);
    }

   void LowPassFilterAccelerometer()
    {
        Vector3 _v3_temporary_lowPassValue = Vector3.zero;
        //use previous value and new value to generate smoothed inbetween values to prevent sudden spikes
        _v3_temporary_lowPassValue.x = Mathf.Lerp(lowPassValue.x, Input.acceleration.x, LowPassFilterFactor);
        _v3_temporary_lowPassValue.y = Mathf.Lerp(lowPassValue.y, Input.acceleration.y, LowPassFilterFactor);
        _v3_temporary_lowPassValue.z = Mathf.Lerp(lowPassValue.z, Input.acceleration.z, LowPassFilterFactor);
        lowPassValue = _v3_temporary_lowPassValue;
        //return lowPassValue;
    }

    void UnfilteredInput()
    {
        string _str_current_message = "";

        q_differential_attitude_x = Input.acceleration.x;
        q_differential_attitude_y = Input.acceleration.y;
        q_differential_attitude_z = Input.acceleration.z;
        q_differential_attitude_w = 0;


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

    }

    void LowPassFilteredInput()
    {

        string _str_current_message = "";

        //filter the incoming data 
        LowPassFilterAccelerometer();

        q_differential_attitude_x = lowPassValue.x;
        q_differential_attitude_y = lowPassValue.y;
        q_differential_attitude_z = lowPassValue.z;
        q_differential_attitude_w = 0;


        _str_current_message = _str_current_message + "Xb: " + q_differential_attitude_x;
        _str_current_message = _str_current_message + "Yb: " + q_differential_attitude_y;
        _str_current_message = _str_current_message + "Zb: " + q_differential_attitude_z;
        _str_current_message = _str_current_message + "Wb: " + q_differential_attitude_w;

        if (sc_game_manager != null)
        {
            sc_game_manager.ShowText(_str_current_message);
        }
        else
        {
            print(_str_current_message);
        }
    }
}
