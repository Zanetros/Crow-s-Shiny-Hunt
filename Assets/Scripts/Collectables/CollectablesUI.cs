using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    public TextMeshProUGUI cointText;
    public int collectablesCount;

    [SerializeField] private List<GameObject> collectedCoins;

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
        collectablesCount = CollectablesManager.coinsCollected;       

        for (int i = 0; i < collectedCoins.Count; i++)
        {
            if (!collectedCoins[i].gameObject.activeSelf)
            {
                collectablesCount++;
            }
        }

        ManageUI();
    }

    public void ManageUI()
    {
        DataPersistenceManager.instance.CountCoins(collectablesCount);
        cointText.text = collectablesCount + "/6";
    }
}
