using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seffects : MonoBehaviour
{
    [SerializeField] private AudioClip s_hit_effect;
    [SerializeField] private AudioClip s_explosion_effect;
    [SerializeField] private AudioSource enemySource;
    [SerializeField] private AudioSource enemySourceExplosion;


    private void Start()
    {
        enemySource = GetComponent<AudioSource>();  
    }

    private void OnEnable()
    {
        Health.onDie+=health_onDie;
    }

    private void OnDisable()
    {
        Health.onDie -= health_onDie;
    }

    private void health_onDie(object sender, EventArgs e)
    {
        play_sound_explosion_effect();
    }

    public void play_sound_effect()
    {
        if(s_hit_effect != null)
        {
            enemySource.clip = s_hit_effect;    
            enemySource.Play();
        }
    }

    public void play_sound_explosion_effect()
    {
        if (s_explosion_effect != null)
        {
            enemySourceExplosion.clip = s_explosion_effect;
            enemySourceExplosion.Play(); 
        }
    }
}
