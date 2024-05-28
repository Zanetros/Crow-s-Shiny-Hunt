using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float life;
    public Image healthBar;
    private int currentScene;


    private void Update()
    {
        if (life <= 0)
        {
            currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            life -= 0.35f;
            healthBar.fillAmount = life;
        }
    }

}
