using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
   public int coinsCollected;
   public int coinsTotal;
   public int fase1;
   public int fase2;
   
   public SerializableDictionary<string, bool> collectedCoins;
   public SerializableDictionary<string, bool> unlockedLevels;
   public SerializableDictionary<string, int> levelsCoinsCollected;

   public GameData()
   {
        this.coinsCollected = 0;
        this.coinsTotal = 0;
        fase1 = 0;
        fase2 = 0;
        collectedCoins = new SerializableDictionary<string, bool>();
        unlockedLevels = new SerializableDictionary<string, bool>();
        levelsCoinsCollected = new SerializableDictionary<string, int>();
   }
}
