using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    public TextMeshProUGUI cointText;
    public int coinsToCollect;
    public int collectablesCount;

    public List<GameObject> collectedCoins;
    public List<Coin> coins;


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

        for (int i = 0; i < collectedCoins.Count; i++)
        {
            if (!collectedCoins[i].gameObject.activeSelf)
            {
                collectablesCount++;
                cointText.text = collectablesCount + "/" + coinsToCollect;
            }
        }
    }

    public void ManageUI()
    {
        if (collectablesCount > 0)
        {
            collectablesCount++;
            cointText.text = collectablesCount + "/" + coinsToCollect;
        }

        else
        {
            cointText.text = CollectablesManager.coinsCollected + "/" + coinsToCollect;
        }
    }
}
