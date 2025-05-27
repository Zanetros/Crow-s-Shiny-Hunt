using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{

    [Header("Bot�o Jogar")]
    public GameObject mainScreen;
    public GameObject levelScreen;
    public GameObject options;

    [Header("Voltar dos Levels")]
    public GameObject backPanel;
    

    public void LevelScreen()
    {
        mainScreen.SetActive(false);
        levelScreen.SetActive(true);
    }

    public void BackToMenu()
    {     
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void BackFromConfig()
    {
        options.SetActive(false);
        mainScreen.SetActive(true);
    }

    public void OpenConfig()
    {
        mainScreen.SetActive(false);
        options.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToLevel(GameObject levelPanel)
    {
        levelPanel.SetActive(false);
    }

    public void ChooseLevel(GameObject panel)
    {
        panel.SetActive(true); 
    }

    public void PlayLevelNumber(int level)
    {
        SceneManager.LoadScene(level);
    }
}
