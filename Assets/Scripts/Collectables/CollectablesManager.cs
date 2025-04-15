using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesManager : MonoBehaviour, IDataPersistence
{
    public static CollectablesManager instance;
    
    public  int coinsCollected;
    public  int coinsMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void Update()
    {
        Debug.Log(coinsMenu);
    }

    public void LoadData(GameData data)
    {
        coinsMenu = data.coinsCollected;
    }

    public void SaveData(ref GameData data)
    {
        data.coinsCollected = coinsMenu;
    }
}
