using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private int currentScene;
    
    [Header("Painel Menu")]
    public GameObject menuPanel;

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
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
