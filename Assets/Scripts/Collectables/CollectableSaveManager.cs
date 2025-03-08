using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSaveManager : MonoBehaviour
{
    public List<GameObject> collectables;

    public void Update()
    {
        SaveCoinsCollected();
    }

    public void SaveCoinsCollected()
    {
        for (int i = 0; i < collectables.Count; i++)
        {
            if (!collectables[i].gameObject.activeSelf)
            {
                Debug.Log("desligado");
            }
        }
    }
}
