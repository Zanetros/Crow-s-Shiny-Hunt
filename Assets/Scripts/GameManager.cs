using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public GameObject mouse;
   
   private void Awake()
   {
      mouse = GameObject.Find("VirtualMouseUI");
      
      Gamepad gamepad = Gamepad.current;

      if (gamepad == null)
      {
         mouse.SetActive(false);
      }
      
      if (instance == null)
      {
          instance = this;
          DontDestroyOnLoad(this.gameObject);
      }
          
      else Destroy(this.gameObject);
   }
   
   private void OnEnable()
   {
      InputSystem.onDeviceChange += OnDeviceChange;
   }

   private void OnDisable()
   {
      InputSystem.onDeviceChange -= OnDeviceChange;
   }

   private void OnDeviceChange(InputDevice device, InputDeviceChange change)
   {
      Debug.Log($"Device change detected: {device} - Change: {change}");
      if (change == InputDeviceChange.Disconnected)
      {
         Debug.Log($"Device disconnected: {device}");
         // Handle controller disconnection
         mouse.SetActive(false);
      }
      else if (change == InputDeviceChange.Added)
      {
         Debug.Log($"Device added: {device}");
         // Handle controller reconnection
         mouse.SetActive(true);
      }
   }
}
