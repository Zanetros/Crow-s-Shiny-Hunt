using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool collected = false;
    
    public string id;

    private void Start()
    {
        DataPersistenceManager.instance.LoadCoin(id, collected, this.gameObject);
        
        if (!gameObject.activeSelf)
        {
            CollectablesUI.instance.collectablesCount++;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectablesManager.instance.coinsMenu += 1;
            collected = true;
            CollectablesUI.instance.ManageUI();
            gameObject.SetActive(false);
        }
    }
}
