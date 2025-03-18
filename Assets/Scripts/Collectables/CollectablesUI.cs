using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesUI : MonoBehaviour
{
    public TextMeshProUGUI cointText;

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

        for (int i = 0; i < collectedCoins.Count; i++)
        {
            if (!collectedCoins[i].gameObject.activeSelf)
            {
                CollectablesManager.coinsCollected++;
            }
        }

        ManageUI();
    }

    public void ManageUI()
    {
        cointText.text = CollectablesManager.coinsCollected + "/6";
    }
}
