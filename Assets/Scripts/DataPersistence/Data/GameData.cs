using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
   public int coinsCollected;

   public SerializableDictionary<string, bool> collectedCoins;

   public GameData()
   {
        this.coinsCollected = 0;
        collectedCoins = new SerializableDictionary<string, bool>();
   }
}
