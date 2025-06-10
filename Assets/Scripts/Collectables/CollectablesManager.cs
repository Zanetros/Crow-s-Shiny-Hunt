using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectablesManager : MonoBehaviour, IDataPersistence
{
    public static CollectablesManager instance;
    public int fase1;
    public int fase2;
    public int fase3;
    public int fase4;
    public int rank;
    public int rank2;
    
    public  int coinsCollected;
    public  int coinsMenu;
    public int coinsTotal;

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
        coinsTotal = data.coinsTotal;
        fase1 = data.fase1;
        fase2 = data.fase2;
        rank = data.rank;
        rank2 = data.rank2;
    }

    public void SaveData(ref GameData data)
    {
        data.coinsCollected = coinsMenu;
        data.coinsTotal = coinsTotal;
        data.fase1 = fase1;
        data.fase2 = fase2;
        data.rank = rank;
        data.rank2 = rank2;
    }
}
