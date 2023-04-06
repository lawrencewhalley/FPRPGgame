using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public bool hasEnteredZone = false;
    public Collider PlayerEnteringtheZone;
    private void OnTriggerEnter(Collider TheThingEnteringTheTrigger)
    {
        if(TheThingEnteringTheTrigger.tag == "Player")
        {
            hasEnteredZone = true;
            PlayerEnteringtheZone = TheThingEnteringTheTrigger;
            EPromptCanvas.enabled = true;
        }
    }
    private void OnTriggerExit(Collider TheThingEnteringTheTrigger)
    {
        if (TheThingEnteringTheTrigger.tag == "Player")
        {
            hasEnteredZone = false;
            PlayerEnteringtheZone = null;
            EPromptCanvas.enabled = false;
        }
    }


}
