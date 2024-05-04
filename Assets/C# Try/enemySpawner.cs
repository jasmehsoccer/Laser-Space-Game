using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<waveConfig> waveConfig;
    [SerializeField] int startWave = 0;
    [SerializeField] bool looping = false;
    [SerializeField] float nextWaveCountdown = 5f;
    // Start is called before the first frame update
    // Make a blank C# class and create Character creator class: Write a message, "Please fill out form". Make a class called Character Creator. Make many private variables. Create getters and setters. Make a consructor. 
    IEnumerator Start()
    {
        do
        {
           
            yield return StartCoroutine(SpawnAllWaves());

        }
        while (looping);
    }

    
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = 0; waveIndex < waveConfig.Count; waveIndex++) 
        {
            var currentWave = waveConfig[waveIndex];

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));


        }
    }

    private IEnumerator SpawnAllEnemiesInWave(waveConfig currentWave)
    {
        for (int enemyCounter = 0; enemyCounter <= currentWave.GetNumSpawn();enemyCounter++)
        {
            if (enemyCounter == currentWave.GetNumSpawn())
            {
                Debug.Log("Starting Next Wave Timer");
                yield return new WaitForSeconds(nextWaveCountdown);
            }
            var newEnemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoint()[0].transform.position, Quaternion.identity) ;
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(currentWave);
            
            yield return new WaitForSeconds(currentWave.GetSpawnWait());
        }
    }



    // Update is called once per frame

}

