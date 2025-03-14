using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesInterface : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        //CollectablesManager.coinsMenu += PlayerPrefs.GetInt("coins");
        CollectablesManager.coinsMenu =+ CollectablesManager.coinsCollected;
        coinText.text = "X " + CollectablesManager.coinsMenu;        
    }
}
