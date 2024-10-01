using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private int currentScene;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider playerCol;
    public bool ghostMode;

    [Header("Corroutine Variables")]
    public float waitForBumping = 0.4f;
    public float ghostTime = 1.3f;
    public float flashPlayer = 0.14f;
    public GameObject crowMesh;

    [Header("Corações")]
    public int hearts = 3;

    public GameObject heartSprite1;
    public GameObject heartSprite2;
    public GameObject heartSprite3;

    public void Awake()
    {
        playerCol = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (!ghostMode)
            {
                StartCoroutine(WaitForBumping());
                StartCoroutine(CollisionInvencibility());
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
            else { Debug.Log("Ghosting"); }
        }               
    }

    public IEnumerator WaitForBumping()
    {
        animator.SetBool("Bump", true);
        playerCol.enabled = false;
        yield return new WaitForSeconds(waitForBumping);
        playerCol.enabled = true;
        animator.SetBool("Bump", false);
    }

    public IEnumerator CollisionInvencibility()
    {
        StartCoroutine(FlashPlayer());
        ghostMode = true;
        yield return new WaitForSeconds(ghostTime);
        ghostMode = false;
    }

    public IEnumerator FlashPlayer()
    {
        yield return new WaitForSeconds(.1f);
        if (PlayerMovement.isDead)
        {
            Debug.Log("DEAD");
        }
        else
        {
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(false);
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(true);
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(false);
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(true);
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(false);
            yield return new WaitForSeconds(flashPlayer);
            crowMesh.SetActive(true);
        }
    }
}
