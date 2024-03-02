using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static EventHandler onDie; // Observer pattern
    public static event Action onTakeDamage;
    [SerializeField] private int MaxHealth = 25;
    [SerializeField] private int health;


    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage(int damage)
    {
        if (health <= 0)
        {
            Destroy(gameObject);// Give control back to the main code method.

        }

        health = Mathf.Max(health-damage, 0); // If more damage is dealt by the projectile on the enemy or player, than the health, just set the health to zero. 
        onTakeDamage?.Invoke();
        if (health == 0)
        {
            onDie?.Invoke(this, EventArgs.Empty);//Invoking an event. Asking Has this event been activated.


        }

        
    }

}
