using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollLevels : MonoBehaviour
{
    [SerializeField] private RectTransform moveLeft;
    [SerializeField] private RectTransform moveRight;
    [SerializeField] private RectTransform content;

    [SerializeField] private Vector3 movePosLeft;
    [SerializeField] private Vector3 movePosRight;
    
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    public void Start()
    {
        if (moveLeft.position.x == leftLimit)
        {
            leftArrow.SetActive(false);
        }
    }

    private void Update()
    {
        DontMoveRight();
        DontMoveLeft();
    }

    private void DontMoveLeft()
    {
        if (moveLeft.position.x >= leftLimit)
        {
            leftArrow.SetActive(false);
        }

        else 
        {
            leftArrow.SetActive(true);
        }
    }

    private void DontMoveRight()
    {
        if (moveRight.position.x <= rightLimit)
        {
            rightArrow.SetActive(false);
        }

        else
        {
            rightArrow.SetActive(true);
        }
    }

    public void MoveLeft()
    {
        content.localPosition -= movePosLeft;
        ButtonRight.isPressed = false;
    }

    public void MoveRight()
    {
        content.localPosition -= movePosRight;
        ButtonLeft.isPressed = false;
    }
}
