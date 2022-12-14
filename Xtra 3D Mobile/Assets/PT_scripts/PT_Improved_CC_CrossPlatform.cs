using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//based on Character controller script from  https://github.com/valgoun/CharacterController and https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

public class PT_Improved_CC_CrossPlatform : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpHeight = 2f;
    public float Gravity = -9.81f;
    public float GroundDistance = 0.2f;
    public float DashDistance = 5f;
    public float FallMultiplier = 3.0f;
    public LayerMask Ground;
    public Vector3 Drag;
    public bool useOnScreenController;
    public VirtualJoystick MovementHandler;

    private bool jumpPressed = false;
    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _groundChecker = transform.GetChild(0);
    }

    void Update()
    {


        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        Vector3 move = new Vector3(0, 0, 0);
        if (!useOnScreenController)
        {
            move.x = Input.GetAxis("Horizontal");
            move.z = Input.GetAxis("Vertical");
        }
        else
        {
            move.x = MovementHandler.InputDirection.x;
            move.z = MovementHandler.InputDirection.z;
            
        }

        
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
            transform.forward = move;

        if ((Input.GetButtonDown("Jump")|| jumpPressed) && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            
        }
            




        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Dash");
            _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
        }

        //start to fall
        if (_velocity.y < 0)
        {
            _velocity.y += (Gravity * Time.deltaTime) * FallMultiplier;
        }
        else //going up
        {
            _velocity.y += Gravity * Time.deltaTime;
        }


        _velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);


        //clean up the jump
        jumpPressed = false;
    }

    public void JumpAction()
    {
        jumpPressed = true;
    }
}
