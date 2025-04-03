using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedLevel : MonoBehaviour
{
    public bool unlocked;

    public string id;

    public Sprite unlockedSprite;
    public Image lockedSprite;

    private void Start()
    {
        UnlockLevel();
        DataPersistenceManager.instance.LoadUnlockedLevels(id, unlocked, lockedSprite, unlockedSprite);      
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            UnlockLevel();
        }
    }

    public void UnlockLevel()
    {
        DataPersistenceManager.instance.SaveUnlockedLevel(id, unlocked);
       // DataPersistenceManager.instance.SaveGame();
        //DataPersistenceManager.instance.LoadGame();
    }
}
