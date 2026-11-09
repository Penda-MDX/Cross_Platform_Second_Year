using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BopHandler : MonoBehaviour
{
    [SerializeField] private float BopTimer = 0.8f;
    [SerializeField] private GameObject bopCollider;
    [SerializeField] private InputActionReference AttackBop;


    private float TimeOut;

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (TimeOut < Time.time)
        {
            bopCollider.SetActive(false);
        }

    }

    public void BopActivate(Vector2 pointer)
    {
        Vector3 moveTo = Vector3.zero;
        //Vector2 mouseFromScreen = lookPointer.action.ReadValue<Vector2>();
        moveTo.x = pointer.x;
        moveTo.y = pointer.y;

        transform.position = moveTo;
        TimeOut = Time.time + BopTimer;
        bopCollider.SetActive(true);
    }

    private void DoBopAction(InputAction.CallbackContext context)
    {
        //context.action#
        //
        //
        Vector2 mouseFromScreen = Camera.main.ScreenToWorldPoint(AttackBop.action.ReadValue<Vector2>());
        BopActivate(mouseFromScreen);
    }

    void OnEnable()
    {
        AttackBop.action.started += DoBopAction;
    }
    void OnDisable()
    {
        AttackBop.action.started -= DoBopAction;
    }

}
