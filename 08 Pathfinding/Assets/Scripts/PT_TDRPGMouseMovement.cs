using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_TDRPGMouseMovement : MonoBehaviour
{
    public float fl_PC_Move_Speed;
    public float fl_proximity_offset = 0.1f;
    public string CurrentStatus;

    private Vector2 v2_last_mouse_position;
    private Vector2 nextTarget;
    private Vector2 v2_movement;
    // Use this for initialization
    void Start()
    {
        nextTarget = transform.position;
        v2_last_mouse_position = transform.position;
        CurrentStatus = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //set new target
            v2_last_mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //need to align this with the play grid somehow?
        }
        //Move towards target
        MoveToTarget();

    }

    void MoveToTarget()
    {
        //if you have reached the near target but not the click point
        if (IsNearTarget(nextTarget))
        {
            if (!IsNearTarget(v2_last_mouse_position))
            {
                nextTarget = FindNextTarget();
                CurrentStatus = "Moving";
            }
            else
            {
                //Last moue click reached
                CurrentStatus = "Idle";
            }
        }
        else
        {
            CurrentStatus = "Moving";
        }

        if (CurrentStatus == "Moving")
        {
           transform.position = Vector2.MoveTowards(transform.position, nextTarget, (fl_PC_Move_Speed * Time.deltaTime));
        }
    }

    bool IsNearTarget(Vector2 _CurrentTarget)
    {
        //Work out when the mover is close to the click spot and stop
        //temporary proximity bounds
        float _fl_right = (transform.position.x + fl_proximity_offset);
        float _fl_left = (transform.position.x - fl_proximity_offset);
        float _fl_bottom = (transform.position.y + fl_proximity_offset);
        float _fl_top = (transform.position.y - fl_proximity_offset);

        return (_fl_right > _CurrentTarget.x && _fl_left < _CurrentTarget.x) && (_fl_bottom > _CurrentTarget.y && _fl_top < _CurrentTarget.y);

    }

    Vector2 FindNextTarget()
    {
        //generate list of points and distances (this time orthoganal only)
        Vector2[] _ListOfPossible = new Vector2[4];
        float[] _listDistances = new float[4];
        v2_movement = transform.position;
        //up
        _ListOfPossible[0] = v2_movement + (Vector2.up * fl_PC_Move_Speed);
        //right
        _ListOfPossible[1] = v2_movement + (Vector2.right * fl_PC_Move_Speed);
        //down
        _ListOfPossible[2] = v2_movement + (Vector2.down * fl_PC_Move_Speed);
        //left
        _ListOfPossible[3] = v2_movement + (Vector2.left * fl_PC_Move_Speed);

        //calculate the distance between each point and the mouse click
        for (int index = 0; index<_ListOfPossible.Length;index++)
        {
            _listDistances[index] = Vector2.Distance(_ListOfPossible[index], v2_last_mouse_position);
        }

        //work out the point closest to the goal
        int indexOfClosest = 0;
        for (int index = 1; index < _listDistances.Length; index++)
        {
            if(_listDistances[index]< _listDistances[indexOfClosest])
            {
                //is it reachable
                if (IsReachable(_ListOfPossible[index]))
                {
                    indexOfClosest = index;
                }
                
            }
        }

        return _ListOfPossible[indexOfClosest];
    }

    bool IsReachable(Vector2 _targetPoint)
    {
        Vector2 direction = (_targetPoint - (Vector2)transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, fl_PC_Move_Speed);
        if (hit.collider != null)
        {
            if (hit.distance < fl_PC_Move_Speed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }
}

