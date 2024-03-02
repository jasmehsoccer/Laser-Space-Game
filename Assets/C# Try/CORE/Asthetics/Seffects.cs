using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Seffects : MonoBehaviour
{
    [SerializeField] private AudioClip s_hit_effect;
    [SerializeField] private AudioClip s_explosion_effect;
    [SerializeField] private AudioSource enemySource;

    private void Start()
    {
        enemySource = GetComponent<AudioSource>();  
    }
    public void play_sound_effect()
    {
        if(s_hit_effect != null)
        {
            enemySource.Play();
        }
    }
}
