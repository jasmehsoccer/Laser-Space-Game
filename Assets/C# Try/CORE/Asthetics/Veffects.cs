using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private ParticleSystem hit_effect;
    [SerializeField] private ParticleSystem explosion_effect;
    [SerializeField] private ParticleSystem die_effect;

    private void OnEnable()
    {
        Health.onDie += health_onDie;
    }



    private void OnDisable()
    {
        Health.onDie -= health_onDie; // Unsubscribing from the event
    }

    private void health_onDie(object sender, EventArgs e)
    {
        play_die_effect();
    }

    private void play_die_effect()
    {
        if (die_effect != null)
        {

            Instantiate(die_effect, this.transform.position, Quaternion.identity);


        }

    }

    public void play_hit()
    {
        Debug.Log("Hit!");
        if (hit_effect != null)
        {
            Instantiate(hit_effect, this.transform.position,Quaternion.identity ); 
        }
    }
}
