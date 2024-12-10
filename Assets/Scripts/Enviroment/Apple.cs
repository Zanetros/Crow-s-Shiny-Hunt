using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private string player = "Player";
    private string fall = "fall";

    public Rigidbody [] rb;
    public Animator [] animator;
    private float timeToFall = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            StartCoroutine(WaitForApple());
        }
    }

    public IEnumerator WaitForApple()
    {
        for (int i = 0; i < animator.Length; i++)
        {
            animator[i].SetBool(fall, true);
        }

        yield return new WaitForSeconds(timeToFall);
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].useGravity = true;
        }
    }
}
