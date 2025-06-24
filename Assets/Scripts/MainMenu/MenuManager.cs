using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private int currentScene;
    public bool isPaused;
    public ScoreManager scoreManager;
    
    [Header("Painel Menu")]
    public GameObject menuPanel;
    public GameObject optionsMenu;

    private bool openMenu;
    
    public void OpenMenu()
    {      
        if (scoreManager.isDead | scoreManager.levelCompleted) {  return; }
        
        if (!openMenu)
        {
            isPaused = true;
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
            
            Gamepad gamepad = Gamepad.current;

            if (gamepad == null)
            {
                GameManager.instance.mouse.SetActive(false);
            }

            else
            {
                GameManager.instance.mouse.SetActive(true);
            }
        }
        else
        {
            isPaused = false;
            menuPanel.SetActive(false);
            optionsMenu.SetActive(false);
            Time.timeScale = 1f;
            GameManager.instance.mouse.SetActive(false);
        }
        openMenu = !openMenu;
    }

    public void RestartLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToOptions()
    {
        optionsMenu.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        optionsMenu.SetActive(false);
        menuPanel.SetActive(true);
    }
}
