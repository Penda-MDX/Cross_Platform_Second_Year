using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BopHandler : MonoBehaviour
{
    [SerializeField] private float BopTimer = 0.8f;
    [SerializeField] private GameObject bopCollider;

    private float TimeOut;
    // Update is called once per frame
    void Update()
    {
        if (TimeOut < Time.time)
        {
            bopCollider.SetActive(false);
        }
        Vector3 moveTo = Vector3.zero;
        Vector2 mouseFromScreen = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        moveTo.x = mouseFromScreen.x;
        moveTo.y = mouseFromScreen.y;

        transform.position = moveTo;

        if (Mouse.current.leftButton.isPressed)
        {
            TimeOut = Time.time + BopTimer;
            bopCollider.SetActive(true);
        }
    }
}
