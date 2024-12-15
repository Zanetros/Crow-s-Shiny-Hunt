using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    public Button startSelectecButtom;
    public Button backSelectedButtom;

    [Header("Botão Jogar")]
    public GameObject mainScreen;
    public GameObject levelScreen;

    [Header("Voltar dos Levels")]
    public GameObject backPanel;

    public void Start()
    {
        startSelectecButtom.Select();
    }

    public void LevelScreen()
    {
        mainScreen.SetActive(false);
        levelScreen.SetActive(true);
        backSelectedButtom.Select();
    }

    public void BackToMenu()
    {     
        levelScreen.SetActive(false);
        mainScreen.SetActive(true);
        startSelectecButtom.Select();
    }

    public void BackToLevel(GameObject levelPanel)
    {
        levelPanel.SetActive(false);
        backSelectedButtom.Select();
    }

    public void ChooseLevel(GameObject panel)
    {
        panel.SetActive(true); 
    }

    public void ButtomSelected(Button selected)
    {
        selected.Select();
    }

    public void PlayLevelNumber(int level)
    {
        SceneManager.LoadScene(level);
    }
}
