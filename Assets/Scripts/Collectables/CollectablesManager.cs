using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour, IDataPersistence
{
    public static CollectablesManager instance;
    
    public static int coinsCollected;
    public static int coinsMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void LoadData(GameData data)
    {
        coinsCollected = data.coinsCollected;
    }

    public void SaveData(ref GameData data)
    {
        data.coinsCollected = coinsCollected;
    }
}
