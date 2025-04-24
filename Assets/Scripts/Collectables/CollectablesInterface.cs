using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesInterface : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    [Header("Moedas coletadas de cada Fase")]
    [SerializeField] private TextMeshProUGUI fase1Text;
    [SerializeField] private TextMeshProUGUI fase2Text;

    private void Update()
    {
        coinText.text = "X " + CollectablesManager.instance.coinsMenu;        
    }

    public void CoinsLevel1()
    {
        if (CollectablesManager.instance.coinsMenu == 0)
        {
            fase1Text.text = "Moedas - 0/6";
        }
        
        else if (CollectablesManager.instance.coinsMenu > 0)
        {
            fase1Text.text = "Moedas - " + CollectablesManager.instance.fase1 + "/6";
        }
    }
    
    public void CoinsLevel2()
    {
        
    }
}
