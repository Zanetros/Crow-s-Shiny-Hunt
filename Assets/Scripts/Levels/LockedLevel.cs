using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockedLevel : MonoBehaviour
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
        //DataPersistenceManager.instance.LoadLevelCoins(ScoreManager.currentLevel, ScoreManager.levelCoinsCollected);

        if (lockedSprite.sprite == unlockedSprite)
        {
            unlocked = true;
        }
    }

    public void UnlockLevel()
    {
        if (CollectablesManager.instance.coinsMenu < costToUnlock)
        {
            //tocar som de moedas n�o suficientes
            Debug.Log("moedas faltando");
        }

        else if (CollectablesManager.instance.coinsMenu >= costToUnlock)
        {
            CollectablesManager.instance.coinsMenu = CollectablesManager.instance.coinsMenu - costToUnlock;
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
}
