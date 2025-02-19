using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableInterface : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    
    public void ManageUI()
    {
        coinText.text = CollectablesManager.Instance.coinCount.ToString();
    }
}
