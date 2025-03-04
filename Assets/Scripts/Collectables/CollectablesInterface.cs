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
        CollectablesManager.coinsMenu += PlayerPrefs.GetInt("coins");
        coinText.text = "X " + CollectablesManager.coinsMenu;        
    }
}
