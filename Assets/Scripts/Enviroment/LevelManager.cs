using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
            scoreManager.levelCompleted = true;
            PlayerMovement.moveSpeed -= 0f;
            scoreManager.timeStoped = true;
            PlayerMovement.levelCompleted = true;
            MoveCamera.isDeadCamera = true;
            
            Gamepad gamepad = Gamepad.current;
            
            if (gamepad == null)
            {
                GameManager.instance.mouse.SetActive(false);
            }

            else
            {
                GameManager.instance.mouse.SetActive(true);
            }
            scoreManager.ScoreText();
        }
    }
}
