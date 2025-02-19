using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectableInterface : MonoBehaviour
{
    public static CollectableInterface instance;
    
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }

    public void ManageUI()
    {
        coinText.text = "X" + CollectablesManager.Instance.coinCount.ToString();
    }
}
