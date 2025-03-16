using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")] [SerializeField]
    private string fileName;
    
    public GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void Start()
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    
    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        
        if (this.gameData == null)
        {
            gameData = new GameData();
        }
        
        if (this.gameData == null) 
        {
            Debug.Log("No data was found. A New Game needs to be started before data can be loaded.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(gameData);
        }
        
        Debug.Log("List of coins collected " + gameData.collectedCoins.Count);
    }

    public void SaveGame()
    {
        if (this.gameData == null) 
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Number of coins collected: " + gameData.coinsCollected);
        Debug.Log("List of coins collected " + gameData.collectedCoins.Count);
        
        dataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void AddCoin(string id, bool collected)
    {
        if (gameData.collectedCoins.ContainsKey(id))
        {
            gameData.collectedCoins.Remove(id);
        }
        gameData.collectedCoins.Add(id, collected);
    }

    public void LoadCoin(string id, bool collected, GameObject gameObject)
    {
        gameData.collectedCoins.TryGetValue(id, out collected);
        if (collected)
        {
            gameObject.SetActive(false);
        }
    }
}
