using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private ParticleSystem hit_effect;
    [SerializeField] private ParticleSystem explosion_effect;
    private void Start()
    {
        Health.onTakeDamage += Health_onTakeDamage;

    }

    private void Health_onTakeDamage()
    {
        play_hit_effect();

    }

    private void OnDisable()
    {
        Health.onTakeDamage -=Health_onTakeDamage;
    }

    private void play_hit_effect()
    {
        Debug.Log("Effect Played");
        if (hit_effect != null) 
        {
            
            Instantiate(hit_effect, transform.position, Quaternion.identity);

        }
        
    }
    private void play_explosion_effect() 
    {
        if (explosion_effect != null)
        {
    
            explosion_effect.Play();
            

        }

    }
}
