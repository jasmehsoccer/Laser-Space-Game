using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veffects : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private ParticleSystem hit_effect;
    [SerializeField] private ParticleSystem explosion_effect;
    private void play_explosion_effect() 
    {
        if (explosion_effect != null)
        {
    
            explosion_effect.Play();
            

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
