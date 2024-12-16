using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("Tempo")]
    public TextMeshProUGUI timerText;
    public float _time;
    private int scene;
    public bool timeStoped;

    [Header("Animação")]
    [SerializeField] Animator animator;
    public string death = "Death";

    [Header("Rank da Fase")]

    public Button selectedButton;

    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip audioClip;

    public float timeToFinish;
    public TextMeshProUGUI rankText;
    public GameObject rankPanel;
    public bool isDead = false;

    public bool rankS;
    public bool rankA;
    public bool rankB;

    [Header("Rank Variaveis")]
    public float rank_A;
    public float rank_B;

    [Header("Barra de Vida")]
    public HealthBar healthBar;

    private void Awake()
    {
        Time.timeScale = 1f;
        rankPanel.SetActive(false);
        isDead = false;
    }

    private void Update()
    {
        Timer();
        TimeToFinish();

        if (isDead) { return; }

        if (healthBar.hearts == 0)
        {
            StartCoroutine(WaitForDeath());
            isDead = true;
            AudioSource.PlayOneShot(audioClip);
            selectedButton.Select();
            rankPanel.SetActive(true);
            rankText.text = "F";
        }
    }

    public IEnumerator WaitForDeath()
    {
        animator.SetBool(death, true);
        PlayerMovement.moveSpeed -= 0f;
        timeStoped = true;
        PlayerMovement.isDead = true;
        MoveCamera.isDeadCamera = true;
        yield return new WaitForSeconds(1.1f);
    }

    private void Timer()
    {
        if (timeStoped)
        {
            return;
        }
        _time = Time.timeSinceLevelLoad;
        TimeSpan time = TimeSpan.FromSeconds(_time);
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void TimeToFinish()
    {    
        if (healthBar.hearts >= 3)
        {
            if (_time <= timeToFinish)
            {
                Debug.Log("S");
                rankS = true;
            }
            else if (_time <= rank_A * timeToFinish) // only reach here if _time > timeToFinish
            {
                Debug.Log("A");
                rankS = false;
                rankA = true;
            }
            else if (_time <= rank_B * timeToFinish) //only reach here if _time > 1.3 * timeToFinish
            {
                Debug.Log("B");
                rankA = false;
                rankB = true;
            }
        }

        else
        {
            if (healthBar.hearts == 2) // only reach here if _time > timeToFinish
            {
                Debug.Log("A");
                rankS = false;
                rankA = true;
            }
            else if (healthBar.hearts == 1) //only reach here if _time > 1.3 * timeToFinish
            {
                Debug.Log("B");
                rankA = false;
                rankB = true;
            }
        }
    }

    public void ScoreText()
    {
        if (rankS)
        {
            rankPanel.SetActive(true);
            rankText.text = "S";
            rankS = false;
        }
        
        else if (rankA)
        {
            rankPanel.SetActive(true);
            rankText.text = "A";
            rankA = false;
        }

        else if (rankB)
        {
            rankPanel.SetActive(true);
            rankText.text = "B";
            rankB = false;
        }
    }

    public void FinishLevel()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        rankPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
