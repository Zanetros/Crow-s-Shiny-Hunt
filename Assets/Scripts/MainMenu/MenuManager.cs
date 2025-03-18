using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Button selectedButton;

    private bool openMenu;

    public void OpenMenu()
    {      
        if (scoreManager.isDead) {  return; }
        
        if (!openMenu)
        {
            isPaused = true;
            selectedButton.Select();
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
        else
        {
            isPaused = false;
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        openMenu = !openMenu;
    }

    public void RestartLevel()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        CollectablesUI.instance.cointText.text = "X " + PlayerPrefs.GetInt("coins");
        DataPersistenceManager.instance.ClearCoins();
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        DataPersistenceManager.instance.ClearCoins();
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
