using UnityEngine;
using UnityEngine.InputSystem;

public class TouchHandler : MonoBehaviour
{
    [SerializeField] private InputActionReference TouchActivate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TouchActivateRoom(InputAction.CallbackContext context)
    {
        Vector2 mouseFromScreen = Camera.main.ScreenToWorldPoint(TouchActivate.action.ReadValue<Vector2>());

    }

    void OnEnable()
    {
        TouchActivate.action.started += TouchActivateRoom;
    }
    void OnDisable()
    {
        TouchActivate.action.started -= TouchActivateRoom;
    }
}
