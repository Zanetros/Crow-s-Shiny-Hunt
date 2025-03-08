using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectablesManager.coinsCollected += 1;
            CollectablesUI.instance.ManageUI();
            this.gameObject.SetActive(false);
        }
    }
}
