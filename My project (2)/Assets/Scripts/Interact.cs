using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class ShowPrompt : MonoBehaviour
{
    public UnityEvent<ShowPrompt> OnitemPickup;
    public InteractZone triggerZone;
    private Canvas promptCanvas;

    void Update()
    {
        if (triggerZone.hasEnteredZone == true)
        {
                if (Input.GetKeyDown("e"))
                {
                    promptCanvas = triggerZone.EPromptCanvas;
                    ShowPrompt Item = triggerZone.PlayerEnteringtheZone.GetComponent<ShowPrompt>();
                    Interact();
                    promptCanvas.enabled = false;
                    Destroy(gameObject);
                    
                }
        }
    }

    public virtual void Interact()
    {
        
    }
}
