using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private int currentScene;
    public ScoreManager scoreManager;
    
    [Header("Painel Menu")]
    public GameObject menuPanel;
    public Button selectedButton;

    private bool openMenu;

    public void OpenMenu()
    {      
        if (scoreManager.isDead) {  return; }
        
        if (!openMenu)
        {
            Debug.Log("Menu Open");
            selectedButton.Select();
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
        else
        {

            Debug.Log("Menu Closed");
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
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
}
