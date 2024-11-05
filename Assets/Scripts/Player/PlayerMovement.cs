using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionReference moveLeft;
    public InputActionReference moveRight;
    public InputActionReference moveUp;
    public InputActionReference moveDown;

    public PlayerControls playerControls;

    [Header("Movimentação")]
    public static float moveSpeed;
    public float defaultMoveSpeed;
    public float horizontalSpeed;
    public static bool isDead;

    [Header("Mecanica de velocidade")]
    public float maxVelocity = 15f;
    public float minVelocity = 9f;
    private bool max;
    private bool min;
    private bool normal;

    [Header("Animação")]
    [SerializeField] private Animator animator;
    public string Fast = "Fast";

    [Header("UI")]
    public GameObject maxSprite;
    public GameObject minSprite;
    public GameObject normalSprite;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        isDead = false;
        normal = true;
        moveSpeed = defaultMoveSpeed;
    }

    private void Update()
    {
        if (isDead) return;

        MovePlayerForward();

        HandleMovement();
        IncreaseVelocity();
        DecreaseVelocity();
        ChangeVelocityUI();
    }

    #region Player Movement Input
    private void OnMoveLeft()
    {
        if (this.gameObject.transform.position.x > LevelBoundary.instance.leftSide)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        }
    }

    private void OnMoveRight()
    {
        if (this.gameObject.transform.position.x < LevelBoundary.instance.rightSide)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
        }
    }

    private void OnMoveUp()
    {
        if (this.gameObject.transform.position.y < LevelBoundary.instance.topSide)
        {
            transform.Translate(Vector3.up * Time.deltaTime * horizontalSpeed);
        }
    }

    private void OnMoveDown()
    {
        if (this.gameObject.transform.position.y > LevelBoundary.instance.bottomSide)
        {
            transform.Translate(Vector3.down * Time.deltaTime * horizontalSpeed);
        }
    }

    private void HandleMovement()
    {
        bool isLeft = playerControls.Gameplay.MoveLeft.ReadValue<float>() > 0.1f;

        if (isLeft)
        {
            OnMoveLeft();
        }

        bool isRight = playerControls.Gameplay.MoveRight.ReadValue<float>() > 0.1f;

        if (isRight)
        {
            OnMoveRight();
        }

        bool isDown = playerControls.Gameplay.MoveDown.ReadValue<float>() > 0.1f;

        if (isDown)
        {
            OnMoveDown();
        }

        bool isUp = playerControls.Gameplay.MoveUp.ReadValue<float>() > 0.1f;

        if (isUp)
        {
            OnMoveUp();
        }
    }
    #endregion

    private void MovePlayerForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    private void IncreaseVelocity()
    {
        if (min && Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveSpeed = defaultMoveSpeed;
            normal = true;
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
                normal = false;
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
            normal = true;
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
                normal = false;
                min = true;
            }
        }
    }

    private void ChangeVelocityUI()
    {
        if (min)
        {
            minSprite.SetActive(true);
            normalSprite.SetActive(false);
        }

        else if (max)
        {
            maxSprite.SetActive(true);
            normalSprite.SetActive(false);
        }

        else if (!min && !max)
        {
            maxSprite.SetActive(false);
            minSprite.SetActive(false);
            normalSprite.SetActive(true);
        }
    }
}
