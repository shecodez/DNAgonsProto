using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image joystickBG;
    Image joystickKnob;
    Vector3 inputVector;

    void Start()
    {
        joystickBG = GetComponent<Image>();
        joystickKnob = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);
            
            // if vjsBG is anchored: bottom left
            inputVector = new Vector3(pos.x * 2 - 1, 0f, pos.y * 2 - 1);
            /*// if vjsBG is anchored bottom right
            inputVector = new Vector3(pos.x * 2 + 1, 0f, pos.y * 2 - 1);*/

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            
            // Move Joystick knob
            joystickKnob.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 3),
                            inputVector.z * (joystickBG.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        // Reset
        inputVector = Vector3.zero;
        joystickKnob.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");

    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }
}