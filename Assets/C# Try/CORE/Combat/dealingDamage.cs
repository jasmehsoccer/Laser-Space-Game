using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealingDamage : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Health>(out Health component)) 
        {
            component.DealDamage(damage);
            Debug.Log("Damage was dealt");
            Destroy(this.gameObject);

        
        }
        if(collision.TryGetComponent<Veffects>(out Veffects v_component))
        {
            v_component.play_hit();

        }
        if (collision.TryGetComponent<Seffects>(out Seffects s_component))
        {
            s_component.play_sound_effect();

        }



    }

}
