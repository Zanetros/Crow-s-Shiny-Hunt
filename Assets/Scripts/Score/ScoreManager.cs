using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int levelCoinsCollected;
    public static string currentLevel;
    
    [Header("Tempo")]
    public TextMeshProUGUI timerText;
    public float _time;
    public int addDecimal;
    public bool timeStoped;

    [Header("Anima��o")]
    [SerializeField] Animator animator;
    public string death = "Death";


    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip audioClip;

    public float timeToFinish;
    public TextMeshProUGUI rankText;
    public GameObject rankPanel;
    public bool isDead = false;
    public bool levelCompleted = false;

    public bool rankS;
    public bool rankA;
    public bool rankB;
    public bool rankF;

    [Header("Rank Variaveis")]
    public float rank_A;
    public float rank_B;

    [Header("Barra de Vida")]
    public HealthBar healthBar;
    
    [Header("Save Coin")]
    public int fase1;
    public int fase2;
    public int fase3;
    public int fase4;
    public int rank;
    public int rank2;
    
    [Header("Sprites Ranks")]
    public Image mainImage;
    public Sprite spriteRankS;
    public Sprite spriteRankA;
    public Sprite spriteRankB;
    public Sprite spriteRankF;
    
    

    private void Awake()
    {
        Time.timeScale = 1f;
        rankPanel.SetActive(false);
        isDead = false;
        levelCompleted = false;
        currentLevel = SceneManager.GetActiveScene().name;
        rankF = false;
    }

    private void Start()
    {
        GameManager.instance.mouse = GameObject.Find("VirtualMouseUI");
        GameManager.instance.mouse.SetActive(false); 
    }

    private void Update()
    {
        Timer();
        TimeToFinish();
        HandleRanks();

        if (isDead | levelCompleted) { return; }

        if (healthBar.hearts == 0)
        {
            StartCoroutine(WaitForDeath());
            isDead = true;
            AudioSource.PlayOneShot(audioClip);
            rankPanel.SetActive(true);
            GameManager.instance.mouse.SetActive(true);
            mainImage.sprite = spriteRankF;
            rankF = true;
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
        if (_time < 10)
        {
            timerText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        }
        else
        {
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }

    public void TimeToFinish()
    {    
        if (healthBar.hearts >= 3)
        {
            if (_time <= timeToFinish)
            {
                rankS = true;
            }
            else if (_time <= rank_A * timeToFinish) // only reach here if _time > timeToFinish
            {
                rankS = false;
                rankA = true;
            }
            else if (_time <= rank_B * timeToFinish) //only reach here if _time > 1.3 * timeToFinish
            {
                rankA = false;
                rankB = true;
            }
        }

        else
        {
            if (healthBar.hearts == 2) // only reach here if _time > timeToFinish
            {
                rankS = false;
                rankA = true;
            }
            else if (healthBar.hearts == 1) //only reach here if _time > 1.3 * timeToFinish
            {
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
            mainImage.sprite = spriteRankS;
            rankS = false;
        }
        
        else if (rankA)
        {
            rankPanel.SetActive(true);
            mainImage.sprite = spriteRankA;
            rankA = false;
        }

        else if (rankB)
        {
            rankPanel.SetActive(true);
            mainImage.sprite = spriteRankB;
            rankB = false;
        }
    }

    public void HandleRanks()
    {
        if (SceneManager.GetActiveScene().name == "Fase Floresta")
        {
            if (rankS)
            {
                rank = 3;
            }
        
            else if (rankA)
            {
                if (CollectablesManager.instance.rank == 3 || CollectablesManager.instance.rank == 2){ return; }
                rank = 2;
            }
        
            else if (rankB)
            {
                if (CollectablesManager.instance.rank == 3 || CollectablesManager.instance.rank == 2){ return; }
                rank = 1;
            }
        }
        
        else if (SceneManager.GetActiveScene().name == "Fase Mansão")
        {
            if (rankS)
            {
                rank2 = 3;
            }
        
            else if (rankA)
            {
                if (CollectablesManager.instance.rank == 3 || CollectablesManager.instance.rank == 2){ return; }
                rank2 = 2;
            }
        
            else if (rankB)
            {
                if (CollectablesManager.instance.rank == 3 || CollectablesManager.instance.rank == 2){ return; }
                rank2 = 1;
            }
        }
    }

    public void FinishLevel()
    {
        if (levelCompleted)
        {
            FinalizeCoins();
            DataPersistenceManager.instance.SaveGame();
            DataPersistenceManager.instance.LoadGame();
        }
        
        GameManager.instance.mouse.SetActive(true);
        rankPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void FinalizeCoins()
    {
        for (int i = 0; i < CollectablesUI.instance.coins.Count; i++)
        {
            if (!CollectablesUI.instance.coins[i].gameObject.activeSelf)
            {
                DataPersistenceManager.instance.AddCoin(CollectablesUI.instance.coins[i].id, CollectablesUI.instance.coins[i].collected = true);
                SaveCollectables();
            }
        }
    }

    public void SaveCollectables()
    {
        if (SceneManager.GetActiveScene().name == "Fase Floresta")
        {
            fase1++;
            CollectablesManager.instance.rank = rank;
            CollectablesManager.instance.fase1 = fase1;
            CollectablesManager.instance.coinsMenu += CollectablesManager.instance.coinsCollected;
            DataPersistenceManager.instance.SaveCollectedCoins("Fase Floresta", CollectablesManager.instance.fase1);
        }
        
        else if (SceneManager.GetActiveScene().name == "Fase Mansão")
        {
            fase2++;
            CollectablesManager.instance.rank2 = rank2;
            CollectablesManager.instance.fase2 = fase2;
            CollectablesManager.instance.coinsMenu += CollectablesManager.instance.coinsCollected;
            DataPersistenceManager.instance.SaveCollectedCoins("Fase Mansão", CollectablesManager.instance.fase2);
        }
    }
}
