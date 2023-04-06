using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class attack: MonoBehaviour
{
    public UnityEvent<ShowPrompt> OnitemPickup;
    public InteractZone triggerZone;
    private Canvas promptCanvas;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (triggerZone.hasEnteredZone == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                promptCanvas = triggerZone.EPromptCanvas;
                attack Item = triggerZone.PlayerEnteringtheZone.GetComponent<attack>();
                promptCanvas.enabled = false;
                Attack();
            }
        }
    }

    public virtual void Attack()
    {

    }


}
