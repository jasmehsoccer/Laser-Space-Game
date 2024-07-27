using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameSession.OnTriggerBoss += bossEnter;



    }

    private void OnEnable()
    {
        
    }

    private void bossEnter(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Debug.Log("Boss Fight");
    }

    private void OnDisable()
    {
        gameSession.OnTriggerBoss -= bossEnter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
