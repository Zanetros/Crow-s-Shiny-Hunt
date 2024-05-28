using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float moveSpeed;
    public float horizontalSpeed;

    [Header("Mecanica de velocidade")]
    private float maxVelocity = 15f;
    private float minVelocity = 9f;
    private bool max;
    private bool min;

    private void Start()
    {
        moveSpeed = 12f;
    }

    private void Update()
    {
        MovePlayerForward();
        MovePlayerHorizontal();
        MovePlayerVertical();

        IncreaseVelocity();
        DecreaseVelocity();
    }

    private void MovePlayerForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void MovePlayerHorizontal()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }           
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    private void MovePlayerVertical()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (this.gameObject.transform.position.y < LevelBoundary.topSide)
            {
                transform.Translate(Vector3.up * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (this.gameObject.transform.position.y > LevelBoundary.bottomSide)
            {
                transform.Translate(Vector3.down * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    private void IncreaseVelocity()
    {
        if (min && Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveSpeed = 12f;
            min = false;
        }

        else
        {
            if (moveSpeed >= maxVelocity && Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Maximo");
            }

            else if (moveSpeed <= maxVelocity && Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveSpeed = +maxVelocity;
                max = true;
            }
        }               
    }

    private void DecreaseVelocity()
    {
        if (max && Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveSpeed = 12f;
            max = false;
        }

        else
        {
            if (moveSpeed <= minVelocity && Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Minimo");
            }

            else if (moveSpeed >= minVelocity && Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveSpeed = +minVelocity;
                min = true;
            }
        }
    }
}
