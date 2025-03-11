using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    public Toggle fullScreenTog;
    
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    public TMP_Dropdown dropDownResolution;

    public void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        
        
    }

    public void ApplyConfigs()
    {
        Screen.fullScreen = fullScreenTog.isOn;

        if (selectedResolution == 0)
        {
            Screen.SetResolution(resolutions[0].horizontal, resolutions[0].vertical, fullScreenTog.isOn);
        }

        else if (selectedResolution == 1)
        {
            Screen.SetResolution(resolutions[1].horizontal, resolutions[1].vertical, fullScreenTog.isOn);
        }

        else if (selectedResolution == 2)
        {
            Screen.SetResolution(resolutions[2].horizontal, resolutions[2].vertical, fullScreenTog.isOn);
        }

        else if (selectedResolution == 3)
        {
            Screen.SetResolution(resolutions[3].horizontal, resolutions[3].vertical, fullScreenTog.isOn);
        }

        else if (selectedResolution == 4)
        {
            Screen.SetResolution(resolutions[4].horizontal, resolutions[4].vertical, fullScreenTog.isOn);
        }
    }

    public void ChangeResolution()
    {
        selectedResolution = dropDownResolution.value;
        
        Debug.Log(selectedResolution);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
