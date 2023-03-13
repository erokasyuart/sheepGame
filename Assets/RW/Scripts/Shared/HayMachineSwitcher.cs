using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;
    private int selectedIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectedIndex++;
        selectedIndex %= Enum.GetValues(typeof(HayMachineColour)).Length; //mod!
        //blue = 0; yellow = 1; red = 2
        //% == x / 2

        GameSettings.hayMachineColour = (HayMachineColour)selectedIndex;

        //5
        switch (GameSettings.hayMachineColour)
        {
            case HayMachineColour.Blue:
                blueHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                break;
            case HayMachineColour.Yellow:
                blueHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                break;
            case HayMachineColour.Red:
                blueHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                break;
        }
    }
}
