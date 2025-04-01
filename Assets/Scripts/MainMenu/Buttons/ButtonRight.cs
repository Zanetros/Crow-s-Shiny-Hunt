using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ScrollLevels scrollLevels;
    public static bool isPressed;

    public void Update()
    {
        if (isPressed)
        {
            scrollLevels.MoveRight();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
