using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody rb;
    public string player = "Player";
    public string fall = "fall";
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(player))
        {
            StartCoroutine(WaitForApple());
        }
    }

    public IEnumerator WaitForApple()
    {
        animator.SetBool(fall, true);
        yield return new WaitForSeconds(0.8f);
        rb.useGravity = true;
    }
}
