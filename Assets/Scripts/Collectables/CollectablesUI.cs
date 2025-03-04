using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    public TextMeshProUGUI cointText;
    
    public static CollectablesUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    public void Start()
    {
        CollectablesManager.coinsCollected = 0;
        cointText.text = "X" + CollectablesManager.coinsCollected;
    }

    public void ManageUI()
    {
        cointText.text = "X" + CollectablesManager.coinsCollected.ToString();
    }
}
