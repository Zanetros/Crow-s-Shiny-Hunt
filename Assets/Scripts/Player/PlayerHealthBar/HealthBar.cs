using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int currentScene;

    [Header("Corações")]
    public int hearts = 3;

    public GameObject heartSprite1;
    public GameObject heartSprite2;
    public GameObject heartSprite3;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
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

}
