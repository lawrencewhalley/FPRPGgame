using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : ShowPrompt
{

    public Item item;
    
    public override void Interact()
    {
        base.Interact();
        pickUp();
    }
    void pickUp()
    {
        
        Debug.Log("picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
