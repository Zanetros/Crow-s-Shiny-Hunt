using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [Header("Tempo")]
    public TextMeshProUGUI timerText;
    public float _time;
    private int scene;

    [Header("Rank da Fase")]
    public float timeToFinish;
    public TextMeshProUGUI rankText;
    public GameObject rankPanel;

    private bool rankS;
    private bool rankA;
    private bool rankB;
    private bool rankF;

    private void Update()
    {
        //AddScore();
        Timer();
    }

    private void Timer()
    {
        _time = Time.timeSinceLevelLoad;
        TimeSpan time = TimeSpan.FromSeconds(_time);
        timerText.text = "Tempo: " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void TimeToFinish()
    {
        if (_time <= timeToFinish)
        {
            Debug.Log("Rank S");
            rankS = true;
        }
        else if (_time <= 1.1f * timeToFinish) // only reach here if _time > timeToFinish
        {
            Debug.Log("Rank A");
            rankA = true;
        }
        else if (_time <= 1.4f * timeToFinish) //only reach here if _time > 1.3 * timeToFinish
{
            Debug.Log("Rank B");
            rankB = true;
        }
        else  //only reach here if _time > 1.4 * timeToFinish
        {
            Debug.Log("Rank F");
            rankF = true;
        }
    }

    public void ScoreText()
    {
        if (rankS)
        {
            rankPanel.SetActive(true);
            rankText.text = "Rank S";
            rankS = false;
        }
        
        else if (rankA)
        {
            rankPanel.SetActive(true);
            rankText.text = "Rank A";
            rankA = false;
        }

        else if (rankB)
        {
            rankPanel.SetActive(true);
            rankText.text = "Rank B";
            rankB = false;
        }

        else
        {
            rankPanel.SetActive(true);
            rankText.text = "Rank F";
            rankF = false;
        }
    }

    public void FinishLevel()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        rankPanel.SetActive(false);
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
}
