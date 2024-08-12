using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimentação")]
    public static float moveSpeed;
    public float defaultMoveSpeed;
    public float horizontalSpeed;

    [Header("Mecanica de velocidade")]
    public float maxVelocity = 15f;
    public float minVelocity = 9f;
    private bool max;
    private bool min;

    [Header("Animação")]
    [SerializeField] private Animator animator;
    public string Fast = "Fast";

    [Header("UI")]
    public GameObject maxSprite;
    public GameObject minSprite;

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
        ChangeVelocityUI();
    }

    private void MovePlayerForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void MovePlayerHorizontal()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.instance.leftSide) 
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }           
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.instance.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    private void MovePlayerVertical()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (this.gameObject.transform.position.y < LevelBoundary.instance.topSide)
            {
                transform.Translate(Vector3.up * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (this.gameObject.transform.position.y > LevelBoundary.instance.bottomSide)
            {
                transform.Translate(Vector3.down * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    private void IncreaseVelocity()
    {
        if (min && Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveSpeed = defaultMoveSpeed;
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
                animator.SetBool(Fast, true);
                max = true;
            }
        }               
    }

    private void DecreaseVelocity()
    {
        if (max && Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveSpeed = defaultMoveSpeed;
            animator.SetBool(Fast, false);
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

    private void ChangeVelocityUI()
    {
        if (min)
        {
            minSprite.SetActive(true);
        }

        else if (max)
        {
            maxSprite.SetActive(true);
        }

        else if (!min && !max)
        {
            maxSprite.SetActive(false);
            minSprite.SetActive(false);
        }
    }
}
