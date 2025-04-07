using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesInterface : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Update()
    {
        coinText.text = "X " + CollectablesManager.instance.coinsMenu;        
    }
}
