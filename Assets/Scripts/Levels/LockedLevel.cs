using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedLevel : MonoBehaviour, IDataPersistence
{
    public bool unlocked;

    public string id;
    public int costToUnlock;

    public Sprite unlockedSprite;
    public Image lockedSprite;

    public GameObject lockedUI;
    public GameObject unlockedUI;

    private void Start()
    {
        DataPersistenceManager.instance.LoadUnlockedLevels(id, unlocked, lockedSprite, unlockedSprite);      
    }

    public void UnlockLevel()
    {
        if (CollectablesManager.coinsMenu < costToUnlock)
        {
            //tocar som de moedas não suficientes
            Debug.Log("moedas faltando");
        }

        else if (CollectablesManager.coinsMenu >= costToUnlock)
        {
            unlocked = true;
            Debug.Log("level desbloqueado");
            DataPersistenceManager.instance.SaveUnlockedLevel(id, unlocked);
            DataPersistenceManager.instance.LoadUnlockedLevels(id, unlocked, lockedSprite, unlockedSprite);
            DataPersistenceManager.instance.SaveGame();
            DataPersistenceManager.instance.LoadGame();
            lockedUI.SetActive(false);
        }
    }

    public void OpenLevelUnlocker()
    {
        {
            if (unlocked)
            {
                unlockedUI.SetActive(true);
            }

            else
            {
                lockedUI.SetActive(true);
            }
        }              
    }

    public void CloseLevelUnlocker()
    {
        if (unlocked)
        {
            unlockedUI.SetActive(false);
        }

        else
        {
            lockedUI.SetActive(false);
        }
    }

    public void LoadData(GameData data)
    {
        unlocked = data.levelUnlocked;
    }

    public void SaveData(ref GameData data)
    {
        data.levelUnlocked = unlocked;
    }
}
