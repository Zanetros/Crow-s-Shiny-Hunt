using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesInterface : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    [Header("Moedas coletadas de cada Fase")]
    [SerializeField] private TextMeshProUGUI fase1Text;
    [SerializeField] private TextMeshProUGUI fase2Text;

    [Header("Rank da Fase")]
    [SerializeField] private Image mainImage1;
    [SerializeField] private Image mainImage2;
    [SerializeField] private Sprite rankS;
    [SerializeField] private Sprite rankA;
    [SerializeField] private Sprite rankB;
    

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
        if (CollectablesManager.instance.coinsMenu == 0)
        {
            fase2Text.text = "Moedas - 0/6";
        }
        
        else if (CollectablesManager.instance.coinsMenu > 0)
        {
            fase2Text.text = "Moedas - " + CollectablesManager.instance.fase2 + "/6";
        }
    }

    public void Level1Rank()
    {
        if (CollectablesManager.instance.rank == 3)
        {
            mainImage1.sprite = rankS;
        }
        
        else if (CollectablesManager.instance.rank == 2)
        {
            mainImage1.sprite = rankA;
        }
        
        else if (CollectablesManager.instance.rank == 1)
        {
            mainImage1.sprite = rankB;
        }
    }

    public void Level2Rank()
    {
        if (CollectablesManager.instance.rank == 3)
        {
            mainImage2.sprite = rankS;
        }
        
        else if (CollectablesManager.instance.rank == 2)
        {
            mainImage2.sprite = rankA;
        }
        
        else if (CollectablesManager.instance.rank == 1)
        {
            mainImage2.sprite = rankB;
        }
    }
}
