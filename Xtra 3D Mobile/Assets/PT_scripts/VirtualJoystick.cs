using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Virtual joystick for mobile joystick control
/// </summary>
public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image backPanel;
    public Image knob;

    public Vector3 InputDirection { get; set; }

    /// <summary>
    /// Get the joystick UI.
    /// </summary>
    private void Start()
    {
        //backPanel = GetComponent<Image>();
        //knob = transform.GetChild(0).GetComponent<Image>();
    }

    /// <summary>
    /// Drag the knob of the joystick.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        Vector2 position = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle
            (backPanel.rectTransform,
                pointerEventData.position,
                pointerEventData.pressEventCamera,
                out position))
        {
            // Get the touch position
            position.x = (position.x / backPanel.rectTransform.sizeDelta.x);
            position.y = (position.y / backPanel.rectTransform.sizeDelta.y);

            // Calculate the move position
            float x = (backPanel.rectTransform.pivot.x == 1) ?
                position.x * 2 + 1 : position.x * 2 - 1;
            float y = (backPanel.rectTransform.pivot.y == 1) ?
                position.y * 2 + 1 : position.y * 2 - 1;

            // Get the input position
            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ?
                InputDirection.normalized : InputDirection;

            // Move the knob
            knob.rectTransform.anchoredPosition =
                new Vector3(InputDirection.x * (backPanel.rectTransform.sizeDelta.x / 3),
                    InputDirection.z * (backPanel.rectTransform.sizeDelta.y / 3));
        }
    }

    /// <summary>
    /// Click on the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        OnDrag(pointerEventData);
    }

    /// <summary>
    /// Click off the knob.
    /// </summary>
    /// <param name="pointerEventData">Data from the touch.</param>
    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        InputDirection = Vector3.zero;
        knob.rectTransform.anchoredPosition = Vector3.zero;
    }
}
