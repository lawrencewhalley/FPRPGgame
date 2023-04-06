using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int currentStamina;
    public int currentHealth;
    public Stat damage;
    public Stat armour;
    public Stat Stamina;
    public Stat health;

    [SerializeField] public healthBarScript _healthbar;


    private void Awake()
    {
        currentHealth = health.GetValue();
        currentStamina = Stamina.GetValue();
        _healthbar.updateHealthBar(health.GetValue(), currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {

        damage-= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // ensures that when we take damage if AR is higher than damage taken we dont heal due to positive damage

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");
        _healthbar.updateHealthBar(health.GetValue(), currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //overwrite death method

        Debug.Log(transform.name + " Died");
    }


}
