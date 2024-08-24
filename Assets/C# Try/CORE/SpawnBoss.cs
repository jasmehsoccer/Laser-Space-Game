using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{

    [SerializeField] GameObject Boss;
    private void OnEnable()
    {
        gameSession.OnTriggerBoss += spawnBoss;
    }

    private void spawnBoss(object sender, EventArgs e)
    {
        Instantiate(Boss, transform.position, Quaternion.identity);
    }

    private void OnDisable()
    {
        gameSession.OnTriggerBoss -= spawnBoss;
    }

}
