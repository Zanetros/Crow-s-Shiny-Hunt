using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int currentScene;

    [Header("Cora��es")]
    public int hearts = 3;

    public GameObject heartSprite1;
    public GameObject heartSprite2;
    public GameObject heartSprite3;


    private void Update()
    {
        if (hearts == 0)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        hearts--;
        if (hearts == 2)
        {
            heartSprite1.SetActive(false);
        }
        else if (hearts == 1)
        {
            heartSprite2.SetActive(false);
        }
    }

}
