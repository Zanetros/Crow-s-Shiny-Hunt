using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectablesInterface : MonoBehaviour
{
   public TextMeshProUGUI coinText;

   private void Start()
   {
      coinText.text = "X " + PlayerPrefs.GetInt("coins", CollectablesManager.coinsMenu).ToString();
   }
}
