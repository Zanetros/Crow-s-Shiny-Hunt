using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
   public int coinsCollected;
   public int coinsTotal;

   public SerializableDictionary<string, bool> collectedCoins;
   public SerializableDictionary<string, bool> unlockedLevels;

   public GameData()
   {
        this.coinsCollected = 0;
        this.coinsTotal = 0;
        collectedCoins = new SerializableDictionary<string, bool>();
        unlockedLevels = new SerializableDictionary<string, bool>();
   }
}
