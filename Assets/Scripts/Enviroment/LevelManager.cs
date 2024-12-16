using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LevelManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(clip);
            scoreManager.isDead = true;
            scoreManager.selectedButton.Select();
            PlayerMovement.moveSpeed -= 0f;
            scoreManager.timeStoped = true;
            PlayerMovement.isDead = true;
            MoveCamera.isDeadCamera = true;
            scoreManager.ScoreText();
        }
    }
}
