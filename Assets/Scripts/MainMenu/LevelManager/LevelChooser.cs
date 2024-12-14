using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [Header("Botão Jogar")]
    public GameObject levelPanel;
    public GameObject menuButtons;
    public Button selectedButtom;

    [Header("Voltar dos Levels")]
    public GameObject backPanel;

    public void Start()
    {
        selectedButtom.Select();
    }

    public void Play()
    {
        menuButtons.SetActive(false);
        levelPanel.SetActive(true);
        backPanel.SetActive(true);
    }

    public void BackToMenu()
    {     
        backPanel.SetActive(false);
        levelPanel.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void PlayLevelNumber(int level)
    {
        SceneManager.LoadScene(level);
    }
}
