using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private bool collected = false;
    
    [SerializeField] private string id;

    private void Start()
    {
        DataPersistenceManager.instance.LoadCoin(id, collected, this.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectablesManager.coinsCollected += 1;
            collected = true;
            CollectablesUI.instance.ManageUI();
            DataPersistenceManager.instance.AddCoin(id, collected);
            gameObject.SetActive(false);
        }
    }
}
