using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            scoreManager.TimeToFinish();
            scoreManager.ScoreText();
        }
    }
}
