using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    
    // 1
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;

    private int selectedIndex; // 2
    
    public void OnPointerClick(PointerEventData eventData) // 1
    {
        selectedIndex++; // 2
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length; // 3

        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex; // 4

        // 5
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
            break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
            break;
        }
    }
}
