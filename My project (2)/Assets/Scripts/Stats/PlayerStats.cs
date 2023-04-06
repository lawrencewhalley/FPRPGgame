using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged (Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armour.addModifier(newItem.armorModifier);
            damage.addModifier(newItem.damageModifier);
            health.addModifier(newItem.healthModifier);
            currentHealth = currentHealth + newItem.healthModifier;
            _healthbar.updateHealthBar(health.GetValue(), currentHealth);

        }
        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
            health.RemoveModifier(oldItem.healthModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.Killplayer();
    }
}
